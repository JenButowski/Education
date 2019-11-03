using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11_T3
{
    class SquareMatrix
    {
        private static int counter = 0;

        public int N { get; set; }

        public double [,]  MatrixView { get; set; }

        public string MatrixName { get; set; }

        public SquareMatrix(int n, string matrixName = "defaultName_")
        {
            this.N = n;
            this.MatrixView = new double[n, n];
            this.MatrixName = MatrixName + counter;
            counter++;
        }

        public SquareMatrix(double [,] matrix, string matrixName = "defaultName_")
        {
            this.N = matrix.Length / matrix.GetLength(0);
            this.MatrixView = matrix;
            this.MatrixName = MatrixName + counter;
            counter++;
        }
    }
}
