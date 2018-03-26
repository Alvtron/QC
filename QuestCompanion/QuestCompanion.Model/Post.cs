using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Post
    {
        public Guid UID { get; }
        public string Title { get; set; }
        public string About { get; set; }
        public List<Image> Screenshots { get; }
        public List<string> VideoURLS { get; }
        public List<Log> Changelog { get; }
        public List<Comment> Comments { get; }

        public Post(string title, string about, User user, string info = null)
        {
            UID = Guid.NewGuid();
            Title = title;
            About = about;
            Changelog.Add(new Log(user, "Post Created", info));
        }
    }
}
