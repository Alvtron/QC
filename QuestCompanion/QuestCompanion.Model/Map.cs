using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Map
    {
        public Image Image { get; set; }
        public List<Coordinate> Coordinates { get; set; }

        public void AddCoordinate(Coordinate Coordinate)
        {
            Coordinates.Add(Coordinate);
        }
    }
}
