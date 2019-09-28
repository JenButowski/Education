using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace L11_T2
{
    static class GaussMethod
    {
        public static void MainMethod(double [,] coefficients)
        {
            double s = 0;
            int n = 3;
            double[,] privatecpefficients = GetPrivateCoefficcients(coefficients);
            double[] b = GetPublicCoefficcients(coefficients);
            double[] x = new double[n];          

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        privatecpefficients[i, j] = privatecpefficients[i, j] - privatecpefficients[k, j] * (privatecpefficients[i, k] / privatecpefficients[k, k]);
                    }
                    b[i] = b[i] - b[k] * privatecpefficients[i, k] / privatecpefficients[k, k];
                }
            }
            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < n; j++)
                    s = s + privatecpefficients[k, j] * x[j];
                x[k] = (b[k] - s) / privatecpefficients[k, k];
            }

            MessageBox.Show($"X{x[0]} Y{x[1]} Z{x[2]}");
        }

        private static double[,] GetPrivateCoefficcients(double [,] coefficients)
        {
            var result = new double[3, 3];

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    result[i, j] = coefficients[i, j];
                }
            }

            return result;
        }

        private static double[] GetPublicCoefficcients(double[,] coefficients)
        {
            var result = new List<double>();
            var counter = 1;

            foreach(var element in coefficients)
            {
                if (counter % 4 == 0)
                    result.Add(element);
                counter++;
            }

            return result.ToArray();
        }
    }
}
