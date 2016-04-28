using EntityInterfaces;
using HRMSService.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HRMSService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        
        [OperationContract]
        [WebInvoke(UriTemplate = "GetEmployeeById",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          Method = "POST")]
        EmployeeInformation GetEmployeeById(int EmployeeId);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetEmployees",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          Method = "POST")]
        IList<EmployeeInformation> GetEmployees();
    }
}