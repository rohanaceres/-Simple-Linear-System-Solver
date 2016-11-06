using Geronimo.Core.Rules.Model;
using Geronimo.Core.Extensions;
using System;
using System.Diagnostics;

namespace Geronimo.Core.Rules
{
    public class Simpson38Rule : AbstractRule
    {
        public double A { get; set; }
        public double B { get; set; }
        public int IterationNumber { get; set; }
        public double Heigth { get; set; }

        public Simpson38Rule(double a, double b, int n, int dividedBy = 0)
        {
            this.A = a;
            this.B = b;
            this.IterationNumber = n;

            if (dividedBy == 0)
            {
                this.Heigth = (b - a) / n;
            }
            else
            {
                this.Heigth = (b - a) / dividedBy;
            }
        }
        // Thanks to: https://onedrive.live.com/view.aspx?cid=fbeb5ec903ef1e67&id=documents&resid=FBEB5EC903EF1E67%2174691&app=Word&authkey=AMp8PL_gFTSmmfo&
        protected override DerivativeResult SolveItByConcrete()
        {
            double sum = this.SolveEquationAt(this.A) + this.SolveEquationAt(this.B);

            double x0, x1, x2, x3, strip;
            strip = (this.B.InvertIfNegative() + this.A.InvertIfNegative()) / 3;
            x0 = this.A;
            x1 = x0 + strip;
            x2 = x1 + strip;
            x3 = this.B;

            // Resolve equação 21.20
            // TODO: Acho que o calculo do erro está errado.
            double i = (this.B - this.A)
                * (this.SolveEquationAt(x0) + 3 * (this.SolveEquationAt(x1) + this.SolveEquationAt(x2))
                + this.SolveEquationAt(x3)) / 8;

            for (int j = 1; j <= this.IterationNumber; j++)
            {
                double x = this.A + (this.Heigth * j);

                if (j % 3 == 0)
                {
                    sum += 2 * this.SolveEquationAt(x);
                }
                else
                {
                    sum += 3 * this.SolveEquationAt(x);
                }

                double currentResult = 3 * sum * this.Heigth / 8;

                Debug.WriteLine("n = {0} | integral = {1} | erro = {2}",
                    j, currentResult, currentResult - i);
            }

            double result = 3 * sum * this.Heigth / 8;

            return new DerivativeResult
            {
                Result = result,
                RelativeError = (result - i).InvertIfNegative(),
                RelativeErrorPercentage = string.Format("{0:0.00}% de erro", 100 * (result - i).InvertIfNegative() / result)
            };
        }
    }
}
