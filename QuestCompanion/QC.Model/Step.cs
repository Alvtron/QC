using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public class Step
    {
        public string Title { get; set; }
        public string About { get; set; }
        public Byte[] Screenshot { get; set; }
        public Map Map { get; set; }
    }
}