using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Quest : Post
    {
        public string QuestID { get; set; }
        public Game Game { get; set; }
        public Questline Questline { get; set; }
        public int QuestlineNR { get; set; }
        public Map Map { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<Step> Steps { get; set; }

        public Quest(Guid uid, string title, string about, string questID, Game game, Questline questline, int questlineNR, Map map, List<Reward> rewards, List<Step> steps, List<QCImage> screenshots, List<string> videoURLS, List<Log> changelog, List<Comment> comments) : base(uid, title, about, screenshots, videoURLS, changelog, comments)
        {
            QuestID = questID;
            Game = game;
            Questline = questline;
            QuestlineNR = questlineNR;
            Map = map;
            Rewards = rewards;
            Steps = steps;
        }

        public Quest(string title, string about, Game game, User user, List<Step> steps) : base(title, about, user)
        {
            UID = Guid.NewGuid();

        }
    }
}
