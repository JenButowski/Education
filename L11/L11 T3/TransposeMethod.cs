using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_T3
{
    class TransposeMethod
    {
        public static SquareMatrix Transpose(SquareMatrix matrix)
        {
            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = i + 1; j < matrix.N; j++)
                {
                    var value = matrix.MatrixView[i,j];
                    matrix.MatrixView[i,j] = matrix.MatrixView[j,i];
                    matrix.MatrixView[j,i] = value;
                }
            }

            return matrix;
        }
    }
}
