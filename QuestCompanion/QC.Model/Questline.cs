using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public class Questline
    {
        public Guid UID;
        public string Title { get; set; }
        public Game Game { get; set; }

        public Questline(string title, Game game)
        {
            UID = Guid.NewGuid();
            Title = title;
            Game = game;
        }
    }
}