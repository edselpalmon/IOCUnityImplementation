using NHibernate;
using NHibernateCfg = NHibernate.Cfg;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessLayer
{
    public class DALSessionFactory : IDALSessionFactory
    {
        public IDictionary<string, T> CreateSessionFactory<T>()
        {
            var sessionFactory = new Dictionary<string, T>();
            for(var i= 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
            {
                if (ConfigurationManager.ConnectionStrings[i].Name == "LocalSqlServer")
                    continue;
                var sessionName = ConfigurationManager.ConnectionStrings[i].Name;
                var connstr = ConfigurationManager.ConnectionStrings[i].ToString();
                sessionFactory.Add(sessionName,
                    (T)new NHibernateCfg.Configuration()
                    .Configure()
                    .SetProperty(NHibernateCfg.Environment.ConnectionString, connstr)
                    .SetProperty(NHibernateCfg.Environment.SessionFactoryName, sessionName)
                    .BuildSessionFactory()
                );
            }

            return sessionFactory;
            
        }
    }
}
