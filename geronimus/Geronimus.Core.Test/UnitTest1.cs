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
                .AddEquation(new LinearEquation())
                .AddEquation(new LinearEquation())
                .AddEquation(new LinearEquation())
                .AddErrorRate(0.0001m)
                .SolveIt();
        }
    }
}
