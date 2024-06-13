using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ScadaCore
{
    [DataContract]
    [KnownType(typeof(DITag))]
    [KnownType(typeof(AITag))]
    [KnownType(typeof(DOTag))]
    [KnownType(typeof(AOTag))]
    public class Tag
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string IOAddress { get; set; }
    }
}