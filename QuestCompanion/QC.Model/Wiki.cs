using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public class Wiki : Post
    {
        public Game Game { get; set; }
        public ICollection<Map> Maps { get; set; }

        public Wiki() : base()
        {
            Maps = new HashSet<Map>();
        }
    }
}
