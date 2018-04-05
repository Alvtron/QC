using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QC.Model
{
    public class QCImage
    {
        public Guid UID { get; set; }
        public byte[] ImageInBytes { get; set; }
        public string Description { get; set; }
        public DateTime Uploaded { get; private set; }

        public QCImage(byte[] imageInBytes, string description = null)
        {
            ImageInBytes = imageInBytes;
            Description = description;
            Uploaded = DateTime.Now;
        }
    }
}
