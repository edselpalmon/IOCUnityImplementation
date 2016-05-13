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
        private IList<ServiceHost> _serviceHostList;
        //private ServiceHost serviceHost2;
                                                                  
        public Service1()
        {

            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            _serviceHostList = new List<ServiceHost>();
            _serviceHostList.Add(new ServiceHost(typeof(TestService), new Uri("https://localhost:9999/TestService/")));
            _serviceHostList.Add(new ServiceHost(typeof(EmployeeService), new Uri("https://localhost:9999/HRMSService/")));

            //open the ServiceHosts
            foreach (var serviceHost in _serviceHostList)
            {
                serviceHost.Open();
            }
        }
       
        protected override void OnStop()
        {
            //close the ServiceHosts
            foreach (var serviceHost in _serviceHostList)
            {
                if (serviceHost.State == CommunicationState.Opened)
                {
                    serviceHost.Close();
                }
            }
        }
    }
}
