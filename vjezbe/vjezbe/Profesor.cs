using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Profesor:Osoba
    {
        public override void Ispisi()
        {
            Console.Write("prof. ");
            base.Ispisi();
        }
    }
}
