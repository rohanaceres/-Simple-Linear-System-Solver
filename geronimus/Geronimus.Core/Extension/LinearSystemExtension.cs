using Geronimus.Core.Model;

namespace Geronimus.Core.Extensions
{
    public static class LinearSystemExtension
    {
        public static double [,] ToMatrix (this LinearSystem system)
        {
            double[,] matrix = new double[3, 4];

            if (system == null || system.Equations == null) { return null; }
            
            for (int i = 0; i < system.Dimension; i++)
            {
                for (int j = 0; j < system.Dimension + 1; j++)
                {
                    matrix[i, j] = system.Equations[i].Variables[j];
                }
            }
            
            return matrix;
        }
    }
}
