using IOCFactory;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = IOCDependencyFactory.Resolve<IService>("Service");
            var accountingService = IOCDependencyFactory.Resolve<IAccountingService>("AccountingService");
            var billingService = IOCDependencyFactory.Resolve<IService>("BillingService");
            var paymentService = IOCDependencyFactory.Resolve<IService>("PaymentService");
            var accountInformation = IOCDependencyFactory.Resolve<IAccounting>("Accounting");

            accountInformation.FirstName = "Edsel";
            accountInformation.LastName = "Palmon";
            accountInformation.MiddleName = "Villanueva";
            accountInformation.AccountNumber = "92-04629-A";

            var info = accountingService.SetAccountInformation(accountInformation);

            Console.WriteLine("Account Information");
            Console.WriteLine("FirstName: " + info.FirstName);
            Console.WriteLine("LastName: " + info.LastName);
            Console.WriteLine("MiddleName: " + info.MiddleName);
            Console.WriteLine("AccountNumber: " + info.AccountNumber);
            
            Console.WriteLine(service.Process());
            Console.WriteLine(accountingService.AuditProcess());
            Console.WriteLine(billingService.Process());
            Console.WriteLine(paymentService.Process());

            Console.ReadLine();

        }
    }
}
