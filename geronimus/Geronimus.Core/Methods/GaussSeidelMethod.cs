using Geronimo.Core.Extensions;
using Geronimo.Core.Model;
using System.Diagnostics;

namespace Geronimo.Core.Methods
{
    public sealed class GaussSeidelMethod : AbstractMethod
    {
        protected override LinearSystemResult SolveItByConcrete()
        {
            LinearSystemResult result = new LinearSystemResult(this.Dimension.Value);

            double[] r = new double[this.Dimension.Value];
            double[] tmp = new double[this.Dimension.Value];

            do
            {
                r.CopyTo(tmp, 0);

                for (int i = this.Dimension.Value - 1; i >= 0; i--)
                {
                    r[i] = this.System.Equations[i].Variables[this.Dimension.Value];

                    for (int j = 0; j < this.Dimension.Value; j++)
                    {
                        if (j != i)
                        {
                            r[i] -= this.System.Equations[i].Variables[j] * r[j];
                        }
                    }

                    r[i] /= this.System.Equations[i].Variables[i];
                }

                result.Iterations++;
            }
            while (ShouldIStay(r, tmp) == true);

            result.Values.InsertRange(0, r);

            return result;
        }

        /// <summary>
        /// Verify if the algorithm should stop or continue iterating.
        /// Return true if should stay.
        /// </summary>
        /// <returns>If the algorithm should stop or continue iterating.</returns>
        private bool ShouldIStay(double[] a, double[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if ((a[i] - b[i]).InvertIfNegative() > this.ErrorRate)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
