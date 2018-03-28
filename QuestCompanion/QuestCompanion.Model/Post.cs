using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Post
    {
        public Guid UID { get; protected set; }
        public string Title { get; set; }
        public string About { get; set; }
        public List<QCImage> Screenshots { get; }
        public List<string> VideoURLS { get; }
        public List<Log> Changelog { get; }
        public List<Comment> Comments { get; }

        public Post(Guid uid, string title, string about, List<QCImage> screenshots, List<string> videoURLS, List<Log> changelog, List<Comment> comments)
        {
            UID = uid;
            Title = title;
            About = about;
            Screenshots = screenshots;
            VideoURLS = videoURLS;
            Changelog = changelog;
            Comments = comments;
        }

        public Post(string title, string about, User user)
        {
            UID = Guid.NewGuid();
            Title = title;
            About = about;
            Changelog.Add(new Log(user, "Post Created"));
        }
    }
}
