using System;
using QuestCompanion.DataAccess;
using QuestCompanion.Model;

namespace QuestCompanion.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Context();

            Quest quest = new Quest { ID = 0001, Title = "Thomas" };

            db.Quests.Add(quest);
           
            db.SaveChanges();
        }
    }
}
