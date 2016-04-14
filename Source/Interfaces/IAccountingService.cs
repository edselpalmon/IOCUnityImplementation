using EntityInterfaces;

namespace ServiceInterfaces
{
    public interface IAccountingService
    {
        string AuditProcess();
        IAccounting SetAccountInformation(IAccounting accountInformation);

    }
}
