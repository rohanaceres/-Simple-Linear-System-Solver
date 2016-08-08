using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geronimus.Core.Model;
using Geronimus.Core.Builder;

namespace Geronimus.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LinearSystemResult result = new JacobiMethodBuilder()
                .Method
                .AddEquation(new LinearEquation(70,  1,  0, 363))
                .AddEquation(new LinearEquation(60, -1,  1, 518))
                .AddEquation(new LinearEquation(40,  0, -1, 307))
                .AddErrorRate(0.0001)
                .SolveIt();
        }
        [TestMethod]
        public void MyTestMethod2()
        {
            LinearSystemResult result = new JacobiMethodBuilder()
                .Method
                .AddEquation(new LinearEquation(10, 2, -1, 7))
                .AddEquation(new LinearEquation(1, 8, 3, -4))
                .AddEquation(new LinearEquation(-2, -1, 10, 9))
                .AddErrorRate(0.0001)
                .SolveIt();
        }
    }
}
