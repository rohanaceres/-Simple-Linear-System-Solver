using Geronimus.Core.Extensions;
using Geronimus.Core.Model;
using System.Diagnostics;

namespace Geronimus.Core.Methods
{
    public class GaussSeidelMethod : AbstractMethod
    {
        protected override LinearSystemResult SolveItByConcrete()
        {
            LinearSystemResult result = new LinearSystemResult();

            double tmpX = 0, tmpY = 0, tmpZ = 0;

            do
            {
                tmpX = result.X;
                tmpY = result.Y;
                tmpZ = result.Z;

                result.X = (this.System.Equations[0].Y.Invert() * tmpY
                     + this.System.Equations[0].Z.Invert() * tmpZ
                     + this.System.Equations[0].ConstantResult)
                    / this.System.Equations[0].X;

                result.Y = (this.System.Equations[1].X.Invert() * result.X
                     + this.System.Equations[1].Z.Invert() * result.Z
                     + this.System.Equations[1].ConstantResult)
                    / this.System.Equations[1].Y;

                result.Z = (this.System.Equations[2].X.Invert() * result.X
                     + this.System.Equations[2].Y.Invert() * result.Y
                     + this.System.Equations[2].ConstantResult)
                     / this.System.Equations[2].Z;

                result.Iterations++;

                Debug.WriteLine("Iteration: {0}, {1}, {2}", result.X, result.Y, result.Z);
            }
            while (ShouldIStayOrShouldIGo(result, tmpX, tmpY, tmpZ) == true);
            
            return result;
        }

        /// <summary>
        /// Verify if the algorithm should stop or continue iterating.
        /// Return true if should stay.
        /// </summary>
        /// <returns>If the algorithm should stop or continue iterating.</returns>
        private bool ShouldIStayOrShouldIGo(LinearSystemResult currentResult, double x, double y, double z)
        {
            return (currentResult.X - x).InvertIfNegative() > this.ErrorRate
                && (currentResult.Y - y).InvertIfNegative() > this.ErrorRate
                && (currentResult.Z - z).InvertIfNegative() > this.ErrorRate;
        }
    }
}
