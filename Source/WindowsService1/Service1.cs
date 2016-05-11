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
using IOCFactory;
using AutoMapper;
using EntityInterfaces;
using WindowsService1.DataContracts;
using ServiceInterfaces;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private ServiceHost serviceHost1;
        private ServiceHost serviceHost2;
                                                                  
        public Service1()
        {

            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            var serviceAddress1 = "http://localhost:9999/TestService/";
            var serviceAddress2 = "http://localhost:9999/HRMSService/";
            var baseAddress1 = new Uri(serviceAddress1);
            var baseAddress2 = new Uri(serviceAddress2);
            if (serviceHost1 != null)
            {
                serviceHost1.Close();
            }
            if (serviceHost2 != null)
            {
                serviceHost2.Close();
            }

            serviceHost1 = new ServiceHost(typeof(TestService), baseAddress1); 
            serviceHost2 = new ServiceHost(typeof(EmployeeService), baseAddress2);

            //configuration was moved back to the app.config

            //var webhttp = new WebHttpBinding(WebHttpSecurityMode.None);

            //var smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;

            //var serviceEndpoint = serviceHost.AddServiceEndpoint(typeof(ITestService), webhttp, serviceAddress);

            //serviceHost.Authorization.ServiceAuthorizationManager = new RestAuthorizationManager();

            //var serviceBehavior = new WebHttpBehavior();
            //serviceEndpoint.Behaviors.Add(serviceBehavior);
            ////serviceEndpoint.Behaviors.Add(new ServerInterceptor());
            //serviceHost.Description.Behaviors.Add(smb);

            serviceHost1.Open();
            serviceHost2.Open();
        }
       
        protected override void OnStop()
        {
            if (serviceHost1 != null)
            {
                serviceHost1.Close();
            }
            if (serviceHost2 != null)
            {
                serviceHost2.Close();
            }
        }
    }
}
