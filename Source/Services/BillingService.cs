using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceInterfaces;

namespace Services
{
    public class BillingService : IService
    {
        public BillingService()
        { }
        public string Process()
        {
            return "Billing service process executed";
        }
    }
}
