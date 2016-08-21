namespace Geronimus.Core.Model
{
    /// <summary>
    /// A linear equation with 3 variables.
    /// </summary>
    /// <example>2x + 3y + 4z = 5</example>
    public class LinearEquation
    {
        /// <summary>
        /// Variable X.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Variable Y.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Variable Z.
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// Equation constant result.
        /// </summary>
        public double ConstantResult { get; set; }

        /// <summary>
        /// Creates an instance with all variables.
        /// </summary>
        /// <param name="x">Variable X.</param>
        /// <param name="y">Variable Y.</param>
        /// <param name="z">Variable Z.</param>
        /// <param name="result">Equation constant result.</param>
        public LinearEquation(double x, double y, double z, double result)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.ConstantResult = result;
        }
    }
}
