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
        //string UserName { [OperationContract] get; [OperationContract] set; }
        //string Password { [OperationContract] get; [OperationContract] set; }

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

        [OperationContract]
        [WebInvoke(UriTemplate = "Authenticate",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          Method = "POST")]
        User Authenticate();
    }
}