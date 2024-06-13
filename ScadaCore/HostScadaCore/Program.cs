using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HostScadaCore.ServiceReference1;

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
                Console.Clear();
                Console.WriteLine("SCADA System Menu:");
                Console.WriteLine("1. Add Tag");
                Console.WriteLine("2. Remove Tag");
                Console.WriteLine("3. Set Tag Value");
                Console.WriteLine("4. Get Tag Value");
                Console.WriteLine("5. Turn Scan On/Off");
                Console.WriteLine("6. Register User");
                Console.WriteLine("7. Login");
                Console.WriteLine("8. Logout");
                Console.WriteLine("9. Exit");

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter tag name: ");
                        string tagName = Console.ReadLine();
                        //tagProcessingClient.AddTag(new Tag { Name = tagName });
                        Console.WriteLine("Tag added.");
                        break;
                    case "2":
                        Console.Write("Enter tag name: ");
                        tagName = Console.ReadLine();
                        tagProcessingClient.RemoveTag(tagName);
                        Console.WriteLine("Tag removed.");
                        break;
                    case "3":
                        Console.Write("Enter tag name: ");
                        tagName = Console.ReadLine();
                        Console.Write("Enter tag value: ");
                        double tagValue = double.Parse(Console.ReadLine());
                        tagProcessingClient.SetTagValue(tagName, tagValue);
                        Console.WriteLine("Tag value set.");
                        break;
                    case "4":
                        Console.Write("Enter tag name: ");
                        tagName = Console.ReadLine();
                        double value = tagProcessingClient.GetTagValue(tagName);
                        Console.WriteLine($"Tag value: {value}");
                        break;
                    case "5":
                        Console.Write("Enter tag name: ");
                        tagName = Console.ReadLine();
                        Console.Write("Turn scan on (true/false): ");
                        bool scanOn = bool.Parse(Console.ReadLine());
                        tagProcessingClient.TurnScanOnOff(tagName, scanOn);
                        Console.WriteLine("Scan status changed.");
                        break;
                    case "6":
                        Console.Write("Enter username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        userProcessingClient.RegisterUser(username, password);
                        Console.WriteLine("User registered.");
                        break;
                    case "7":
                        Console.Write("Enter username: ");
                        username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = Console.ReadLine();
                        bool loggedIn = userProcessingClient.Login(username, password);
                        Console.WriteLine(loggedIn ? "Login successful." : "Login failed.");
                        break;
                    case "8":
                        Console.Write("Enter username: ");
                        username = Console.ReadLine();
                        userProcessingClient.Logout(username);
                        Console.WriteLine("User logged out.");
                        break;
                    case "9":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        // close the connection
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
