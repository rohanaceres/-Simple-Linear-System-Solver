using Geronimo.Core.Rules;
using Geronimo.Core.Rules.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geronimo.Core.Test
{
    [TestClass]
    public class RuleUsageTest
    {
        [TestMethod]
        public void TrapezoidalRule_test()
        {
            double a, b;
            int n;

            a = 0;
            b = 0.8;
            n = 500;

            DerivativeResult trResult = new TrapezoidalRule(a, b, n)
                .AddToEquation(+0.2, 0)
                .AddToEquation(+25,  1)
                .AddToEquation(-200, 2)
                .AddToEquation(+675, 3)
                .AddToEquation(-900, 4)
                .AddToEquation(+400, 5)
                .SolveIt();
        }
        [TestMethod]
        public void Simpson13Rule_test()
        {
            double a, b;
            int n;

            a = 0;
            b = 0.8;
            n = 50;

            DerivativeResult s13Result = new Simpson13Rule(a, b, n)
                .AddToEquation(+0.2, 0)
                .AddToEquation(+25, 1)
                .AddToEquation(-200, 2)
                .AddToEquation(+675, 3)
                .AddToEquation(-900, 4)
                .AddToEquation(+400, 5)
                .SolveIt();

            Assert.AreEqual(s13Result.Result, 1.6405326342826709);
            Assert.AreEqual(s13Result.RelativeError, 0.27306596761599655);
        }
        [TestMethod]
        public void Simpson38Rule_test()
        {
            double a, b;
            int n;

            a = 0;
            b = 0.8;
            n = 20;

            DerivativeResult s38Result = new Simpson38Rule(a, b, n)
                .AddToEquation(+0.2, 0)
                .AddToEquation(+25, 1)
                .AddToEquation(-200, 2)
                .AddToEquation(+675, 3)
                .AddToEquation(-900, 4)
                .AddToEquation(+400, 5)
                .SolveIt();

            // 1.6400964266666769
            Assert.AreEqual(s38Result.Result, 1.640573333331393);
            Assert.AreEqual(s38Result.RelativeError, 0.12140296296101516);
        }
        [TestMethod]
        public void Simpson13Rule_21_5()
        {
            double a, b;
            int n;

            a = -3;
            b = 5;
            n = 4;

            Simpson13Rule s13 = new Simpson13Rule(a, b, n)
            {
                SolveEquationAtImpl = this.SolveEquationAtImpl
            };

            DerivativeResult s13Result4 = s13
                .SolveIt();

            n = 5;
            s13 = new Simpson13Rule(a, b, n)
            {
                SolveEquationAtImpl = this.SolveEquationAtImpl
            };
            DerivativeResult s13Result5 = s13
                .SolveIt();

            ; // Conclusão: só pode número par!
        }
        [TestMethod]
        public void Simpson38Rule_21_5()
        {
            double a, b;
            int n;

            a = -3;
            b = 5;
            n = 4;

            Simpson38Rule s38 = new Simpson38Rule(a, b, n)
            {
                SolveEquationAtImpl = this.SolveEquationAtImpl
            };

            DerivativeResult s38Result4 = s38
                .SolveIt();

            n = 101;
            s38 = new Simpson38Rule(a, b, n)
            {
                SolveEquationAtImpl = this.SolveEquationAtImpl
            };

            DerivativeResult s38Result5 = s38
                .SolveIt();

            ; // Conclusão: não diferem se o numero de iterações (n) for pequeno. Conforme o numero de iterações aumenta,
            // mais percebe-se a diferença entre os resultados quando n é impar e par.
        }
        private double SolveEquationAtImpl (double index)
        {
            return Math.Pow((4 * index) - 3, 3);
        }
    }
}
