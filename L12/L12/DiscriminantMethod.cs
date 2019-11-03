using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L12
{
    class DiscriminantMethod
    {
        public static (double x, double x2) GetDiscriminant(QuadraticEquation equation)
        {
            var D = Math.Pow(equation.B, 2) - 4 * equation.A * equation.C;
            var result = (x: 0.0, x2: 0.0);

            if (D > 0)
            {
                result.x = (-1 * equation.B + Math.Sqrt(D)) / 2 * equation.A;
                result.x2 = (-1 * equation.B - Math.Sqrt(D)) / 2 * equation.A;
            }
            else if (D == 0)
            {
                result.x = -1 * equation.B / 2 * equation.A;
                result.x2 = result.x;
            }
            else
                throw new Exception("Уравнение не имеет вещественных корней");
            
            return result;
        }
    }
}
