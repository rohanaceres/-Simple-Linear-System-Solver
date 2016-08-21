using System.Collections;
using System.Collections.Generic;

namespace Geronimus.Core.Model
{
    /// <summary>
    /// A linear equation with 3 variables.
    /// </summary>
    /// <example>2x + 3y + 4z = 5</example>
    public class LinearEquation
    {
        public List<double> Variables { get; private set; }

        /// <summary>
        /// Creates an instance with all variables.
        /// </summary>
        /// <param name="vars">Equation variables coefficient.</param>
        public LinearEquation(params double [] vars)
        {
            this.Variables = new List<double>(vars);
        }
    }
}
