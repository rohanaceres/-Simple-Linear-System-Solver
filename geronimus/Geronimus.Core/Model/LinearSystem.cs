using System;
using System.Collections.Generic;

namespace Geronimus.Core.Model
{
    public class LinearSystem
    {
        public const short LimitVariableNumber = 3;

        public List<LinearEquation> Equations { get; private set; }

        public LinearSystem()
        {
            this.Equations = new List<LinearEquation>(3);
        }

        public LinearSystem Add(LinearEquation equation)
        {
            this.Equations.Add(equation);
            return this;
        }
    }
}
