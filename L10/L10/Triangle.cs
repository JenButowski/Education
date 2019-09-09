using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10
{
    internal class Triangle
    {
        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static int CalculatePerimeter(Triangle triangle)
        {
            try
            {
                if (triangle.A <= 0 || triangle.B <= 0 || triangle.C <= 0)
                    throw new L10.Exceptions.ZeroException();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return triangle.A + triangle.B + triangle.C;
        }
    }
}
