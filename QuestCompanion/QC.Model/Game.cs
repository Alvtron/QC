using System;
using System.Collections.Generic;

namespace QC.Model
{
    public class Game : Post
    {
        public Image CoverArt { get; set; }
        public string TrailerURL { get; set; }
        public DateTime Release { get; set; }
        public ICollection<Quest> Quests { get; set; }
        public ICollection<Wiki> Wikis { get; set; }

        public Game() : base()
        {
            Quests = new HashSet<Quest>();
            Wikis = new HashSet<Wiki>();
        }
    }
}
