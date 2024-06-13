using System;
using System.Runtime.Serialization;

namespace ScadaCore
{
    [DataContract]
    public class DITag : Tag
    {
        [DataMember]
        public string Driver { get; set; }
        [DataMember]
        public int ScanTime { get; set; }
        [DataMember]
        public bool ScanOn { get; set; }
        public DITag() { }
    }
}