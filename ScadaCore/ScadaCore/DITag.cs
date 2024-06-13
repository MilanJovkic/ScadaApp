using System;

namespace ScadaCore
{
    [Serializable]
    public class DITag : Tag
    {
        public string Driver { get; set; }
        public int ScanTime { get; set; }
    }
}