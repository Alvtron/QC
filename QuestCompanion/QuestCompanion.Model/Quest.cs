using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Quest
    {
        struct Reward
        {
            private string Type { get; set; }
            private int Amount { get; set; }
        }

        public int ID { get; set; }
        public string Title { get; set; }
        private List<Reward> Rewards { get; set; }
        private UpdateLog UpdateLog { get; set; }
    }
}
