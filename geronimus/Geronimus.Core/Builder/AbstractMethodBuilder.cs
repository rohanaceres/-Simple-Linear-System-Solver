using Geronimus.Core.Methods;

namespace Geronimus.Core.Builder
{
    public abstract class AbstractMethodBuilder <T>
        where T : AbstractMethod
    {
        public T Method { get; protected set; }
    }
}
