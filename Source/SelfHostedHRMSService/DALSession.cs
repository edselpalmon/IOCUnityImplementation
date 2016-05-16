using IOCFactory;
using NHibernate;
using ServiceInterfaces;

namespace SelfHostedHRMSService
{
    //public class DALSession
    //{
    //    private static readonly IHibernateDAL _DAL;

    //    public static IHibernateDAL GetDAL()
    //    {
    //        if (_DAL == null)
    //        {
    //            _DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
    //            _DAL.OpenHibernateSession<ISession>("HRMSDB");
    //        }

    //        return _DAL;
    //    }

    //}

    public sealed class DALSession
    {
        private static readonly DALSession _instance = new DALSession();

        public static IHibernateDAL DAL;

        public static DALSession Instance
        {
           get { return _instance; }
        }

        DALSession()
        {
            if (DAL == null)
            {
                DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
                DAL.OpenHibernateSession<ISession>("HRMSDB");
            }
        }

    }

}
