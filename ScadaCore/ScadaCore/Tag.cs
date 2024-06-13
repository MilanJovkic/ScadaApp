using System;
using System.Collections.Generic;

namespace ScadaCore
{
    [Serializable]
    public class Tag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IOAddress { get; set; }
        public bool ScanOn { get; set; }
    }
}