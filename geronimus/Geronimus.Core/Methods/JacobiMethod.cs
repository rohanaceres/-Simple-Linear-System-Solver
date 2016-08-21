using Geronimus.Core.Model;
using Geronimus.Core.Extensions;

namespace Geronimus.Core.Methods
{
    /// <summary>
    /// Jacobi method to solve systems of linear equations.
    /// </summary>
    public sealed class JacobiMethod : AbstractMethod
    {
        /// <summary>
        /// Solve the <see cref="System"/>.
        /// </summary>
        /// <returns><see cref="System"/> result.</returns>
        /// <exception cref="DivideByZeroException">If a division by zero occurred.</exception>
        protected override LinearSystemResult SolveItByConcrete()
        {
            LinearSystemResult result = new LinearSystemResult();

            double x = 0, y = 0, z = 0;
            double x0 = 0, y0 = 0, z0 = 0;
            int iterations = 0;

            do
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

                iterations++;

                //Debug.WriteLine("Iteration: {0}, {1}, {2}", x, y, z);
            }
            while (ShouldIStayOrShouldIGo(x0, x, y0, y, z0, z) == true);

            result.X = x;
            result.Y = y;
            result.Z = z;
            result.Iterations = iterations;

            return result;
        }
        

        /// <summary>
        /// Verify if the algorithm should stop or continue iterating.
        /// Return true if should stay.
        /// </summary>
        /// <returns>If the algorithm should stop or continue iterating.</returns>
        private bool ShouldIStayOrShouldIGo(double x0, double x, double y0, double y, double z0, double z)
        {
            return (x0 - x).InvertIfNegative() > this.ErrorRate 
                && (y0 - y).InvertIfNegative() > this.ErrorRate 
                && (z0 - z).InvertIfNegative() > this.ErrorRate;
        }
    }
}
