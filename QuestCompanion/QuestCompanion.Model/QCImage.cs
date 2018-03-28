using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace QuestCompanion.Model
{
    public class QCImage
    {
        public Guid UID { get; set; }
        public byte[] ImageInBytes { get; set; }
        public string Description { get; set; }
        public DateTime Uploaded { get; private set; }

        public QCImage(Guid uid, byte[] imageInBytes, string description, DateTime uploaded)
        {
            UID = uid;
            ImageInBytes = imageInBytes;
            Description = description;
            Uploaded = uploaded;
        }

        public QCImage(byte[] imageInBytes, string description = null)
        {
            UID = uID;
            ImageInBytes = imageInBytes;
            Description = description;
            Uploaded = DateTime.Now;
        }
    }
}
