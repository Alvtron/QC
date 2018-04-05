using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public class Wiki : Post
    {
        public Game Game { get; set; }
        public List<Map> Maps { get; set; }
    }
}
