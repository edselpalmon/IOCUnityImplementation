using System.ServiceModel;
using System.ServiceModel.Web;
using SelfHostedHRMSService.DataContracts;

namespace SelfHostedHRMSService
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "Authenticate",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          Method = "POST")]
        User Authenticate();


    }
}