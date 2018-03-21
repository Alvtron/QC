using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Quest
    {
        public struct Reward
        {
            public string Type { get; set; }
            public int Amount { get; set; }
        }

        public int ID { get; set; }
        public string QuestID { get; set; }
        public string Title { get; set; }
        public List<Reward> Rewards { get; private set; }
        public Changelog Changelog { get; private set; }

        public Quest()
        {
        }
    }
}
