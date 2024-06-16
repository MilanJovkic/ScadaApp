using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RTUApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input address of device: ");
            string address = Console.ReadLine();
            while (true)
            {
                double value = new Random().NextDouble() * 100;
                RealTimeDriver.RealTimeDriver.WriteValue(address, value);
                Thread.Sleep(5000);
            }
        }
    }
}
