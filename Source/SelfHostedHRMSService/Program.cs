using System;
using Topshelf;

namespace SelfHostedHRMSService
{
    class Program
    {
        static void Main(string[] args)
        {

            var exitcode = HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<HRMSService>(
                    serviceConfigurator =>
                    {
                        serviceConfigurator.ConstructUsing(() => new HRMSService());
                        serviceConfigurator.WhenStarted(myService => myService.Start());
                        serviceConfigurator.WhenStopped(myService => myService.Stop());
                    });

                hostConfigurator.RunAsLocalSystem();
                hostConfigurator.StartAutomatically();

                hostConfigurator.SetDisplayName("HRMS WCF Service");
                hostConfigurator.SetDescription("HRMS WCFS Service");
                hostConfigurator.SetServiceName("HRMSWCFService");
                hostConfigurator.EnableServiceRecovery(x => x.RestartService(1));
            });

            Console.WriteLine("Topshelf install/uninstall process exiting on code: " + exitcode);

        }
    }
}
