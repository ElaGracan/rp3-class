using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class PravokutniTrokut:Lik
    {
        double a;
        double b;

        public PravokutniTrokut(double a, double b )
        {
            this.a = a;
            this.b = b;
                
        }
        public override void IspisImena()
        {
            Console.WriteLine("Pravokutni trokut sa stranicama {0} i {1}", a, b);
        }

        public override double Opseg()
        {
            return a + b + Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b,2));
        }

        public override double Povrsina()
        {
            return a * b / 2;
        }
    }
}
