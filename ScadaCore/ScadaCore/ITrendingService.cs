using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScadaCore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITrendingService" in both code and config file together.
    [ServiceContract]
    internal interface ITrendingProcessing
    {
        [OperationContract]
        string GetInputTagValue();
    }
}
