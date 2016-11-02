using System.Collections.Generic;

namespace Geronimo.Core.Rules.Model
{
    public sealed class Equation
    {
        public List<KeyValuePair<double, int>> Items { get; set; }

        public Equation()
        {
            this.Items = new List<KeyValuePair<double, int>>();
        }
    }
}
