using EntityInterfaces;
using HRMSService.DataContracts;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace HRMSService
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebInvoke(UriTemplate = "GetEmployeeByIdX",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        string GetEmployeeByIdX(int EmployeeId);

        [WebInvoke(UriTemplate = "GetEmployeeById",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        EmployeeInformation GetEmployeeById(int EmployeeId);
    }
}