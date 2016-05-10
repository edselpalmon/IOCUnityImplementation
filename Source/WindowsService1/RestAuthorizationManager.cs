using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public class RestAuthorizationManager : ServiceAuthorizationManager
    {

        protected override bool CheckAccessCore(OperationContext operationContext)
        {

            try
            {

                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                string headers = request.Headers["Authorization"];

                //Extract the Authorization header, and parse out the credentials converting the Base64 string:  
                var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                if ((authHeader != null) && (authHeader != string.Empty))
                {
                    var svcCredentials = ASCIIEncoding.ASCII
                        .GetString(Convert.FromBase64String(authHeader.Substring(6)))
                        .Split(':');
                    var user = new
                    {
                        Name = svcCredentials[0],
                        Password = svcCredentials[1]
                    };
                    if ((user.Name == "edsel" && user.Password == "test"))
                    {
                        //User is authrized and originating call will proceed  
                        return true;
                    }
                }

                //not authorized  
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate: Basic Realm=\"Edsel\"");
                return false;

            }
            catch
            {
                throw new WebFaultException(HttpStatusCode.Forbidden);
            }
        }

    }
}
