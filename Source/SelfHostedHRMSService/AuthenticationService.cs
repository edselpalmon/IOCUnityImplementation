using AutoMapper;
using EntityInterfaces;
using SelfHostedHRMSService.DataContracts;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedHRMSService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AuthenticationService : IAuthenticationService
    {
        private IHibernateDAL _DAL;
        private IMapper _Mapper;

        public AuthenticationService()
        {
            _DAL = DALSession.GetDAL();
            _Mapper = Mapper.GetMapper();
        }
        /// <summary>
        /// Authenticates the User and generate a session token
        /// </summary>
        /// <returns></returns>
        public User Authenticate()
        {
            try
            {
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
                        var userInfoWithToken = Token.GenerateSessionToken(userInfo);

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
                        Token.ClearSessionToken(user);
                    }

                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                }
            }
            catch
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
            }
        }


        //private bool ValidateSessionToken(string token)
        //{

        //    var tokenCredentials = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(token));

        //    var userToken = (from user in _DAL.GetRecords<IUser>()
        //                     where user.UserToken == tokenCredentials
        //                     && user.TokenExpiryDate > DateTime.Now
        //                     select user.UserToken).FirstOrDefault();
        //    if (!string.IsNullOrEmpty(userToken))
        //    {
        //        return true;
        //    }

        //    return false;

        //}

        //private IUser GenerateSessionToken(IUser userInfo)
        //{
        //    userInfo.UserToken = Tokenizer.Hash.Get(userInfo.EmployeeInformation.FirstName + userInfo.EmployeeInformation.LastName + DateTime.Now.ToString("MMddyyyyhhmmss"), Tokenizer.HashType.MD5, ASCIIEncoding.UTF8);
        //    userInfo.TokenExpiryDate = DateTime.Now.AddHours(30); //Token will expire in 1 month. In prep for differnt authentication approach where in the token will be sent via email and will be used as a login.

        //    _DAL.SaveRecord<IUser>(userInfo);

        //    return userInfo;
        //}

        //private void ClearSessionToken(IUser userInfo)
        //{
        //    userInfo.UserToken = null;
        //    userInfo.TokenExpiryDate = null;

        //    _DAL.SaveRecord<IUser>(userInfo);
        //}
    }
}
