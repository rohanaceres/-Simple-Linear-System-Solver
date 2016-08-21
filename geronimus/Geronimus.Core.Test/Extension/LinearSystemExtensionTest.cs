using Geronimus.Core.Extensions;
using Geronimus.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Geronimus.Core.Test.Extension
{
    [TestClass]
    public class LinearSystemExtensionTest
    {
        [TestMethod]
        public void ToMatrix_test()
        {
            LinearSystem system = new LinearSystem();

            system.Equations.Add(new LinearEquation(1, 2, 3, 4));
            system.Equations.Add(new LinearEquation(5, 6, 7, 8));
            system.Equations.Add(new LinearEquation(9, 10, 11, 12));

            double[,] matrix = system.ToMatrix();

            int i = 0;
            foreach (LinearEquation currentEquation in system.Equations)
            {
                Assert.AreEqual(matrix[i, 0], system.Equations[i].X);
                Assert.AreEqual(matrix[i, 1], system.Equations[i].Y);
                Assert.AreEqual(matrix[i, 2], system.Equations[i].Z);
                Assert.AreEqual(matrix[i, 3], system.Equations[i].ConstantResult);

                i++;
            }
        }
    }
}
