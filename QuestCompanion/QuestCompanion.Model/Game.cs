using System;
using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class Game
    {

        private int ID { get; set; }
        private string Title { get; set; }
        private DateTime DateRelease { get; set; }
        private string Information { get; set; }
        private UpdateLog UpdateLog { get; set; }
        private List<QuestLine> Quest { get; set; }

        // Default constructor.
        public Game()
        {
            Title = "unknown";
        }

        // Constructor that takes one argument.
        public Game(string title)
        {
            Title = title;
        }
    }
}
