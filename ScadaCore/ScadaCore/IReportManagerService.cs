using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScadaCore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportManagerService" in both code and config file together.
    [ServiceContract]
    public interface IReportManagerService
    {
        [OperationContract]
        List<TriggeredAlarm> GetAlarmsWithinPeriod(DateTime start, DateTime end);

        [OperationContract]
        List<TriggeredAlarm> GetAlarmsOfPriority(int priority);

        [OperationContract]
        List<TagValue> GetTagValues(string tagName);

        [OperationContract]
        List<TagValue> GetLastValuesOfTags(string type);

        [OperationContract]
        List<TagValue> GetTagValuesWithinPeriod(DateTime start, DateTime end);
    }
}
