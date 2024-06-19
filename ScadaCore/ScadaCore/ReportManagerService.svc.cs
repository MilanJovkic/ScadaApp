using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScadaCore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportManagerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportManagerService.svc or ReportManagerService.svc.cs at the Solution Explorer and start debugging.
    public class ReportManagerService : IReportManagerService
    {
        private static readonly int MAX_NUMBER = 30;
        public List<TriggeredAlarm> GetAlarmsOfPriority(int priority)
        {
            List<TriggeredAlarm> allActivatedAlarms = DBManager.GetAllAlarmValues();
            return allActivatedAlarms
                .Where(alarm => alarm.Alarm.Priority == priority)
                .OrderBy(alarm => alarm.TriggeredAt)
                .ToList();
        }

        public List<TriggeredAlarm> GetAlarmsWithinPeriod(DateTime start, DateTime end)
        {
            List<TriggeredAlarm> allActivatedAlarms = DBManager.GetAllAlarmValues();
            return allActivatedAlarms
                .Where(alarm => alarm.TriggeredAt >= start && alarm.TriggeredAt <= end)
                .OrderBy(alarm => alarm.TriggeredAt)
                .ToList();
        }

        public List<TagValue> GetLastValuesOfTags(string type)
        {
            return DBManager.GetLatestTagValuesOfType(type);
        }

        public List<TagValue> GetTagValues(string tagName)
        {
            List<TagValue> allTagValues = DBManager.GetAllTagValues();
            return allTagValues
                .Where(tagValue => tagValue.TagName == tagName)
                .OrderByDescending(tagValue => tagValue.Value)
                .ToList();
        }

        public List<TagValue> GetTagValuesWithinPeriod(DateTime start, DateTime end)
        {
            List<TagValue> allTagValues = DBManager.GetAllTagValues();
            return allTagValues
                .Where(tagValue => tagValue.ArrivedAt >= start && tagValue.ArrivedAt <= end)
                .OrderBy(tagValue => tagValue.ArrivedAt)
                .ToList();
        }

    }
}
