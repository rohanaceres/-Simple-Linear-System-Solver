using Geronimus.Core.Extensions;
using Geronimus.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

            for (int i = 0; i < system.Dimension; i++)
            {
                for (int j = 0; j < system.Dimension + 1; j++)
                {
                    Debug.Write(matrix[i, j] + " ");
                }
                Debug.Write(Environment.NewLine);
            }

            for (int i = 0; i < system.Dimension; i++)
            {
                for (int j = 0; j < system.Dimension + 1; j++)
                {
                    Assert.AreEqual(matrix[i, j], system.Equations[i].Variables[j]);
                }
            }
        }
    }
}
