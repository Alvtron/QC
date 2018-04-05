using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QC.Model
{
    [ComplexType]
    public class Coordinate
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
