using System;
using Geronimo.Core.Rules.Model;
using Geronimo.Core.Extensions;

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
        // Thanks to: http://www.codesansar.com/numerical-methods/simpson-1-3-rule-algorithm-or-pseudocode.html
        //protected override DerivativeResult SolveItByConcrete()
        //{
        //    double sum = this.SolveEquationAt(0);

        //    // Define 3 pontos igualmente espaçados
        //    double x0, x1, x2, strip;

        //    strip = (this.B.InvertIfNegative() + this.A.InvertIfNegative()) / 2;
        //    x0 = this.A;
        //    x1 = x0 + strip;
        //    x2 = this.B;

        //    // Resolve equação 21.15
        //    double i = (this.B - this.A)
        //        * (this.SolveEquationAt(x0) + 4 * this.SolveEquationAt(x1) 
        //        + this.SolveEquationAt(x2)) / 6;

        //    for (int j = 1; j <= this.IterationNumber - 1; j++)
        //    {
        //        double x = this.A + (this.Heigth * j);

        //        if (j % 2 == 0)
        //        {
        //            sum += 2 * this.SolveEquationAt(x);
        //        }
        //        else
        //        {
        //            sum += 4 * this.SolveEquationAt(x);
        //        }
        //    }

        //    sum += this.SolveEquationAt(this.A) + this.SolveEquationAt(this.B);
        //    double result = sum * this.Heigth / 3;

        //    return new DerivativeResult
        //    {
        //        Result = result,
        //        RelativeError = (result - i).InvertIfNegative(),
        //        RelativeErrorPercentage = string.Format("{0:0.00}% de erro", 100 * (result.InvertIfNegative() - i.InvertIfNegative()) / result.InvertIfNegative())
        //    };
        //}
        protected override DerivativeResult SolveItByConcrete()
        {
            double sum = this.SolveEquationAt(0);

            // Define 3 pontos igualmente espaçados
            double x0, x1, x2, strip;

            strip = (this.B.InvertIfNegative() + this.A.InvertIfNegative()) / 2;
            x0 = this.A;
            x1 = x0 + strip;
            x2 = this.B;

            // Resolve equação 21.15
            double i = (this.B - this.A)
                * (this.SolveEquationAt(x0) + 4 * this.SolveEquationAt(x1)
                + this.SolveEquationAt(x2)) / 6;

            for (int j = 1; j < this.IterationNumber - 2; j += 2)
            {
                sum += 4 * this.SolveEquationAt(this.Heigth * j)
                     + 2 * this.SolveEquationAt(this.Heigth * (j + 1));
            }

            sum += 4 * this.SolveEquationAt(this.Heigth * (this.IterationNumber - 1))
                + this.SolveEquationAt(this.Heigth * this.IterationNumber);

            double result = sum * this.Heigth / 3;

            return new DerivativeResult
            {
                Result = result,
                RelativeError = (result - i).InvertIfNegative(),
                RelativeErrorPercentage = string.Format("{0:0.00}% de erro", 100 * (result.InvertIfNegative() - i.InvertIfNegative()) / result.InvertIfNegative())
            };
        }
    }
}
