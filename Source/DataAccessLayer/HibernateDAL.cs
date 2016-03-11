using NHibernate;
using NHibernate.Cfg;


namespace DataAccessLayer
{
    public class HibernateDAL
    {
        public DataAccessClass.Channel GetChannelById(int channelId)
        {
            ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            return session.Get<DataAccessClass.Channel>(channelId);
        }
    }
}
