using System;
using System.Text;
using QuestCompanion.DataAccess;
using QuestCompanion.Model;

namespace QuestCompanion.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Quest quest = new Quest { ID = 1, Title = "Thomas" };

            Password psw = new Password("Alvtron1");
            psw.Print();

            Console.WriteLine(psw.ValidatePassword("Alvtron1"));

            Console.ReadLine();
        }
    }
}