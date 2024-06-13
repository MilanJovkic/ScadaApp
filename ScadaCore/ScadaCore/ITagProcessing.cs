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
        void AddTag(Tag tag);

        [OperationContract]
        void RemoveTag(string tagName);

        [OperationContract]
        bool SetTagValue(string tagName, double value);

        [OperationContract]
        double GetTagValue(string tagName);

        [OperationContract]
        void TurnScanOnOff(string tagName, bool onOff);

        [OperationContract]
        string GetInputTagValue();
        
    }
}
