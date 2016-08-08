using System;

namespace Geronimus.Core.Model
{
    public class LinearEquation
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double ConstantResult { get; set; }

        public LinearEquation(double x, double y, double z, double result)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.ConstantResult = result;
        }
    }
}
