using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AlarmDisplay
{
    class AlarmDisplayCallback : ServiceReference1.IAlarmDisplayServiceCallback
    {
        private readonly object consoleLock = new object();

        public void AlarmTriggered(ServiceReference1.TriggeredAlarm alarm, double value)
        {
            lock (consoleLock)
            {
                for (int i = 0; i < alarm.Alarm.Priority; i++)
                {
                    Console.WriteLine($"Alarm for: {alarm.Alarm.TagName}, Threshold: {alarm.Alarm.Threshold}, " +
                        $"Priority: {alarm.Alarm.Priority}, Triggered at: {alarm.TriggeredAt}, For: {Math.Round(value, 2)}");
                }
            }
        }
    }
    class Program
    {
        static ServiceReference1.AlarmDisplayServiceClient proxy;

        static void Main(string[] args)
        {
            InstanceContext ic = new InstanceContext(new AlarmDisplayCallback());
            proxy = new ServiceReference1.AlarmDisplayServiceClient(ic);
            proxy.InitializeAlarmDisplay();
            Console.ReadKey();
        }
    }
}
