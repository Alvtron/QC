using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
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

        public Post()
        {
            UID = Guid.NewGuid();
        }
    }
}
