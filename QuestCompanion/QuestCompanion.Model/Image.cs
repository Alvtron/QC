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
        public int ID { get; set; }
        public byte[] ImageInBytes { get; set; }

        public Image(string path)
        {
            ImageInBytes = File.ReadAllBytes(path);
        }
    }
}
