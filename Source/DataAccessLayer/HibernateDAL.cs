using NHibernate;
using NHibernate.Cfg;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class HibernateDAL : IHibernateDAL
    {
        private ISession _session;
        private IDALSessionFactory _factory;

        public IDictionary<string, ISessionFactory> FactorySessions { get; private set; }

        #region constructors

        public HibernateDAL(IDALSessionFactory factory) //contructor to be used for multiple db sources then call OpenHibernateSession  
        {
            _factory = factory;

        }
        
        public HibernateDAL(string connectionString) //using Connection string
        {

            _session = new Configuration()
                .Configure()
                .SetProperty("connection.connection_string", connectionString)
                .BuildSessionFactory().OpenSession();

        }

        public HibernateDAL(IDbConnection conn) //using connection object
        {
            _session = new Configuration()
                .Configure()
                .BuildSessionFactory().OpenSession(conn);

        }

        #endregion

        #region public methods

        public IChannel GetChannelById(int channelId)
        {
            IChannel channel;

            using (var trx = _session.BeginTransaction())
            {
                channel = _session.Get<IChannel>(channelId);
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
                employee = _session.Get<IEmployeeInformation>(employeeId);
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

        #endregion

        #region public generic DAL methods

        public T OpenHibernateSession<T>(string connectionName) 
        {
            FactorySessions = _factory.CreateSessionFactory<ISessionFactory>();

            foreach (var sessionFactory in FactorySessions)
            {
                if (connectionName == sessionFactory.Key)
                {
                    _session = sessionFactory.Value.OpenSession();

                }
            }

            return (T)_session;

        }

        public T GetRecordsById<T>(Int64 recordId)
        {
            using (var trx = _session.BeginTransaction())
            {
                var records = _session.Get<T>(recordId);
                trx.Commit();
                return records;
            }           
        }

        public void DeleteRecords<T>(T recordInformation)
        {
            try
            {
                using (var trx = _session.BeginTransaction())
                {
                    _session.Delete(recordInformation);
                    _session.Flush();
                    trx.Commit();
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public T SaveInformation<T>(T recordInformation)
        {
            try
            {
                using (var trx = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(recordInformation);
                    _session.Flush();
                    trx.Commit();
                    return recordInformation;
                }
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public T LoadRecordInfo<T>(Int64 recordId)
        {

            using (var trx = _session.BeginTransaction())
            {
                var records = _session.Load<T>(recordId);
                trx.Commit();
                return records;
            }
        }
        
        #endregion

    }
}
