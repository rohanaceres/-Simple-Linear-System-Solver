using System;

namespace Geronimus.Core.Model
{
    /// <summary>
    /// A linear system solver result.
    /// </summary>
    public class LinearSystemResult
    {
        /// <summary>
        /// Variable X value.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Variable Y value.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Variable Z value.
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// Number of iterations needed to find the result.
        /// </summary>
        public int Iterations { get; set; }
        /// <summary>
        /// Whether the result was rounded or not.
        /// </summary>
        public bool IsRounded { get; set; }
    }
}
