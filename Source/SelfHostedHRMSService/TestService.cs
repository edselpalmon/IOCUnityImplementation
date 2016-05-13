using System.ServiceModel;
using SelfHostedHRMSService.DataContracts;

namespace SelfHostedHRMSService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TestService : ITestService       
    {
        public User Authenticate()  //fake auth
        {
            var userinfo = new User { UserName = "edselle23", UserRole = "Admin", FirstName = "Edsel", LastName = "Palmon" };
            return userinfo;
        }
      
    }
   
   
}


    