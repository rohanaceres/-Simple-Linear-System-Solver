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
    }
}
