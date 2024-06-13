using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScadaCore
{
    [Serializable]
    public class Tag
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public bool ScanOn { get; set; }
    }
}