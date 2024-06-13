using System;
using System.ServiceModel;
using HostScadaCore.ServiceReference2;
using ScadaCore;

namespace HostScadaCore
{
    class Program
    {
        private static readonly ServiceReference2.UserProcessingClient userProcessingClient = new ServiceReference2.UserProcessingClient();
        private static readonly ServiceReference2.TagProcessingClient tagProcessingClient = new ServiceReference2.TagProcessingClient();
        private static bool isLoggedIn = false;
        private static string loggedInUser = string.Empty;

        static void Main(string[] args)
        {
            Console.WriteLine("SCADA Core Service is running...");

            while (true)
            {
                if (!isLoggedIn)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to SCADA System");
                    Console.WriteLine("1. Register User");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");

                    Console.Write("Select an option: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            RegisterUser();
                            break;
                        case "2":
                            Login();
                            break;
                        case "3":
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    ShowMainMenu();
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void RegisterUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            bool isRegistered = userProcessingClient.RegisterUser(username, password);
            if (isRegistered)
            {
                Console.WriteLine("User registered.");
            }
            else {
                Console.WriteLine("Username already exist");
            }
        }

        static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            bool success = userProcessingClient.Login(username, password);
            if (success)
            {
                isLoggedIn = true;
                loggedInUser = username;
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Login failed. Please try again.");
            }
        }

        static void Logout()
        {
            userProcessingClient.Logout(loggedInUser);
            isLoggedIn = false;
            loggedInUser = string.Empty;
            Console.WriteLine("User logged out.");
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("SCADA System Menu:");
            Console.WriteLine("1. Add Tag");
            Console.WriteLine("2. Remove Tag");
            Console.WriteLine("3. Set Tag Value");
            Console.WriteLine("4. Get Tag Value");
            Console.WriteLine("5. Turn Scan On/Off");
            Console.WriteLine("6. Logout");
            Console.WriteLine("7. Exit");

            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddTag();
                    break;
                case "2":
                    RemoveTag();
                    break;
                case "3":
                    SetTagValue();
                    break;
                case "4":
                    GetTagValue();
                    break;
                case "5":
                    TurnScanOnOff();
                    break;
                case "6":
                    Logout();
                    break;
                case "7":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        static void AddTag()
        {
            Console.WriteLine("Select Tag Type:");
            Console.WriteLine("1. Digital Input (DI)");
            Console.WriteLine("2. Digital Output (DO)");
            Console.WriteLine("3. Analog Input (AI)");
            Console.WriteLine("4. Analog Output (AO)");

            string tagType = Console.ReadLine();
            Tag newTag = null;
            switch (tagType)
            {
                case "1":
                    newTag = CreateDITag();
                    break;
                case "2":
                    newTag = CreateDOTag();
                    break;
                case "3":
                    newTag = CreateAITag();
                    break;
                case "4":
                    newTag = CreateAOTag();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            SetTagFields(newTag);
            tagProcessingClient.AddTag(newTag);
            Console.WriteLine("Tag added.");   
        }

        private static AOTag CreateAOTag()
        {
            Console.Write("Enter initial value: ");
            double initialValue = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Low Limit: ");
            double lowLimit = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter High Limit: ");
            double highLimit = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Units: ");
            string units = Console.ReadLine();
            return new AOTag { InitialValue = initialValue, LowLimit = lowLimit, HighLimit = highLimit, Units = units };
        }

        private static AITag CreateAITag()
        {
            Console.Write("Enter Driver Name: ");
            string driver = Console.ReadLine();
            int scanTime = 0;
            Console.WriteLine("Enter Low Limit: ");
            double lowLimit = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter High Limit: ");
            double highLimit = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Units: ");
            string units = Console.ReadLine();

            // TODO: Implement Alarms
            return new AITag { Driver = driver, ScanTime = scanTime, LowLimit = lowLimit, HighLimit = highLimit, Units = units , ScanOn = false};
        }

        private static DOTag CreateDOTag()
        {
            Console.Write("Enter initial value: ");
            double initialValue = double.Parse(Console.ReadLine());
            return new DOTag { InitialValue = initialValue };
        }

        private static DITag CreateDITag()
        {
            Console.Write("Enter Driver Name: ");
            string driver = Console.ReadLine();
            int scanTime = 0;
            return new DITag { Driver = driver, ScanTime = scanTime, ScanOn = false };
        }

        private static void SetTagFields(Tag newTag)
        {
            Console.Write("Enter Tag Name (ID): ");
            newTag.Name = Console.ReadLine();

            Console.Write("Enter Description: ");
            newTag.Description = Console.ReadLine();

            Console.Write("Enter I/O Address: ");
            newTag.IOAddress = Console.ReadLine();
        }

        static void RemoveTag()
        {
            //Console.Write(tagProcessingClient.GetInputTagValue());
            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();
            tagProcessingClient.RemoveTag(tagName);
            Console.WriteLine("Tag removed.");
        }

        static void SetTagValue()
        {
            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();
            Console.Write("Enter tag value: ");
            double tagValue = double.Parse(Console.ReadLine());
            bool succestag = tagProcessingClient.SetTagValue(tagName, tagValue);
            if (succestag)
            {
                Console.WriteLine("Tag value set.");
            }
            else
            {
                Console.WriteLine("Failed to set tag value.");
            }
        }

        static void GetTagValue()
        {
            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();
            double value = tagProcessingClient.GetTagValue(tagName);
            Console.WriteLine($"Tag value: {value}");
        }

        static void TurnScanOnOff()
        {
            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();
            Console.Write("Turn scan on (true/false): ");
            bool scanOn = bool.Parse(Console.ReadLine());
            tagProcessingClient.TurnScanOnOff(tagName, scanOn);
            Console.WriteLine("Scan status changed.");
        }
    }
}
