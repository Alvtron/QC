using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public class Quest : Post
    {
        public string QuestID { get; set; }
        public Game Game { get; set; }
        public Questline Questline { get; set; }
        public int QuestlineNR { get; set; }
        public Map Map { get; set; }
        public ICollection<Reward> Rewards { get; set; }
        public ICollection<Step> Steps { get; set; }

        public Quest() : base()
        {
            Rewards = new HashSet<Reward>();
            Steps = new HashSet<Step>();
        }
    }
}
