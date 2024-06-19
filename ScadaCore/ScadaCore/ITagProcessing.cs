using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCore
{
    [ServiceContract]
    public interface ITagProcessing
    {
        [OperationContract]
        bool AddTag(Tag tag);

        [OperationContract]
        bool RemoveTag(string tagName);

        [OperationContract]
        bool SetTagValue(string tagName, double value);

        [OperationContract]
        double GetTagValue(string tagName);

        [OperationContract]
        bool TurnScanOnOff(string tagName, bool onOff);

        [OperationContract]
        bool AddAlarm(Alarm alarm);
    }
}
