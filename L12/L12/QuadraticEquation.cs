using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L12
{
    class QuadraticEquation
    {
        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public string VariableName { get; set; }

        public QuadraticEquation(double A, double B, double C, string VariableName)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.VariableName = VariableName;
        }

        public override string ToString()
        {
            return $"{A}{VariableName}^2 + {B}{VariableName} + {C}";
        }
    }
}
