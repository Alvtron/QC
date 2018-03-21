using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Post
    {
        public uint ID { get; set; }
        public string Title { get; set; }
        public List<Byte[]> Screenshots { get; set; }
        public List<string> VideoURLS { get; set; }
        public string About { get; set; }
        public List<Log> Changelog { get; set; }
        public List<Comment> Comments { get; set; }

        public Post() { }
    }
}
