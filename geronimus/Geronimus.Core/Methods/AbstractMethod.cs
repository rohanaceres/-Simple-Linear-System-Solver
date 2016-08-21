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
        /// Number of decimal places the result should have.
        /// If null, the most accurate value will be returned.
        /// </summary>
        public Nullable<int> DecimalPlacesToRound { get; protected set; }
        
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
            LinearSystemResult result = this.SolveItByConcrete();

            if (this.DecimalPlacesToRound.HasValue == true)
            {
                result.X = Math.Round(result.X, this.DecimalPlacesToRound.Value);
                result.Y = Math.Round(result.Y, this.DecimalPlacesToRound.Value);
                result.Z = Math.Round(result.Z, this.DecimalPlacesToRound.Value);
                result.IsRounded = true;
            }

            return result;
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
        /// <summary>
        /// Add decimal praces to round the result.
        /// </summary>
        /// <param name="decimalPlacesToRound">Number of decimal places.</param>
        /// <returns>Itself.</returns>
        public virtual AbstractMethod IsRound(int decimalPlacesToRound)
        {
            this.DecimalPlacesToRound = decimalPlacesToRound;
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
