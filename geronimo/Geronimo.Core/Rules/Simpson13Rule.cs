using System;
using Geronimo.Core.Rules.Model;

namespace Geronimo.Core.Rules
{
    public sealed class Simpson13Rule : AbstractRule
    {
        public double A { get; set; }
        public double B { get; set; }
        public int IterationNumber { get; set; }
        public double Heigth { get; set; }

        public Simpson13Rule(double a, double b, int n)
        {
            this.A = a;
            this.B = b;
            this.IterationNumber = n;
            this.Heigth = (b - a) / n;
        }

        protected override DerivativeResult SolveItByConcrete()
        {
            double sum = this.SolveEquationAt(0);

            double i = this.B * (this.SolveEquationAt(this.A) + 4 * this.SolveEquationAt((this.B - this.A) / 2) + this.SolveEquationAt(this.B)) / 6;

            for (int j = 1; j <= this.IterationNumber - 2; j += 2)
            {
                sum += 4 * this.SolveEquationAt(this.Heigth * j) + 2 * this.SolveEquationAt(this.Heigth * (j + 1));
                Console.WriteLine("i={0}, sum={1}", j, sum);
            }
            sum += 4 * this.SolveEquationAt(this.Heigth * (this.IterationNumber - 1)) + this.SolveEquationAt(this.Heigth * this.IterationNumber);

            double result = this.Heigth * (sum / 3);

            return new DerivativeResult
            {
                Result = result,
                RelativeError = result - i
            };
        }
    }
}
