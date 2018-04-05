using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QC.Model
{
    [ComplexType]
    public class Step
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string About { get; set; }
        public Byte[] Screenshot { get; set; }
        public Map Map { get; set; }
    }
}