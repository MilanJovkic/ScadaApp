using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScadaCore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlarmDisplayService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IAlarmDisplayCallback))]
    public interface IAlarmDisplayService
    {
        [OperationContract(IsOneWay = true)]
        void InitializeAlarmDisplay();
    }

    public interface IAlarmDisplayCallback
    {
        [OperationContract(IsOneWay = true)]
        void AlarmTriggered(TriggeredAlarm alarm, double value);
    }
}
