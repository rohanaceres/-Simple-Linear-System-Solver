using Geronimus.Core.Methods;

namespace Geronimus.Core.Builder
{
    public class JacobiMethodBuilder : AbstractMethodBuilder<JacobiMethod>
    {
        public JacobiMethodBuilder()
        {
            this.Method = new JacobiMethod();
        }
    }
}
