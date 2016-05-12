using System.ServiceModel;
using WindowsService1.DataContracts;

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


    