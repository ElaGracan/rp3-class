using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Romb : Lik
    {
        protected double a;
        protected double h;
        public Romb(double a, double h)
        {
            this.a = a;
            this.h = h;
        }
        public override void IspisImena()
        {
            Console.WriteLine("Romb sa stranicom {0} i visinom {1}", a, h);
        }

        public override double Opseg()
        {
            return 4 * a;
        }

        public override double Povrsina()
        {
            return a * h;
        }
    }
}
