using System;
using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class Game : Post
    {
        public QCImage CoverArt { get; set; }
        public string TrailerURL { get; set; }
        public DateTime Release { get; set; }
        public List<Quest> Quests { get; set; }
        public List<Wiki> Wikis { get; set; }

        public Game(string title, string about, User user, QCImage coverArt, DateTime release, string trailerUrl = null) : base(title, about, user)
        {

        }
    }
}
