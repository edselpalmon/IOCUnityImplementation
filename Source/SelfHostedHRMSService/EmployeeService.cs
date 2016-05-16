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
using SelfHostedHRMSService.DataContracts;
using System.Linq;
using System.Net;

namespace SelfHostedHRMSService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EmployeeService : IEmployeeService
    {
        private IHibernateDAL _DAL;
        private IMapper _Mapper;

        public EmployeeService()
        {
            _DAL = DALSession.DAL;
            _Mapper = Mapper.GetMapper();
        }
        
        //note: EmployeeInformation is a datacontract. IEmployeeInformation is the interface of Employeeinformation Entity
        public EmployeeInformation GetEmployeeById(int EmployeeId)
        {
            try
            {
                var token = WebOperationContext.Current.IncomingRequest.Headers["Token"];

                if (Token.ValidateSessionToken(token))
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

                if (Token.ValidateSessionToken(token))
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
       
    }
}
