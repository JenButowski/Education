using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_T3
{
    class MatrixSum
    {
        public static SquareMatrix GetSum(SquareMatrix matrix_1, SquareMatrix matrix_2)
        {
            var result = new SquareMatrix(matrix_1.N);

            if(matrix_1.N == matrix_2.N)
            {
                for(int i = 0; i < matrix_1.N; i++)
                {
                    for(int j = 0; j < matrix_1.N; j++)
                    {
                        result.MatrixView[i, j] = matrix_1.MatrixView[i, j] + matrix_2.MatrixView[i, j];
                    }
                }
            }

            return result;
        }
    }
}
