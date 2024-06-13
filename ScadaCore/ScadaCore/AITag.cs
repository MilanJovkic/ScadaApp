using System;
using System.Collections.Generic;

namespace ScadaCore
{
    [Serializable]
    public class AITag : Tag
    {
        public string Driver { get; set; }
        public int ScanTime { get; set; }
        public List<string> Alarms { get; set; }
        public double LowLimit { get; set; }
        public double HighLimit { get; set; }
        public string Units { get; set; }
    }
}