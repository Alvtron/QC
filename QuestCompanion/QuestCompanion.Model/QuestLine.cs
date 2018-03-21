using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class QuestLine
    {
        public List<Quest> Quests { get; private set; }
        public Changelog Changelog { get; private set; }

        public QuestLine()
        {

        }
    }
}
