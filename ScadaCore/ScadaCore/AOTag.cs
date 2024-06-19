using System;
using System.Runtime.Serialization;

namespace ScadaCore
{
    [DataContract]
    public class AOTag : Tag
    {
        [DataMember]
        public double InitialValue { get; set; }
        [DataMember]
        public double LowLimit { get; set; }
        [DataMember]
        public double HighLimit { get; set; }
        [DataMember]
        public string Units { get; set; }
        public AOTag() { }
    }
}