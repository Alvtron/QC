using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QC.Model
{
    [ComplexType]
    public class Reward
    {
        public string Type { get; set; }
        public int Amount { get; set; }
    }
}