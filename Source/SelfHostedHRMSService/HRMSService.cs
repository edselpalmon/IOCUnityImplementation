using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SelfHostedHRMSService
{
    public class HRMSService
    {
        private IList<ServiceHost> _serviceHostList;

        public HRMSService()
        { }

        public void Start()
        {
            _serviceHostList = new List<ServiceHost>();
            _serviceHostList.Add(new ServiceHost(typeof(TestService)));// new Uri("https://localhost:9990/TestService/")));
            _serviceHostList.Add(new ServiceHost(typeof(EmployeeService)));// new Uri("https://localhost:9990/HRMSService/")));

            //open the ServiceHosts
            foreach (var serviceHost in _serviceHostList)
            {
                serviceHost.Open();
            }
        }

        public void Stop()
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
