using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QC.Model
{
    public class Questline
    {
        [Key]
        public Guid UID;
        [Required]
        public string Title { get; set; }
        [Required]
        public Game Game { get; set; }

        public Questline()
        {
            UID = Guid.NewGuid();
        }

        public Questline(string title, Game game)
        {
            UID = Guid.NewGuid();
            Title = title;
            Game = game;
        }
    }
}