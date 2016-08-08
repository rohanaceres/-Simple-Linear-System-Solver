using Geronimus.Core.Model;
using Geronimus.Core.Extensions;
using System;
using System.Diagnostics;

namespace Geronimus.Core.Methods
{
    public class JacobiMethod : AbstractMethod
    {
        public override LinearSystemResult SolveIt()
        {
            LinearSystemResult result = new LinearSystemResult();

            double x = 0, y = 0, z = 0;
            double x0 = 0, y0 = 0, z0 = 0;

            while (ShouldIStayOrShouldIGo(x0, x, y0, y, z0, z))
            {
                x0 = x;
                y0 = y;
                z0 = z;

                x = (this.System.Equations[0].Y.Invert() * y0
                     + this.System.Equations[0].Z.Invert() * z0
                     + this.System.Equations[0].ConstantResult)
                    / this.System.Equations[0].X;

                y = (this.System.Equations[1].X.Invert() * x0
                     + this.System.Equations[1].Z.Invert() * z0
                     + this.System.Equations[1].ConstantResult)
                    / this.System.Equations[1].Y;

                z = (this.System.Equations[2].X.Invert() * x0
                     + this.System.Equations[2].Y.Invert() * y0
                     + this.System.Equations[2].ConstantResult)
                     / this.System.Equations[2].Z;

                Debug.WriteLine("Iteration: {0}, {1}, {2}", x, y, z);
            };

            result.X = x;
            result.Y = y;
            result.Z = z;

            return result;
        }

        private bool ShouldIStayOrShouldIGo(double x0, double x, double y0, double y, double z0, double z)
        {
            return (x0 - x).InvertIfNegative() > this.ErrorRate 
                && (y0 - y).InvertIfNegative() > this.ErrorRate 
                && (z0 - z).InvertIfNegative() > this.ErrorRate;
        }
    }
}
