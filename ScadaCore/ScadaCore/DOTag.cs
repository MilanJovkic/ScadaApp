using System;
using System.Runtime.Serialization;

namespace ScadaCore
{
    [DataContract]
    public class DOTag : Tag
    {
        [DataMember]
        public double InitialValue { get; set; }
        public DOTag() { }
    }
}