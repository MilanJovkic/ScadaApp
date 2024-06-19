using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ScadaCore
{
    

    [DataContract]
    public class Alarm
    {
        [DataMember]
        public AlarmType Type { get; set; }

        [DataMember]
        public int Priority { get; set; }

        [DataMember]
        public double Threshold { get; set; }

        [DataMember]
        public string TagName { get; set; }

        public override string ToString()
        {
            return $"Alarm tag: {TagName}, Type: {Type}, Priority: {Priority}, Threshold: {Threshold}";
        }
    }

    public enum AlarmType { low, high };

    [DataContract]
    public class TriggeredAlarm
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        public Alarm Alarm { get; set; }

        [DataMember]
        public DateTime TriggeredAt { get; set; }

        public override string ToString()
        {
            return $"{Alarm}, Activated at: {TriggeredAt}";
        }
    }
}