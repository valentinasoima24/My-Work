using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLearning.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public double CalculateArea()
        {
            return 0.25 * Math.Sqrt((SideA + SideB + SideC) * (-SideA + SideB + SideC) * (SideA - SideB + SideC) * (SideA + SideB - SideC));

        }
    }
}
