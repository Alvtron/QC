using System;
using System.Collections.Generic;
using System.Text;

namespace QC.Model
{
    public struct Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Label { get; set; }

        public Coordinate(double x, double y, string label = null)
        {
            X = x;
            Y = y;
            Label = label;
        }
    }
}
