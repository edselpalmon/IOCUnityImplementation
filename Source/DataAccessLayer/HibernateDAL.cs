using DataAccessClass;
using Entities;
using NHibernate;
using NHibernate.Cfg;
using ServiceInterfaces;
using System;

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

        public IEmployeeInformation GetEmployeeById(Int64 employeeId)
        {
            IEmployeeInformation employee;

            using (var trx = _session.BeginTransaction())
            {
                employee = _session.Get<EmployeeInformation>(employeeId);
                trx.Commit();
            }

            return employee;
        }

        public Int64 SaveEmployeeInformation(IEmployeeInformation employeeInformation)
        {
            using (var trx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(employeeInformation);
                trx.Commit();
            }

            return employeeInformation.EmployeeId;
        }

    }
}
