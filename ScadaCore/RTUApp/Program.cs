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
            string address = "RealTimeDriverAddress";
            RealTimeDrive driver = new RealTimeDriver();

            while (true)
            {
                double value = new Random().NextDouble() * 10;
                driver.WriteValue(address, value);
                Thread.Sleep(1000); // Send data every second
            }
        }
    }
}
