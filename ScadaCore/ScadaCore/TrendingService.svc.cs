using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScadaCore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TrendingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TrendingService.svc or TrendingService.svc.cs at the Solution Explorer and start debugging.
    public class TrendingService : ITrendingProcessing
    {
        private static readonly string SolutionDirectory1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..");
        private static readonly string FilePathValues = Path.Combine(SolutionDirectory1, "inputTagsValues.txt");
        public string GetInputTagValue()
        {
            SCADACoreService.tags = XmlSerializationHelper.DeserializeTagsFromXml(SCADACoreService.FilePath1);
            var dict = new Dictionary<string, object>();
            foreach (var tag in SCADACoreService.tags)
            {
                if (tag.Value is AITag aiTag)
                {
                    if (aiTag.ScanOn)
                    {
                        dict[tag.Key] = RealTimeDriver.RealTimeDriver.ReadValue(aiTag.IOAddress);
                    }
                }
                else if (tag.Value is DITag diTag)
                {
                    if (diTag.ScanOn)
                    {
                        dict[tag.Key] = RealTimeDriver.RealTimeDriver.ReadValue(diTag.IOAddress);
                    }
                }
            }
            return GenerateTable(dict);
        }
        private string GenerateTable(Dictionary<string, object> data)
        {
            // Initialize the resulting string
            string result = "Name\tValue\n";
            result += "------------------------\n";

            // Iterate through all key-value pairs in the dictionary
            foreach (var item in data)
            {
                // if item value NaN string is no device on the field
                if (item.Value.ToString() == "NaN")
                {
                    result += $"{item.Key}\tNo device on the field\n";
                }
                else
                {
                    result += $"{item.Key}\t{item.Value.ToString()}\n";
                }
            }

            File.AppendAllText(FilePathValues, result);

            return result;
        }
    }
}
