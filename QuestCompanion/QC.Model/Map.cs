using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public class Map : Image
    {
        public List<Coordinate> Coordinates { get; set; }

        public Map(byte[] imageInBytes, string description = null, List<Coordinate> coordinates = null)
            : base(imageInBytes, description)
        {
            Coordinates = coordinates;
        }
    }
}
