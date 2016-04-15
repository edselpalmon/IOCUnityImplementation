using System;
using System.ServiceModel.Activation;
using System.Web.Routing;
using IOCFactory;
using ServiceInterfaces;
using System.Collections.Generic;
using NHibernate;

namespace HRMSService
{
    public class Global : System.Web.HttpApplication
    {

        public static IHibernateDAL DAL { get; private set; }
        public static ITransactionLogger Logger { get; private set; }

        private ISession DBSession;

        protected void Application_Start(object sender, EventArgs e)
        {
            DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
            Logger = DependencyFactory.Resolve<ITransactionLogger>("TransactionLogger");
            DBSession = DAL.OpenHibernateSession<ISession>("HRMSDB");

            RouteTable.Routes.Add(new ServiceRoute("EmployeeService", new WebServiceHostFactory(), typeof(EmployeeService)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            DBSession.Close();
            DBSession.Dispose();
        }
    }
}