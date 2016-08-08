using Geronimus.Core.Model;

namespace Geronimus.Core.Methods
{
    /// <summary>
    /// Abstract method to solve systems of linear equations.
    /// </summary>
    public abstract class AbstractMethod
    {
        /// <summary>
        /// System to be solved.
        /// </summary>
        public LinearSystem System { get; protected set; }
        /// <summary>
        /// Error rate to determine when the algorithm should stop iterate.
        /// </summary>
        public double ErrorRate { get; protected set; }
        
        /// <summary>
        /// Create an instance of <see cref="System"/>.
        /// </summary>
        public AbstractMethod()
        {
            this.System = new LinearSystem();
        }

        /// <summary>
        /// Solve the <see cref="System"/>.
        /// </summary>
        /// <returns>System result.</returns>
        public abstract LinearSystemResult SolveIt();
        /// <summary>
        /// Add an equation to the <see cref="System"/>.
        /// </summary>
        /// <param name="equation">New equation.</param>
        /// <returns>Itself.</returns>
        public virtual AbstractMethod AddEquation (LinearEquation equation)
        {
            this.System.Equations.Add(equation);
            return this;
        }
        /// <summary>
        /// Add the <see cref="ErrorRate"/>.
        /// </summary>
        /// <param name="errorRate">New error rate.</param>
        /// <returns>Itself.</returns>
        public virtual AbstractMethod AddErrorRate(double errorRate)
        {
            this.ErrorRate = errorRate;
            return this;
        }
    }
}
