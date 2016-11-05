using System;
using Geronimo.Core.Rules.Model;

namespace Geronimo.Core.Rules
{
    public class Simpson38Rule : AbstractRule
    {
        public double A { get; set; }
        public double B { get; set; }
        public int IterationNumber { get; set; }
        public double Heigth { get; set; }

        public Simpson38Rule(double a, double b, int n)
        {
            this.A = a;
            this.B = b;
            this.IterationNumber = n;
            this.Heigth = (b - a) / n;
        }
        // Thanks to: https://onedrive.live.com/view.aspx?cid=fbeb5ec903ef1e67&id=documents&resid=FBEB5EC903EF1E67%2174691&app=Word&authkey=AMp8PL_gFTSmmfo&
        protected override DerivativeResult SolveItByConcrete()
        {
            double sum = this.SolveEquationAt(0);

            double x2, x3;
            x2 = this.B / 3;
            x3 = 2 * this.B / 3;

            double i = this.B
                * (this.SolveEquationAt(this.A) + 3 * (this.SolveEquationAt(x2) + this.SolveEquationAt(x3))
                + this.SolveEquationAt(this.B)) / 8;

            for (int j = 1; j <= this.IterationNumber - 1; j++)
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
            }

            sum += this.SolveEquationAt(this.A) + this.SolveEquationAt(this.B);
            double result = sum * (3 * this.Heigth) / 8;

            return new DerivativeResult
            {
                Result = result,
                RelativeError = result - i,
                RelativeErrorPercentage = string.Format("{0:0.00}% de erro", 100 * (result - i) / result)
            };  
        }
    }
}
