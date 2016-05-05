using System.ServiceModel;
using System.ServiceModel.Web;

namespace WindowsService1
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