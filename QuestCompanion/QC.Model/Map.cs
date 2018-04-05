using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public class Map
    {
        public QCImage Image { get; set; }
        public List<Coordinate> Coordinates { get; set; }

        public void AddCoordinate(Coordinate Coordinate)
        {
            Coordinates.Add(Coordinate);
        }
    }
}
