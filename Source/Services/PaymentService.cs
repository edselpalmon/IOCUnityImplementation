using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService : IService
    {

        public PaymentService()
        {
        }

        public string Process()
        {
            return "Payment service process executed";
        }

    }
}
