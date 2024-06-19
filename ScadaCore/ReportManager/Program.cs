using ReportManager.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class Program
    {
        static ServiceReference1.ReportManagerServiceClient service;
        static readonly string INPUT_ERROR_MSG = "Invalid input, try again";

        static void Main(string[] args)
        {
            service = new ReportManagerServiceClient();
            while (true)
            {
                String option = WriteMenu();
                switch (option)
                {
                    case "1":
                        DisplayAlarms(service.GetAlarmsWithinPeriod(EnterDateTime("start"), EnterDateTime("end")).ToList());
                        break;
                    case "2":
                        DisplayAlarms(service.GetAlarmsOfPriority(EnterAlarmPriority()).ToList());
                        break;
                    case "3":
                        DisplayTagValues(service.GetLastValuesOfTags(EnterTagType()).ToList());
                        break;
                    case "4":
                        Console.WriteLine("Enter tag name: ");
                        DisplayTagValues(service.GetTagValues(Console.ReadLine()).ToList());
                        break;
                    case "5":
                        DisplayTagValues(service.GetTagValuesWithinPeriod(EnterDateTime("start"), EnterDateTime("end")).ToList());
                        break;
                    case "x":
                        return;
                    default:
                        return;

                }
            }
        }


        static string WriteMenu()
        {
            while (true)
            {
                Console.WriteLine("================= Report manager =================");
                Console.WriteLine("1. Get alarms within specific period");
                Console.WriteLine("2. Get alarms of specific priority");
                Console.WriteLine("3. Get last values of tags");
                Console.WriteLine("4. Get tag values by tag name");
                Console.WriteLine("5. Get tag values within specific period");
                Console.WriteLine("x. Exit");

                Console.WriteLine("Select an option: ");
                string option = Console.ReadLine();
                if (option != "1" && option != "2" && option != "3" && option != "4" && option != "5" && option != "x")
                {
                    continue;
                }
                return option;
            }

        }

        private static void DisplayAlarms(List<TriggeredAlarm> alarms)
        {
            foreach (TriggeredAlarm alarm in alarms)
            {
                Console.WriteLine($"Alarm for {alarm.Alarm.TagName}, Type: {alarm.Alarm.Type}, " +
                    $"Priority: {alarm.Alarm.Priority}, Threshold: {alarm.Alarm.Threshold}, Activated at: {alarm.TriggeredAt}");
            }
        }

        private static void DisplayTagValues(List<TagValue> values)
        {
            foreach (TagValue val in values)
            {
                Console.WriteLine($"{val.TagName}, Tag type: {val.TagType}, Value: {Math.Round(val.Value, 2)}, Arrived at: {val.ArrivedAt}");
            }
            Console.WriteLine("\n\n");
        }

        private static DateTime EnterDateTime(string type)
        {
            var cultureInfo = new CultureInfo("sr-Latn-CS");
            while (true)
            {
                Console.Write($"Enter {type} date and time (dd/MM/yyyy HH:mm) ");
                string input = Console.ReadLine();
                try
                {
                    return DateTime.Parse(input, cultureInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine(INPUT_ERROR_MSG);
                }
            }
        }

        private static int EnterAlarmPriority()
        {
            while (true)
            {
                Console.Write("Enter priority (1/2/3): ");
                string input = Console.ReadLine().Trim();
                if (input == "1" || input == "2" || input == "3")
                {
                    return int.Parse(input);
                }
                Console.WriteLine(INPUT_ERROR_MSG);
            }
        }

        private static string EnterTagType()
        {
            while (true)
            {
                Console.Write("Enter tag type (AITag/DITag): ");
                string input = Console.ReadLine().Trim();
                if (input == "AITag" || input == "DITag")
                {
                    return input;
                }
                Console.WriteLine(INPUT_ERROR_MSG);
            }
        }
    }
}
