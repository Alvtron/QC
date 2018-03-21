using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Log
    {
        public int ID { get; set; }
        public String Type { get; set; }
        public User User { get; set; }
        public String Information { get; set; }
        public DateTime Date { get; set; }
    }
}
