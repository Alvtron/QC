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
        public ICollection<Image> Screenshots { get; }
        public ICollection<string> VideoURLS { get; }
        public ICollection<Log> Logs { get; }
        public ICollection<Comment> Comments { get; }

        public Post()
        {
            UID = Guid.NewGuid();
            Screenshots = new HashSet<Image>();
            VideoURLS = new HashSet<string>();
            Logs = new HashSet<Log>();
            Comments = new HashSet<Comment>();
        }
    }
}
