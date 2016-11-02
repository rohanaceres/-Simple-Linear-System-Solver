using Geronimo.Core.Rules;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geronimo.Core.Test
{
    [TestClass]
    public class RuleUsageTest
    {
        [TestMethod]
        public void MyTestMethod()
        {
            double a, b;
            int n;

            a = 0;
            b = 0.8;
            n = 500;

            double trResult = new TrapezoidalRule(a, b, n)
                .AddToEquation(+0.2, 0)
                .AddToEquation(+25,  1)
                .AddToEquation(-200, 2)
                .AddToEquation(+675, 3)
                .AddToEquation(-900, 4)
                .AddToEquation(+400, 5)
                .SolveIt();
         }
    }
}
