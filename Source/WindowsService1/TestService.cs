using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TestService : ITestService       
    {
        public User Authenticate()  //fake auth
        {
            var userinfo = new User { UserName = "edselle23", UserRole = "Admin", FirstName = "Edsel", LastName = "Palmon" };
            return userinfo;
        }

        //public bool HandleHttpOptionsRequest()
        //{
        //    if (WebOperationContext.Current != null && WebOperationContext.Current.IncomingRequest.Method == "OPTIONS")
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
   
   
}


    