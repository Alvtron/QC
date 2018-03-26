using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace QuestCompanion.Model
{
    public class Image
    {
        public Guid UID { get; set; }
        public byte[] ImageInBytes { get; set; }
        public string Description { get; set; }
        public DateTime Uploaded { get; set; }

        public Image(string path, string description = null)
        {
            UID = Guid.NewGuid();
            ImageInBytes = File.ReadAllBytes(path);
            Description = description;
            Uploaded = DateTime.Now;
        }
    }
}
