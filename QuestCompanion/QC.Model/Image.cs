using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace QC.Model
{
    public class Image
    {
        [Key]
        public Guid UID { get; set; }
        [Required]
        public byte[] ImageInBytes { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Uploaded { get; private set; }

        public Image(byte[] imageInBytes, string description = null)
        {
            UID = Guid.NewGuid();
            ImageInBytes = imageInBytes;
            Description = description;
            Uploaded = DateTime.Now;
        }
    }
}
