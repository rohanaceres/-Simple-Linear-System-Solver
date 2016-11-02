using System;
using System.Diagnostics;

namespace Geronimo.Core.Rules
{
    public sealed class TrapezoidalRule : AbstractRule
    {
        public double A { get; set; }
        public double B { get; set; }
        public int IterationNumber { get; set; }
        public double Heigth { get; set; }

        public TrapezoidalRule (double a, double b, int n)
        {
            this.A = a;
            this.B = b;
            this.IterationNumber = n;
            this.Heigth = (b - a)/n;
        }
        protected override double SolveItByConcrete()
        {
            double sum = this.SolveEquationAt(0);

            this.B = this.A + this.Heigth;

            for (int i = 1; i < this.IterationNumber; i++)
            {
                Debug.WriteLine("{0} > a={1}, b={2}, sum={3}", i, this.A, this.B, sum);

                sum += 2 * this.SolveEquationAt(this.B);
                this.B += this.Heigth;
            }

            sum += this.SolveEquationAt(this.B);

            return this.Heigth * (sum / 2);
        }
    }
}
