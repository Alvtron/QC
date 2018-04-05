using System;
using System.Collections.Generic;

namespace QC.Model
{
    public class Game : Post
    {
        public QCImage CoverArt { get; set; }
        public string TrailerURL { get; set; }
        public DateTime Release { get; set; }
        public List<Quest> Quests { get; set; }
        public List<Wiki> Wikis { get; set; }
    }
}
