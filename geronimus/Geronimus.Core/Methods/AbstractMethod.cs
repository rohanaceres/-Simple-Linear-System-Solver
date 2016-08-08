using Geronimus.Core.Model;
using System;

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
        /// Solve the <see cref="System"/> and validate data before.
        /// </summary>
        /// <returns><see cref="System"/> result.</returns>
        /// <exception cref="InvalidOperationException">If a system with an invalid number of equations is input.</exception>
        /// <exception cref="DivideByZeroException">If a division by zero occurred.</exception>
        public LinearSystemResult SolveIt()
        {
            this.Validate();
            return this.SolveItByConcrete();
        }
        /// <summary>
        /// Solve the <see cref="System"/> by concrete class.
        /// </summary>
        /// <returns><see cref="System"/> result.</returns>
        /// <exception cref="DivideByZeroException">If a division by zero occurred.</exception>
        protected abstract LinearSystemResult SolveItByConcrete();
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

        private void Validate()
        {
            if (this.System.Equations.Count != LinearSystem.LimitVariableNumber)
            {
                throw new InvalidOperationException("Invalid number of equations. Only systems with 3 equations are supported.");
            }
        }
    }
}
