using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokviji
{
    class CetvrtastiUteg : IUteg
    {
        

        public double Sirina { get; set; }

        public double Stranica { get; set; }

        public double Gustoca { get; set; }

        public CetvrtastiUteg(double a, double g, double s)
        {
            Stranica = a;
            Gustoca = g;
            Sirina = s;
        }

        public double masa()
        {
            return Sirina * Math.Pow(Stranica, 2) * Gustoca;
        }

        public double visina()
        {
            return Stranica;
        }
    }
}
