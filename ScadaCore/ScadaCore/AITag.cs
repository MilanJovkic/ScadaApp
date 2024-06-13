using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ScadaCore
{
    [DataContract]
    public class AITag : Tag
    {
        [DataMember]
        public string Driver { get; set; }
        [DataMember]
        public int ScanTime { get; set; }
        [DataMember]
        public List<string> Alarms { get; set; }
        [DataMember]
        public double LowLimit { get; set; }
        [DataMember]
        public double HighLimit { get; set; }
        [DataMember]
        public string Units { get; set; }
        [DataMember]
        public bool ScanOn { get; set; }
        public AITag() { }
    }
}