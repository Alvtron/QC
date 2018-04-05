using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QC.Model
{
    [ComplexType]
    public class Reward
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}