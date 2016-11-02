using Geronimo.Core.Rules.Model;
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
        protected override DerivativeResult SolveItByConcrete()
        {
            double sum = this.SolveEquationAt(0);

            // No final, deve ser subtraído do resultado para gerar o erro relativo!
            double i = this.B * (this.SolveEquationAt(this.A) + this.SolveEquationAt(this.B)) / 2;

            this.B = this.A + this.Heigth;

            for (int j = 1; j < this.IterationNumber; j++)
            {
                // TODO: Lançar evento para mostrar na view os valores de iteração! :/
                sum += 2 * this.SolveEquationAt(this.B);
                this.B += this.Heigth;
            }
            
            sum += this.SolveEquationAt(this.B);

            double result = this.Heigth * (sum / 2);

            return new DerivativeResult
            {
                Result = result,
                RelativeError = result - i
            };
        }
    }
}
