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
            var securityValidator = new CustomUserValidator();
            string serviceAddress = "http://localhost:9999/TestService";
            Uri baseAddress = new Uri(serviceAddress);
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(TestService), baseAddress);
            serviceHost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            serviceHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = securityValidator;

            //var webhttp = new WebHttpBinding(WebHttpSecurityMode.None);
            var webhttp = new WebHttpBinding(WebHttpSecurityMode.TransportCredentialOnly);
            webhttp.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

            var serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(ITestService), webhttp, serviceAddress);
            serviceEndpoint.Behaviors.Add(new WebHttpBehavior());
            //serviceEndpoint.Behaviors.Add(new EnableCrossOriginResourceSharingBehavior());
            //serviceEndpoint.EndpointBehaviors.Add(new EnableCrossOriginResourceSharingBehavior());

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
