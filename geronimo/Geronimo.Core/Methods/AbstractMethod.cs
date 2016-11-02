using Geronimo.Core.Model;
using System;

namespace Geronimo.Core.Methods
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
        /// System dimension.
        /// </summary>
        public Nullable<int> Dimension { get; protected set; }

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
            LinearSystemResult result = this.SolveItByConcrete();

            if (this.DecimalPlacesToRound.HasValue == true)
            {
                for (int i = 0; i < result.Values.Count; i++)
                {
                    result.Values[i] = Math.Round(result.Values[i], this.DecimalPlacesToRound.Value);
                }

                result.IsRounded = true;
            }

            return result;
        }
        /// <summary>
        /// Add an equation to the <see cref="System"/>.
        /// </summary>
        /// <param name="equation">New equation.</param>
        /// <returns>Itself.</returns>
        public virtual AbstractMethod AddEquation(LinearEquation equation)
        {
            this.ValidateEquation(equation);
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
        /// <summary>
        /// Set system dimension.
        /// </summary>
        /// <param name="dimension">System dimension.</param>
        /// <returns>Itself.</returns>
        public virtual AbstractMethod AddDimension(int dimension)
        {
            this.Dimension = dimension;
            return this;
        }

        /// <summary>
        /// Solve the <see cref="System"/> by concrete class.
        /// </summary>
        /// <returns><see cref="System"/> result.</returns>
        /// <exception cref="DivideByZeroException">If a division by zero occurred.</exception>
        protected abstract LinearSystemResult SolveItByConcrete();

        /// <summary>
        /// Validate equations to ensure the integrity of the linear system.
        /// </summary>
        /// <param name="equation">Equation to be validated.</param>
        private void ValidateEquation(LinearEquation equation)
        {
            if (this.Dimension.HasValue == false)
            {
                throw new InvalidOperationException("Set dimension first.");
            }
            if (equation.Variables.Count != this.Dimension + 1)
            {
                throw new ArgumentException("Your system dimension is " + 
                    this.Dimension.Value + ", hence your equation must have " 
                    + (this.Dimension + 1) + " numbers.");
            }
        }
    }
}
