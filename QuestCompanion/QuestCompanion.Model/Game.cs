using System;
using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class Game
    {

        private int ID { get; set; }
        private string Title { get; set; }
        private DateTime DateRelease { get; set; }
        private string About { get; set; }
        private Changelog Changelog { get; set; }
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
