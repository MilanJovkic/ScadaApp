using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HostScadaCore
{
    class Program
    {
        private static readonly ServiceReference2.UserProcessingClient userProcessingClient = new ServiceReference2.UserProcessingClient();
        private static readonly ServiceReference2.TagProcessingClient tagProcessingClient = new ServiceReference2.TagProcessingClient();
        static void Main(string[] args)
        {
            Console.WriteLine("SCADA Core Service is running...");
            while (true)
            {
                userProcessingClient.RegisterUser("admin","admin");
                Console.WriteLine(userProcessingClient.Login("admin", "admin"));
            }
        }
    }
}
