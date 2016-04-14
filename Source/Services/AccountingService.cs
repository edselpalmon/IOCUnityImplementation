using ServiceInterfaces;
using EntityInterfaces;

namespace Services
{
    public class AccountingService : IService, IAccountingService
    {

        public AccountingService()
        {
        }

        public string Process()
        {
            return "Accounting service process executed";
        }

        public string AuditProcess()
        {
            return "Accounting service audit process executed";
        }

        public IAccounting SetAccountInformation(IAccounting accountInformation)
        {
            var accountInfo = accountInformation;

            return accountInfo;
        }


    }
}
