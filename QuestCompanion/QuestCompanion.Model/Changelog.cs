using System;
using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class Changelog
    {
        private DateTime DateTime { get; set; }
        private User User { get; set; }
        private string Info { set; get; }
    }
}