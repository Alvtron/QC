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

        private int ID { get; set; }
        private string Title { get; set; }
        private List<Reward> Rewards { get; set; }
        private UpdateLog UpdateLog { get; set; }
    }
}
