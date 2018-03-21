using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Quest : Post
    {
        public string QuestID { get; set; }
        public Game Game { get; set; }
        public Questline Questline { get; set; }
        public uint QuestlineNR { get; set; }
        public Map Map { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<Step> Steps { get; set; }
    }
}
