using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public static class Action
    {
        public enum Type : int
        {
            ADD_GAME = 1000,
            ADD_WIKI = 200,
            ADD_QUEST = 200,
            ADD_COMMENT = 20,
            ADD_PROFILE_PHOTO = 100,
            EDIT_GAME = 10,
            EDIT_WIKI = 10,
            EDIT_QUEST = 10,
            UPLOAD_IMAGE = 10,
            UPLOAD_VIDEO = 10
        };

        public const int LEVEL_UP_EXP = 5000;

        public static int ExpToLevel(int exp)
        {
            return exp % LEVEL_UP_EXP;
        }

        public static int LevelToExp(int level)
        {
            return level * LEVEL_UP_EXP;
        }
    }
}
