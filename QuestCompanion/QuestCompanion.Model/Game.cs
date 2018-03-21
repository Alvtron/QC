using System;
using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class Game : Post
    {

        public Byte[] CoverArt { get; set; }
        public string TrailerURL { get; set; }
        public DateTime Release { get; set; }
        public List<Quest> Quests { get; set; }
        public List<Wiki> Wikis { get; set; }

        // Default constructor.
        public Game() { }
    }
}
