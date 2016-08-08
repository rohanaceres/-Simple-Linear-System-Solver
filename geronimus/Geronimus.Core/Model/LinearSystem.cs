using System.Collections.Generic;

namespace Geronimus.Core.Model
{
    /// <summary>
    /// A linear system with a maximum of 3 equations.
    /// </summary>
    public class LinearSystem
    {
        /// <summary>
        /// Limit of equations in the system.
        /// </summary>
        public const short LimitVariableNumber = 3;

        /// <summary>
        /// List of equations in the system.
        /// </summary>
        public List<LinearEquation> Equations { get; private set; }

        /// <summary>
        /// Creates a system with 3 equations.
        /// </summary>
        public LinearSystem()
        {
            this.Equations = new List<LinearEquation>(LimitVariableNumber);
        }
    }
}
