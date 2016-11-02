using System.Collections.Generic;
using System.Text;

namespace Geronimo.Core.LinearEquation.Model
{
    /// <summary>
    /// A linear system solver result.
    /// </summary>
    public class LinearSystemResult
    {
        /// <summary>
        /// Result of linear equations.
        /// </summary>
        public List<double> Values { get; private set; }
        /// <summary>
        /// Number of iterations needed to find the result.
        /// </summary>
        public int Iterations { get; set; }
        /// <summary>
        /// Whether the result was rounded or not.
        /// </summary>
        public bool IsRounded { get; set; }

        public LinearSystemResult(double[] result)
        {
            this.Values = new List<double>(result);
        }
        public LinearSystemResult(int dimension)
        {
            this.Values = new List<double>(dimension);
        }

        public override string ToString()
        {

            StringBuilder builder = new StringBuilder();

            if (this.IsRounded == true)
            {
                builder.Append("Valores arredondados -> ");
            }

            builder.Append("{");

            for (int i = 0; i < this.Values.Count; i++)
            {
                builder.Append(this.Values[i]);

                if (i != this.Values.Count - 1)
                {
                    builder.Append(", ");
                }
            }

            builder.Append("} Total de iterações: ")
                   .Append(this.Iterations);

            return builder.ToString();
        }
    }
}
