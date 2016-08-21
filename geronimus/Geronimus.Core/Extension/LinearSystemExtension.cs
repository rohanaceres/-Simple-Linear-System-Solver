using Geronimus.Core.Model;

namespace Geronimus.Core.Extensions
{
    public static class LinearSystemExtension
    {
        public static double [,] ToMatrix (this LinearSystem system)
        {
            double[,] matrix = new double[3, 4];

            if (system == null || system.Equations == null) { return null; }

            int i = 0;

            foreach (LinearEquation currentEquation in system.Equations)
            {
                matrix[i, 0] = currentEquation.X;
                matrix[i, 1] = currentEquation.Y;
                matrix[i, 2] = currentEquation.Z;
                matrix[i, 3] = currentEquation.ConstantResult;

                i++;
            }

            return matrix;
        }
        public static LinearSystem ToLinearSystem(this double [,] matrix, int rows)
        {
            LinearSystem system = new LinearSystem();

            for (int i = 0; i < rows; i++)
            {
                system.Equations[i].X = matrix[i, 0];
                system.Equations[i].Y = matrix[i, 1];
                system.Equations[i].Z = matrix[i, 2];
                system.Equations[i].ConstantResult = matrix[i, 3];
            }

            return system;
        }
    }
}
