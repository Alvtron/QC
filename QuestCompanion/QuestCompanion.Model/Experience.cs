using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public static class Experience
    {
        public const uint LEVEL_UP_EXP = 5000;

        public enum Action : uint
        {
            AddGame = 1000,
            AddWiki = 200,
            AddQuest = 200,
            EditGame = 10,
            EditWiki = 10,
            EditQuest = 10,
            UploadMedia = 50,
            Comment = 20
        };

        public static uint ExpToLevel (uint Exp)
        {
            return Exp % LEVEL_UP_EXP;
        }

        public static uint LevelToExp(uint Level)
        {
            return Level * LEVEL_UP_EXP;
        }
    }
}
