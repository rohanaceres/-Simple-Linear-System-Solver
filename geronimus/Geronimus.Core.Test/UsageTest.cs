using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geronimus.Core.Model;
using System.Diagnostics;
using Geronimus.Core.Methods;

namespace Geronimus.Core.Test
{
    [TestClass]
    public class UsageTest
    {
        [TestMethod]
        public void Jacobi_parachute_problem()
        {
            LinearSystemResult result = new JacobiMethod()
                .AddDimension(3)
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0001)
                .SolveIt();

            Debug.WriteLine("Jacobi: " + result.ToString());
        }
        [TestMethod]
        public void Jacobi_test()
        {
            LinearSystemResult result = new JacobiMethod()
                .AddDimension(3)
                .AddEquation(new LinearEquation(10, 2, -1, 7))
                .AddEquation(new LinearEquation(1, 8, 3, -4))
                .AddEquation(new LinearEquation(-2, -1, 10, 9))
                .AddErrorRate(0.000000000001)
                .IsRound(10)
                .SolveIt();

            Debug.WriteLine("Jacobi: " + result.ToString());

            Assert.AreEqual(result.Values[0], 1);
            Assert.AreEqual(result.Values[1], -1);
            Assert.AreEqual(result.Values[2], 1);
        }
        [TestMethod]
        public void Jacobi_vs_GaussSiedel()
        {
            LinearSystemResult resultj = new JacobiMethod()
                .AddDimension(3)
               .AddEquation(new LinearEquation(5, -1, 2, 12))
               .AddEquation(new LinearEquation(3, 8, -2, -25))
               .AddEquation(new LinearEquation(1, 1, 4, 6))
               .AddErrorRate(0.000000000001)
               .IsRound(10)
               .SolveIt();

            Assert.AreEqual(resultj.Values[0], 1);
            Assert.AreEqual(resultj.Values[1], -3);
            Assert.AreEqual(resultj.Values[2], 2);

            LinearSystemResult resultgs = new GaussSeidelMethod()
                .AddDimension(3)
                .AddEquation(new LinearEquation(5, -1, 2, 12))
                .AddEquation(new LinearEquation(3, 8, -2, -25))
                .AddEquation(new LinearEquation(1, 1, 4, 6))
                .AddErrorRate(0.00000000001)
                .IsRound(10)
                .SolveIt();

            Debug.WriteLine("Jacobi: " + resultj.ToString());
            Debug.WriteLine("Gauss-Siedel: " + resultgs.ToString());

            Assert.AreEqual(resultj.Values[0], resultgs.Values[0]);
            Assert.AreEqual(resultj.Values[1], resultgs.Values[1]);
            Assert.AreEqual(resultj.Values[2], resultgs.Values[2]);
            Assert.IsTrue(resultgs.Iterations < resultj.Iterations);
        }
        [TestMethod]
        public void Jacobi_vs_GaussSiedel_parachute_problem()
        {
            LinearSystemResult resultj = new JacobiMethod()
                .AddDimension(3)
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0000001)
                .IsRound(4)
                .SolveIt();

            LinearSystemResult resultgs = new GaussSeidelMethod()
                .AddDimension(3)
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0000001)
                .IsRound(4)
                .SolveIt();

            Debug.WriteLine("Jacobi: " + resultj.ToString());
            Debug.WriteLine("Gauss-Siedel: " + resultgs.ToString());
        }
        [TestMethod]
        public void GaussSiedel_parachute_problem()
        {
            LinearSystemResult resultgs = new GaussSeidelMethod()
                .AddDimension(3)
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0000001)
                .IsRound(4)
                .SolveIt();

            Debug.WriteLine("Gauss-Siedel: " + resultgs.ToString());

            Assert.AreEqual(resultgs.Values[0], 8.5941);
            Assert.AreEqual(resultgs.Values[1], 34.4118);
            Assert.AreEqual(resultgs.Values[2], 36.7647);
        }
        [TestMethod]
        public void GaussElimination_test()
        {
            LinearSystemResult result = new GaussJordanMethod()
                .AddDimension(3)
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .IsRound(4)
                .SolveIt();

            Debug.WriteLine("Gauss-Jordan: " + result.ToString());
        }
    }
}
