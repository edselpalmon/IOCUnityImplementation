using AutoMapper;
using EntityInterfaces;
using IOCFactory;
using NHibernate;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WindowsService1.DataContracts;
using System.Linq;
using System.Net;

namespace WindowsService1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EmployeeService : IEmployeeService
    {
        private ISession _DBSession;
        private IHibernateDAL _DAL;
        private IMapper _Mapper;

        public EmployeeService()
        {
            _DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
            _DBSession = _DAL.OpenHibernateSession<ISession>("HRMSDB");
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IEmployeeAddress, EmployeeAddress>();
                cfg.CreateMap<IEducationalBackground, EducationalBackground>();
                cfg.CreateMap<IEmployementHistory, EmployementHistory>();
                cfg.CreateMap<IEmployeeInformation, EmployeeInformation>();
            });

           _Mapper = config.CreateMapper();
        }

        /// <summary>
        /// Authenticates the User and generate a session token
        /// </summary>
        /// <returns></returns>
        public User Authenticate()
        {
            try {
                var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

                if ((authHeader != null) && (authHeader != string.Empty))
                {
                    var svcCredentials = ASCIIEncoding.ASCII
                        .GetString(Convert.FromBase64String(authHeader))
                        .Split(':');
                    var userCredentials = new
                    {
                        Name = svcCredentials[0],
                        Password = svcCredentials[1]
                    };

                    var userInfo = (from user in _DAL.GetRecords<IUser>()
                                    where user.Username == userCredentials.Name
                                    && user.Password == userCredentials.Password
                                    select user).FirstOrDefault();
                    if (userInfo != null)
                    {
                        var userInfoWithToken = GenerateSessionToken(userInfo);
                                                                                                      
                        return new User
                        {
                            FirstName = userInfoWithToken.EmployeeInformation.FirstName,
                            LastName = userInfoWithToken.EmployeeInformation.LastName,
                            UserRole = userInfoWithToken.UserRole,
                            UserToken = userInfoWithToken.UserToken
                        };
                    }
                }

                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return null;
            }
            catch
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
                return null;
            }
        }

        public void Logout()
        {
            try
            {
                var token = WebOperationContext.Current.IncomingRequest.Headers["Token"];

                if ((token != null) && (token != string.Empty))
                {
                    var tokenCredentials = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(token));

                    var user = (from userInfo in _DAL.GetRecords<IUser>()
                                     where userInfo.UserToken == tokenCredentials
                                     select userInfo).FirstOrDefault();

                    if (user != null)
                    {
                        ClearSessionToken(user);
                    }

                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                }  
            }
            catch
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
            }
        }

        //note: EmployeeInformation is a datacontract. IEmployeeInformation is the interface of Employeeinformation Entity
        public EmployeeInformation GetEmployeeById(int EmployeeId)
        {
            try
            {
                var token = WebOperationContext.Current.IncomingRequest.Headers["Token"];

                if (ValidateToken(token))
                {
                    var employee = _DAL.GetRecordById<IEmployeeInformation>(EmployeeId);

                    if (employee == null) //when no records found
                    {
                        return new EmployeeInformation();
                    }

                    var employeeInfo = _Mapper.Map<EmployeeInformation>(employee);

                    return employeeInfo;
                }

                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return null;
            }
            catch
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
                return null;
            }
        }

        public IList<EmployeeInformation> GetEmployees()
        {
            try
            {
                var token = WebOperationContext.Current.IncomingRequest.Headers["Token"];

                if (ValidateToken(token))
                {

                    var employees = _DAL.GetRecords<IEmployeeInformation>();

                    if (employees == null) //when no records found
                    {
                        return new List<EmployeeInformation>();
                    }

                    var listOfEmployees = _Mapper.Map<List<EmployeeInformation>>(employees);

                    return listOfEmployees;
                }

                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return null;
            }
            catch
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
                return null;
            }
        }

        private bool ValidateToken(string token)
        {
           
            var tokenCredentials = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(token));

            var userToken = (from user in _DAL.GetRecords<IUser>()
                             where user.UserToken == tokenCredentials
                             && user.TokenExpiryDate > DateTime.Now
                             select user.UserToken).FirstOrDefault();
            if (!string.IsNullOrEmpty(userToken))
            {
                return true;
            }

            return false;

        }

        private IUser GenerateSessionToken(IUser userInfo)
        {
            userInfo.UserToken = Tokenizer.Hash.Get(userInfo.EmployeeInformation.FirstName + userInfo.EmployeeInformation.LastName + DateTime.Now.ToString("MMddyyyyhhmmss"), Tokenizer.HashType.MD5, ASCIIEncoding.UTF8);
            userInfo.TokenExpiryDate = DateTime.Now.AddHours(30); //Token will expire in 1 month. In prep for differnt authentication approach where in the token will be sent via email and will be used as a login.

            _DAL.SaveRecord<IUser>(userInfo);

            return userInfo;
        }

        private void ClearSessionToken(IUser userInfo)
        {
            userInfo.UserToken = null;
            userInfo.TokenExpiryDate = null; 

            _DAL.SaveRecord<IUser>(userInfo);
        }

    }
}
