﻿using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.ServiceModel;

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
            _serviceHostList.Add(new ServiceHost(typeof(TestService), new Uri("https://localhost:9990/TestService/")));
            _serviceHostList.Add(new ServiceHost(typeof(EmployeeService), new Uri("https://localhost:9990/HRMSService/")));

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
