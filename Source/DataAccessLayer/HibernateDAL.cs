using DataAccessClass;
using Entities;
using NHibernate;
using NHibernate.Cfg;
using ServiceInterfaces;
using System;

namespace DataAccessLayer
{
    public class HibernateDAL : IHibernateDAL
    {
        private ISession _session;
        
        public HibernateDAL()
        {
            _session = new Configuration().Configure().BuildSessionFactory().OpenSession();

        }
        public IChannel GetChannelById(int channelId)
        {
            var channel = new Channel();

            using (var trx = _session.BeginTransaction())
            {
                channel = _session.Get<Channel>(channelId);
                trx.Commit();
            }

            return channel;
        }

        public void SaveChannel(IChannel channel)
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

        /*generic DAL methods*/
        public T GetRecordsById<T>(Int64 recordId)
        {

            using (var trx = _session.BeginTransaction())
            {
                var records = _session.Get<T>(recordId);
                trx.Commit();
                return records;
            }           
        }

        public T SaveInformation<T>(T recordInformation)
        {
            using (var trx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(recordInformation);
                trx.Commit();
                return recordInformation;
            }
        }


    }
}
