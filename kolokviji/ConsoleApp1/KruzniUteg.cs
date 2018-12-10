using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokviji
{
    class KruzniUteg:IUteg
    {
        double radijus;

        public double Sirina { get; set; }

        public double Gustoca { get; set; }

        public KruzniUteg(double r, double g, double s)
        {
            radijus = r;
            Gustoca = g;
            Sirina = s;
        }

        public double masa()
        {
            return Sirina * Math.Pow(radijus, 2) * Math.PI*Gustoca;
        }

        public double visina()
        {
            return 2* radijus;
        }
    }
}
