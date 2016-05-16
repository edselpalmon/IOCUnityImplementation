using IOCFactory;
using NHibernate;
using ServiceInterfaces;

namespace SelfHostedHRMSService
{
    public static class DALSession
    {
        private static IHibernateDAL _DAL;

        public static IHibernateDAL GetDAL()
        {
            if (_DAL == null)
            {
                _DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
                _DAL.OpenHibernateSession<ISession>("HRMSDB");
            }

            return _DAL;
        }

    }
      
}
