using Geronimus.Core.Methods;

namespace Geronimus.Core.Builder
{
    /// <summary>
    /// Abstract builder, only to make it easy to call and create
    /// instances to solve system of linear equations.
    /// </summary>
    /// <typeparam name="T">Method to solve system of linear equations.</typeparam>
    public abstract class AbstractMethodBuilder <T>
        where T : AbstractMethod, new()
    {
        /// <summary>
        /// Method to solve system of linear equations.
        /// </summary>
        /// <example><see cref="JacobiMethod"/> and <see cref="JacobiMethodBuilder"/></example>
        public T Method { get; protected set; }

        public AbstractMethodBuilder()
        {
            this.Method = new T();
        }
    }
}
