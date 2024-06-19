using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class TagValue
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public string TagType { get; set; }

        [DataMember]
        public string TagName { get; set; }
        [DataMember]
        public double Value { get; set; }
        [DataMember]
        public DateTime ArrivedAt { get; set; }

        public override string ToString()
        {
            return $"Tag name: {TagName}, Tag type: {TagType}, Value: {Value}, Arrived at: {ArrivedAt}";
        }
    }
}