using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ScadaCore
{
    public static class DBManager
    {
        public static readonly string SolutionDirectory1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..");
        public static readonly string FilePathInputTagValues = Path.Combine(SolutionDirectory1, "inputTagsValues.txt");
        public static readonly string FilePathTriggeredAlarmValues = Path.Combine(SolutionDirectory1, "alarmsLog.txt");
        public static readonly string FilePathTags = Path.Combine(SolutionDirectory1, "tags.xml");
        public static readonly string FilePathOutputTagValues = Path.Combine(SolutionDirectory1, "outputTagsValues.txt");

        static readonly object tagValuesDBLock = new object();
        static readonly object alarmsDBLock = new object();
        static readonly object activatedAlarmsLock = new object();
        static readonly object alarmsLogLock = new object();
        public static List<TriggeredAlarm> activatedAlarms = new List<TriggeredAlarm>();
        public delegate void AlarmTriggeredDelegate(TriggeredAlarm alarm, double value);
        public static event AlarmTriggeredDelegate OnAlarmTriggered;

        public static TagValue SaveTagValueToDB(Tag tag, double value)
        {
            lock (tagValuesDBLock)
            {

                using (var db = new TagContext())
                {
                    TagValue tagValue = new TagValue
                    {
                        Id = db.TagValues.Count(),
                        TagType = tag.GetType().Name,
                        TagName = tag.Name,
                        Value = value,
                        ArrivedAt = DateTime.Now
                    };
                    db.TagValues.Add(tagValue);
                    db.SaveChanges();
                    return tagValue;
                }
            }
        }

        private static void SaveAlarmToDB(TriggeredAlarm activatedAlarm)
        {
            lock (alarmsDBLock)
            {
                using (var db = new AlarmsContext())
                {
                    db.TriggeredAlarms.Add(activatedAlarm);
                    db.SaveChanges();
                }
            }
        }

        public static List<TagValue> GetAllTagValues()
        {
            lock (tagValuesDBLock)
            {
                using (var db = new TagContext())
                {
                    return db.TagValues.ToList();
                }
            }
        }

        public static Dictionary<string, TagValue> GetLatestTagValues()
        {
            lock (tagValuesDBLock)
            {
                using (var db = new TagContext())
                {
                    // Get all tag values from the database
                    var allTagValues = db.TagValues.ToList();

                    // Create a dictionary to store the latest TagValue for each TagName
                    var latestTagValues = new Dictionary<string, TagValue>();

                    // Iterate over all tag values
                    foreach (var tagValue in allTagValues)
                    {

                        // If the dictionary already contains the TagName
                        if (latestTagValues.ContainsKey(tagValue.TagName))
                        {
                            // Compare the ArrivedAt time and update if the current tagValue is newer
                            if (tagValue.ArrivedAt > latestTagValues[tagValue.TagName].ArrivedAt)
                            {
                                latestTagValues[tagValue.TagName] = tagValue;
                            }
                        }
                        else
                        {
                            // If the TagName is not in the dictionary, add it
                            latestTagValues[tagValue.TagName] = tagValue;
                        }
                        
                        
                    }

                    return latestTagValues;
                }
            }
        }

        public static List<TagValue> GetLatestTagValuesOfType(string type)
        {
            lock (tagValuesDBLock)
            {
                using (var db = new TagContext())
                {
                    // Get all tag values from the database
                    var allTagValues = db.TagValues.ToList();

                    // Create a dictionary to store the latest TagValue for each TagName
                    var latestTagValues = new Dictionary<string, TagValue>();

                    // Iterate over all tag values
                    foreach (var tagValue in allTagValues)
                    {
                        if (tagValue.TagType == type)
                        {
                            // If the dictionary already contains the TagName
                            if (latestTagValues.ContainsKey(tagValue.TagName))
                            {
                                // Compare the ArrivedAt time and update if the current tagValue is newer
                                if (tagValue.ArrivedAt > latestTagValues[tagValue.TagName].ArrivedAt)
                                {
                                    latestTagValues[tagValue.TagName] = tagValue;
                                }
                            }
                            else
                            {
                                // If the TagName is not in the dictionary, add it
                                latestTagValues[tagValue.TagName] = tagValue;
                            }
                        }

                    }

                    return latestTagValues.Values.ToList();
                }
            }
        }


        public static void RemoveTagFromDB(string tagName)
        {
            lock (tagValuesDBLock)
            {
                using (var db = new TagContext())
                {
                    foreach (TagValue tv in db.TagValues)
                    {
                        if (tv.TagName == tagName)
                        {
                            db.TagValues.Remove(tv);
                        }
                    }
                    db.SaveChanges();
                }
            }
            lock (alarmsDBLock)
            {
                using (var db = new AlarmsContext())
                {
                    foreach (TriggeredAlarm alarm in db.TriggeredAlarms)
                    {
                        if (alarm.Alarm.TagName == tagName)
                        {
                            db.TriggeredAlarms.Remove(alarm);
                        }
                    }
                    db.SaveChanges();
                }
            }
        }

        public static List<TriggeredAlarm> GetAllAlarmValues()
        {
            lock (alarmsDBLock)
            {
                using (var db = new AlarmsContext())
                {
                    return db.TriggeredAlarms.ToList();
                }
            }
        }

        public static void AddActivatedAlarm(TriggeredAlarm activatedAlarm, double value)
        {
            if (activatedAlarms.Count > 0)
            {
                foreach (TriggeredAlarm existing in activatedAlarms)
                {
                    var diffSeconds = (activatedAlarm.TriggeredAt - existing.TriggeredAt).TotalSeconds;
                    if (existing.Alarm.TagName == activatedAlarm.Alarm.TagName && existing.Alarm.Type == activatedAlarm.Alarm.Type && diffSeconds < 3) return;
                }
            }
            //TODO: proveri sto ima 3 alarma na konzoli

            
            OnAlarmTriggered?.Invoke(activatedAlarm, value);
            lock (activatedAlarmsLock)
            {
                activatedAlarms.Add(activatedAlarm);
            }
            lock (alarmsLogLock)
            {
                using (StreamWriter writer = File.AppendText(FilePathTriggeredAlarmValues))
                {
                    writer.WriteLine(activatedAlarm.ToString());
                }
            }
            SaveAlarmToDB(activatedAlarm);
        }

    }
}