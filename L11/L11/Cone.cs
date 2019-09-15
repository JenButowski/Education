using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11
{
    class Cone
    {
        public double Hight { get; }

        public double Radius { get; }

        public double Density { get; set; }

        public Cone (double hight, double radius, double density)
        {
            this.Hight = hight;
            this.Radius = radius;
            this.Density = density;
        }

        public double GetVolume()
        {
            return (1.0 / 3) * Math.PI * Math.Pow(Radius, 2) * Hight;
        }

        public double GetMass()
        {
            return Density * GetVolume();
        }
    }
}
