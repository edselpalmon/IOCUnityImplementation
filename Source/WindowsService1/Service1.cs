using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.ServiceModel;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Configuration;
using System.ServiceModel.Activation;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost serviceHost;

        public Service1()
        {
            InitializeComponent();
        }
               
        protected override void OnStart(string[] args)
        {
            string serviceAddress = "http://localhost:9999/TestService/";
            Uri baseAddress = new Uri(serviceAddress);
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(TestService), baseAddress);

            var webhttp = new WebHttpBinding(WebHttpSecurityMode.None);
           
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;

            var serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(ITestService), webhttp, serviceAddress);
            foreach (ServiceEndpoint EP in serviceHost.Description.Endpoints)
            {
                EP.Behaviors.Add(new BehaviorAttribute());
            }

            //serviceHost.Authorization.ServiceAuthorizationManager = new RestAuthorizationManager();

            var serviceBehavior = new WebHttpBehavior();
            serviceEndpoint.Behaviors.Add(serviceBehavior);
            //serviceEndpoint.Behaviors.Add(new ServerInterceptor());
            serviceHost.Description.Behaviors.Add(smb);
           
            serviceHost.Open();
        }

       
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
        }
    }
}
