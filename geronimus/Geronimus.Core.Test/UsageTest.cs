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
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0001)
                .SolveIt();

            Debug.WriteLine("Jacobi: {" + result.X + ", " + result.Y + ", " + result.Z + "} Total de iterações: " + result.Iterations);
        }
        [TestMethod]
        public void Jacobi_test()
        {
            LinearSystemResult result = new JacobiMethod()
                .AddEquation(new LinearEquation(10, 2, -1, 7))
                .AddEquation(new LinearEquation(1, 8, 3, -4))
                .AddEquation(new LinearEquation(-2, -1, 10, 9))
                .AddErrorRate(0.000000000001)
                .IsRound(10)
                .SolveIt();

            Debug.WriteLine("Jacobi: {" + result.X + ", " + result.Y + ", " + result.Z + "} Total de iterações: " + result.Iterations);

            Assert.AreEqual(result.X, 1);
            Assert.AreEqual(result.Y, -1);
            Assert.AreEqual(result.Z, 1);
        }
        [TestMethod]
        public void Jacobi_vs_GaussSiedel()
        {
            LinearSystemResult resultj = new JacobiMethod()
               .AddEquation(new LinearEquation(5, -1, 2, 12))
               .AddEquation(new LinearEquation(3, 8, -2, -25))
               .AddEquation(new LinearEquation(1, 1, 4, 6))
               .AddErrorRate(0.000000000001)
               .IsRound(10)
               .SolveIt();

            Assert.AreEqual(resultj.X, 1);
            Assert.AreEqual(resultj.Y, -3);
            Assert.AreEqual(resultj.Z, 2);

            LinearSystemResult resultgs = new GaussSeidelMethod()
                .AddEquation(new LinearEquation(5, -1, 2, 12))
                .AddEquation(new LinearEquation(3, 8, -2, -25))
                .AddEquation(new LinearEquation(1, 1, 4, 6))
                .AddErrorRate(0.00000000001)
                .IsRound(10)
                .SolveIt();

            Debug.WriteLine("Jacobi: {" + resultj.X + ", " + resultj.Y + ", " + resultj.Z + "} Total de iterações: " + resultj.Iterations);
            Debug.WriteLine("Gauss-Siedel: {" + resultgs.X + ", " + resultgs.Y + ", " + resultgs.Z + "} Total de iterações: " + resultgs.Iterations);

            Assert.AreEqual(resultj.X, resultgs.X);
            Assert.AreEqual(resultj.Y, resultgs.Y);
            Assert.AreEqual(resultj.Z, resultgs.Z);
            Assert.IsTrue(resultgs.Iterations < resultj.Iterations);
        }
        [TestMethod]
        public void Jacobi_vs_GaussSiedel_parachute_problem()
        {
            LinearSystemResult resultj = new JacobiMethod()
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0000001)
                .IsRound(4)
                .SolveIt();

            LinearSystemResult resultgs = new GaussSeidelMethod()
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0000001)
                .IsRound(4)
                .SolveIt();

            Debug.WriteLine("Jacobi: \t\t{" + resultj.X + ", " + resultj.Y + ", " + resultj.Z + "} Total de iterações: " + resultj.Iterations);
            Debug.WriteLine("Gauss-Siedel: \t{" + resultgs.X + ", " + resultgs.Y + ", " + resultgs.Z + "} Total de iterações: " + resultgs.Iterations);
        }
        [TestMethod]
        public void GaussSiedel_parachute_problem()
        {
            LinearSystemResult resultgs = new GaussSeidelMethod()
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .AddErrorRate(0.0000001)
                .IsRound(4)
                .SolveIt();

            Debug.WriteLine("Gauss-Siedel: {" + resultgs.X + ", " + resultgs.Y + ", " + resultgs.Z + "} Total de iterações: " + resultgs.Iterations);

            Assert.AreEqual(resultgs.X, 8.5941);
            Assert.AreEqual(resultgs.Y, 34.4118);
            Assert.AreEqual(resultgs.Z, 36.7647);
        }
        [TestMethod]
        public void GaussElimination_test()
        {
            LinearSystemResult result = new GaussJordanMethod()
                .AddEquation(new LinearEquation(70, 1, 0, 636))
                .AddEquation(new LinearEquation(60, -1, 1, 518))
                .AddEquation(new LinearEquation(40, 0, -1, 307))
                .IsRound(4)
                .SolveIt();

            Debug.WriteLine("Gauss-Jordan: {" + result.X + ", " + result.Y + ", " + result.Z + "} Total de iterações: " + result.Iterations);
        }
    }
}
