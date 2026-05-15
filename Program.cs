using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NewFileMonitoringService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                NewFileMonitoringService service = new NewFileMonitoringService();
                service.StartInConsole();

            }




            else {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new NewFileMonitoringService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        } }
}
