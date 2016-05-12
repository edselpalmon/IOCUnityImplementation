using EntityInterfaces;
using IOCFactory;
using NHibernate;
using ServiceInterfaces;
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
        private IHibernateDAL _DAL;
        private ISession _DBSession;

        public RestAuthorizationManager()
        {
            _DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
            _DBSession = _DAL.OpenHibernateSession<ISession>("HRMSDB");
        }

        protected override bool CheckAccessCore(OperationContext operationContext)
        {

            try                                                 {

                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;

                if (WebOperationContext.Current.IncomingRequest.Method == "OPTIONS") return true; //added this is for proper preflight handling

                //Extract the Authorization header, and parse out the credentials converting the Base64 string:  
                var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                var tokenHeader = WebOperationContext.Current.IncomingRequest.Headers["Token"];
                if (tokenHeader != null)
                {
                    //do the alogorithm for validating the token
                }
                else if ((authHeader != null) && (authHeader != string.Empty))
                {
                    var svcCredentials = ASCIIEncoding.ASCII
                        .GetString(Convert.FromBase64String(authHeader.Substring(6)))
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

                    if(userInfo != null)
                    {
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
