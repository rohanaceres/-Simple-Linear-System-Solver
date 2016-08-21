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
            double[,] matrix = this.System.ToMatrix();

            this.ForwardElimination(matrix);

            double[] rawResult = this.BackSubstitution(matrix);

            return new LinearSystemResult
            {
                X = rawResult[0],
                Y = rawResult[1],
                Z = rawResult[2],
                Iterations = this.Dimension.Value
            };
        }
        /// <summary>
        /// Operations of getting the row pivot and Gauss Elimination.
        /// </summary>
        /// <param name="matrix">Matrix correspondant to the linear equation system.</param>
        protected virtual void ForwardElimination(double [,] matrix)
        {
            this.GetPivot(matrix);
            this.GaussElimination(matrix);
        }
        /// <summary>
        /// Solve the system using the row-echelon matrix.
        /// </summary>
        /// <param name="matrix">Row-echelon matrix.</param>
        /// <returns>Variables values.</returns>
        protected virtual double [] BackSubstitution(double [,] matrix)
        {
            double[] result = new double[this.Dimension.Value];

            // Equação de exemplo: 2x + 3y +4z = 22;
            for (int i = this.Dimension.Value - 1; i >= 0; i--)                
            {
                // Atribui o valor inicial do resultado igual à 
                // constante da equação atual:
                // Exemplo: result[i] = 22
                result[i] = matrix[i, this.Dimension.Value];

                for (int j = 0; j < this.Dimension; j++)
                {
                    // Subtrai do valor atual os outros elementos da equação:
                    // Exemplo: 2x = -3y -4z + 22
                    if (j != i)
                    {
                        result[i] -= matrix[i, j] * result[j];
                    }
                }
                
                // Divide o resultado das contas pelo coeficiente
                // da variável que está sendo calculada:
                // Exemplo: x = (-3y -4z + 22)/2
                result[i] /= matrix[i, i];
            }

            return result;
        }

        /// <summary>
        /// Get each matrix row pivot.
        /// Reorder the matrix if necessary.
        /// </summary>
        /// <param name="matrix">Matrix containing a system with linear equations.</param>
        private void GetPivot(double[,] matrix)
        {
            // Para cada linha, faça:
            for (int currentRow = 0; currentRow < this.Dimension; currentRow++)
            {
                // Para cada linha após a currentRow:
                for (int nextRow = currentRow + 1; nextRow < this.Dimension; nextRow++)
                {
                    // Se o elemento da diagonal for menor que o elemento 
                    // da linha de baixo, troca as linhas de posição (Swap):
                    if (matrix[currentRow, currentRow] < matrix[nextRow, currentRow])
                    {
                        this.Swap(matrix, currentRow, nextRow);
                    }
                }
            }
        }
        /// <summary>
        /// Eliminate another elements from the row of a pivot, because
        /// it is mandatory that the first non-zero element of a row should
        /// be 1. Moreover, this firsf element should be the only non-zero
        /// element in it's column.
        /// </summary>
        /// <param name="matrix">Matrix containing a system with linear equations.</param>
        /// <example>
        /// |1 0 0|
        /// |0 1 0|
        /// |0 0 1|
        /// </example>
        private void GaussElimination(double[,] matrix)
        {
            // Para cada linha:
            for (int currentRow = 0; currentRow < this.Dimension - 1; currentRow++)
            {
                // Para cada linha após a currentRow:
                for (int nextRow = currentRow + 1; nextRow < this.Dimension; nextRow++)
                {
                    double t = matrix[nextRow, currentRow] / matrix[currentRow, currentRow];

                    for (int j = 0; j <= this.Dimension; j++)
                    {
                        // Zera os elementos abaixo do pivot:
                        matrix[nextRow, j] -= t * matrix[currentRow, j];
                    }
                }
            }
        }
        /// <summary>
        /// Swap two rows of a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to swap rows.</param>
        /// <param name="firstRow">First row to swap.</param>
        /// <param name="secontRow">Second row to swap.</param>
        private void Swap(double [,] matrix, int firstRow, int secontRow)
        {
            for (int i = 0; i <= this.Dimension; i++)
            {
                double temp = matrix[firstRow, i];
                matrix[firstRow, i] = matrix[secontRow, i];
                matrix[secontRow, i] = temp;
            }
        }

        #region debug junk
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
        #endregion  
    }
}
