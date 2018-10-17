using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Pravokutnik : Lik
    {
        double a;
        double b;

        public Pravokutnik(double a, double b)
        {
            this.a = a;
            this.b = b;

        }
        public override void IspisImena()
        {
            Console.WriteLine("Pravokutnik {0} i {1}", a, b);
        }

        public override double Opseg()
        {
            return 2* a + 2 * b;
        }

        public override double Povrsina()
        {
            return a * b;
        }
    }
}
