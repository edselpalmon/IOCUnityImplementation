using DataAccessClass;
using NHibernate;
using NHibernate.Cfg;


namespace DataAccessLayer
{
    public class HibernateDAL
    {
        private ISession _session;
        
        public HibernateDAL()
        {
            _session = new Configuration().Configure().BuildSessionFactory().OpenSession();

        }
        public Channel GetChannelById(int channelId)
        {
            var channel = new Channel();

            using (var trx = _session.BeginTransaction())
            {
                channel = _session.Get<Channel>(channelId);
                trx.Commit();
            }

            return channel;
        }

        public void SaveChannel(Channel channel)
        {
            using (var trx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(channel);
                trx.Commit();
            }
        }
    }
}
