using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Krug : Lik
    {
        double r;
        

        public Krug(double r)
        {
            this.r = r;
            
        }
        public override void IspisImena()
        {
            Console.WriteLine("Krug radijusa {0}", r);
        }

        public override double Opseg()
        {
            return 2*r*Math.PI;
        }

        public override double Povrsina()
        {
            return Math.Pow(r,2)*Math.PI;
        }
    }
}
