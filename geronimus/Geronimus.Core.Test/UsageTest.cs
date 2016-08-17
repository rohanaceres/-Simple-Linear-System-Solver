using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geronimus.Core.Model;
using System.Diagnostics;
using Geronimus.Core.Methods;

namespace Geronimus.Core.Test
{
    [TestClass]
    public class UsageTest
    {
        //[TestMethod]
        public void Jacobi1()
        {
            LinearSystemResult result = new JacobiMethod()
                .AddEquation(new LinearEquation(70, 1, 0, 363))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0001)
                .SolveIt();
        }
        //[TestMethod]
        public void Jacobi2()
        {
            LinearSystemResult result = new JacobiMethod()
                .AddEquation(new LinearEquation(10, 2, -1, 7))
                .AddEquation(new LinearEquation(1, 8, 3, -4))
                .AddEquation(new LinearEquation(-2, -1, 10, 9))
                .AddErrorRate(0.000000000001)
                .IsRound(10)
                .SolveIt();

            Debug.WriteLine(result.X + " " + result.Y + " " + result.Z);
        }
        //[TestMethod]
        public void Jacobi_vs_GaussSiedel()
        {
            LinearSystemResult resultj = new JacobiMethod()
               .AddEquation(new LinearEquation(5, -1, 2, 12))
               .AddEquation(new LinearEquation(3, 8, -2, -25))
               .AddEquation(new LinearEquation(1, 1, 4, 6))
               .AddErrorRate(0.000000000001)
               .IsRound(10)
               .SolveIt();

            LinearSystemResult resultgs = new GaussSeidelMethod()
                .AddEquation(new LinearEquation(5, -1, 2, 12))
                .AddEquation(new LinearEquation(3, 8, -2, -25))
                .AddEquation(new LinearEquation(1, 1, 4, 6))
                .AddErrorRate(0.00000000001)
                .IsRound(10)
                .SolveIt();

            Debug.WriteLine("Jacobi: " + resultj.X + " " + resultj.Y + " " + resultj.Z + " - total de iterações: " + resultj.Iterations);
            Debug.WriteLine("Gauss-Siedel: " + resultgs.X + " " + resultgs.Y + " " + resultgs.Z + " - total de iterações: " + resultgs.Iterations);
        }
    }
}
