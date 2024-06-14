using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrendingApp
{
    public class Program
    {
        private static readonly ServiceReference1.TrendingProcessingClient tagProcessingClient = new ServiceReference1.TrendingProcessingClient();
        static void Main(string[] args)
        {
            // every 1 second, get the value of the tag and print it
            while (true)
            {
                Console.Clear();
                Console.WriteLine(tagProcessingClient.GetInputTagValue());
                Thread.Sleep(1000);
            }
        }
    }
}
