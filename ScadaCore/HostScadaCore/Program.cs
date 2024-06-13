using System;
using System.ServiceModel;
using HostScadaCore.ServiceReference1;

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
            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();
            //tagProcessingClient.AddTag(new Tag { Name = tagName });
            Console.WriteLine("Tag added.");
        }

        static void RemoveTag()
        {
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
            tagProcessingClient.SetTagValue(tagName, tagValue);
            Console.WriteLine("Tag value set.");
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
