using Geronimus.Core.Model;
using Geronimus.Core.Extensions;
using System.Diagnostics;
using System;

namespace Geronimus.Core.Methods
{
    /// <summary>
    /// Also known as Gauss-Jordan or Gaussian elimination to solve
    /// a system with linear equations.
    /// </summary>
    public class GaussJordanMethod : AbstractMethod
    { 
        protected override LinearSystemResult SolveItByConcrete()
        {
            LinearSystemResult result = new LinearSystemResult();
            double[,] matrix = this.System.ToMatrix();

            this.GetPivot(matrix);
            this.GaussEliminate(matrix);

            double[] rawResult = this.BackSubstitution(matrix);

            result.X = rawResult[0];
            result.Y = rawResult[1];
            result.Z = rawResult[2];
            result.Iterations = 3;

            return result;
        }

        protected virtual void GetPivot (double [,] matrix)
        {
            int i, k, j;
            int dimension = 3;

            for (i = 0; i < dimension; i++)
            {
                for (k = i + 1; k < dimension; k++)
                {
                    if (matrix[i, i] < matrix[k, i])
                    {
                        for (j = 0; j <= dimension; j++)
                        {
                            double temp = matrix[i, j];
                            matrix[i, j] = matrix[k, j];
                            matrix[k, j] = temp;
                        }
                    }
                }
            }
        }
        protected virtual void GaussEliminate(double [,] matrix)
        {
            int dimension = 3;

            for (int i = 0; i < dimension - 1; i++)
            {
                for (int k = i + 1; k < dimension; k++)
                {
                    double t = matrix[k, i] / matrix[i, i];

                    for (int j = 0; j <= dimension; j++)
                    {
                        // Make the elements below the pivot elements equal 
                        // to zero or elimnate the variables
                        matrix[k, j] = matrix[k, j] - t * matrix[i, j];
                    }
                }
            }
        }
        protected virtual double [] BackSubstitution(double [,] matrix)
        {
            int dimension = 3;
            double[] result = new double[dimension];

            for (int i = dimension - 1; i >= 0; i--)                
            {
                // Make the variable to be calculated equal to the 
                // rhs of the last equation
                result[i] = matrix[i, dimension];

                for (int j = 0; j < dimension; j++)
                {
                    // Then subtract all the lhs values except the coefficient 
                    // of the variable whose value is being calculated
                    if (j != i)
                    {
                        result[i] -= matrix[i, j] * result[j];
                    }
                }

                // Now finally divide the rhs by the coefficient of 
                // the variable to be calculated
                result[i] /= matrix[i, i];
            }

            return result;
        }

        public void ShowMatrix(double [,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Debug.Write(matrix[i, j] + " ");
                }
                Debug.Write(Environment.NewLine);
            }
        }
    }
}
