using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace RealTimeDriver
{
    public static class RealTimeDriver
    {
        private static readonly string SolutionDirectory1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");
        private static readonly string FilePath1 = Path.Combine(SolutionDirectory1, "RealTimeDriver", "dataStore.json");
        private static readonly string SolutionDirectory2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..");
        private static readonly string FilePath2 = Path.Combine(SolutionDirectory2, "RealTimeDriver", "dataStore.json");

        private static readonly object FileLock = new object();

        public static void WriteValue(string address, double value)
        {
            lock (FileLock)
            {
                var dataStore = LoadDataStore1();
                dataStore[address] = value;
                SaveDataStore1(dataStore);
            }
        }

        public static double ReadValue(string address)
        {
            lock (FileLock)
            {
                var dataStore = LoadDataStore2();
                if (dataStore.TryGetValue(address, out double value))
                {
                    return value;
                }
                else
                {
                    return double.NaN; // Placeholder for non-existent address
                }
            }
        }

        private static Dictionary<string, double> LoadDataStore1()
        {
            if (!File.Exists(FilePath1))
            {
                return new Dictionary<string, double>();
            }

            var json = File.ReadAllText(FilePath1);
            return JsonConvert.DeserializeObject<Dictionary<string, double>>(json) ?? new Dictionary<string, double>();
        }

        private static void SaveDataStore1(Dictionary<string, double> dataStore)
        {
            var json = JsonConvert.SerializeObject(dataStore);
            File.WriteAllText(FilePath1, json);
        }

        private static Dictionary<string, double> LoadDataStore2()
        {
            if (!File.Exists(FilePath2))
            {
                return new Dictionary<string, double>();
            }

            var json = File.ReadAllText(FilePath2);
            return JsonConvert.DeserializeObject<Dictionary<string, double>>(json) ?? new Dictionary<string, double>();
        }

        private static void SaveDataStore2(Dictionary<string, double> dataStore)
        {
            var json = JsonConvert.SerializeObject(dataStore);
            File.WriteAllText(FilePath2, json);
        }
    }
}