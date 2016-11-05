using Geronimo.Core.Rules.Model;
using System;
using System.Collections.Generic;

namespace Geronimo.Core.Rules
{
    public abstract class AbstractRule
    {
        public Equation Equation { get; set; }
        public Func<double, double> SolveEquationAtImpl { get; set; }

        public AbstractRule()
        {
            this.Equation = new Equation();
        }

        public DerivativeResult SolveIt ()
        {
            return this.SolveItByConcrete();
        }
        public AbstractRule AddToEquation(double coefficient, int power)
        {
            this.Equation.Items.Add(new KeyValuePair<double, int>(coefficient, power));
            return this;
        }
        protected double SolveEquationAt (double index)
        {
            if (this.SolveEquationAtImpl != null)
            {
                return this.SolveEquationAtImpl(index);
            }
            else
            {
                double result = 0;

                foreach (KeyValuePair<double, int> currentItem in this.Equation.Items)
                {
                    result += currentItem.Key * (Math.Pow(index, currentItem.Value));
                }

                return result;
            }
        }
        protected abstract DerivativeResult SolveItByConcrete();
    }
}
