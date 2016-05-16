using SelfHostedHRMSService.DataContracts;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SelfHostedHRMSService
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "Authenticate",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          Method = "POST")]
        User Authenticate();

        [OperationContract]
        [WebInvoke(UriTemplate = "Logout",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          Method = "POST")]
        void Logout();
    }
}