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
        

        public string GetInputTagValue()
        {
            SCADACoreService.tags = XmlSerializationHelper.DeserializeTagsFromXml(DBManager.FilePathTags);
            var dict = DBManager.GetLatestTagValues();
            foreach (var tag in SCADACoreService.tags)
            {
                if (tag.Value is AITag aiTag)
                {
                    if (aiTag.ScanOn)
                    {

                        double value = RealTimeDriver.RealTimeDriver.ReadValue(aiTag.IOAddress);
                        if (!dict.ContainsKey(tag.Key) || value != dict[tag.Key].Value)
                        {
                            TagValue tagValue = DBManager.SaveTagValueToDB(tag.Value, value);
                            dict[tag.Key] = tagValue;
                            foreach (Alarm alarm in aiTag.Alarms)
                            {
                                if ((alarm.Type == AlarmType.high && value > alarm.Threshold) || (alarm.Type == AlarmType.low && value < alarm.Threshold))
                                {
                                    DBManager.AddActivatedAlarm(new TriggeredAlarm { Id = DBManager.activatedAlarms.Count, Alarm = alarm, TriggeredAt = DateTime.Now }, value);
                                }
                            }
                        }                                            
                    }
                }
                else if (tag.Value is DITag diTag)
                {
                    if (diTag.ScanOn)
                    {
                        double value = RealTimeDriver.RealTimeDriver.ReadValue(diTag.IOAddress);
                        if (!dict.ContainsKey(tag.Key) || value != dict[tag.Key].Value)
                        {
                            TagValue tagValue = DBManager.SaveTagValueToDB(tag.Value, value);
                            dict[tag.Key] = tagValue;
                            DBManager.SaveTagValueToDB(tag.Value, value);
                        }
                           
                    }
                }
            }
            return GenerateTable(dict);
        }
        private string GenerateTable(Dictionary<string, TagValue> data)
        {
            // Initialize the resulting string
            string result = "\nName\tValue\n";
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
                    result += $"{item.Key}\t{item.Value.Value.ToString()}\n";
                }
            }
           File.WriteAllText(DBManager.FilePathInputTagValues, result);

            return result;
        }

        
    }
}
