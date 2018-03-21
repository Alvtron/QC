using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class Comment
    {
        public uint ID { get; set; }
        public Quest Quest { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public List<Log> Changelog { get; set; }
    }
}
