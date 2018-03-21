using System;
using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class User
    {
        private int ID { get; set; }
        private string Firstname { get; set; }
        private string Lastname { get; set; }
        private string password { get; set; }
        private DateTime DateRegistered { get; set; }
        private DateTime DateLastLogin { get; set; }
    }
}
