namespace Geronimus.Core.Extensions
{
    /// <summary>
    /// Extension to make it easy simple operations on double variables.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Invert the number.
        /// </summary>
        /// <param name="self">Number to be inverted.</param>
        /// <returns>Inverted number.</returns>
        /// <example>Input: 1 -> Output: -1</example>
        public static double Invert(this double self)
        {
            return self * -1;
        }
        /// <summary>
        /// Invert a number, only if it is negative.
        /// </summary>
        /// <param name="self">Number to be inverted.</param>
        /// <returns>Inverted number, if the input is negative and itself if the input is positive.</returns>
        /// <example>Input: -1 -> Output: 1. Input: 2 -> Output: 2</example>
        public static double InvertIfNegative(this double self)
        {
            if (self < 0)
            {
                return self.Invert();
            }

            return self;
        }
    }
}
