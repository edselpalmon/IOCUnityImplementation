using System;
using System.ServiceModel.Activation;
using System.Web.Routing;
using IOCFactory;
using ServiceInterfaces;
using NHibernate;
using System.Web;
using AutoMapper;
using EntityInterfaces;
using HRMSService.DataContracts;

namespace HRMSService
{
    public class Global : System.Web.HttpApplication
    {

        public static IHibernateDAL DAL { get; private set; }
        public static ITransactionLogger Logger { get; private set; }  
        public static IMapper Mapper { get; private set; }

        private ISession DBSession;

        protected void Application_Start(object sender, EventArgs e)
        {
            DAL = DependencyFactory.Resolve<IHibernateDAL>("HibernateDAL");
            Logger = DependencyFactory.Resolve<ITransactionLogger>("TransactionLogger");
            DBSession = DAL.OpenHibernateSession<ISession>("HRMSDB");

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<IEmployeeAddress, EmployeeAddress>();
                cfg.CreateMap<IEducationalBackground, EducationalBackground>();
                cfg.CreateMap<IEmployementHistory, EmployementHistory>();
                cfg.CreateMap<IEmployeeInformation, EmployeeInformation>();
            });

            Mapper = config.CreateMapper();

            RouteTable.Routes.Add(new ServiceRoute("EmployeeService", new WebServiceHostFactory(), typeof(EmployeeService)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Authorization, Content-Type, Accept");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
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