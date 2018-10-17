using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Student:Osoba
    {
        public string JMBAG;

        public Student(string ime, string prezime, string jmbag)
            :base(ime, prezime)
        { JMBAG = jmbag; }

        public Student(string ime="Netko")
            :this(ime, "Netković", "1191227179") { }

        public override void Ispisi()
        {
            
            Console.WriteLine("{0} {1} {2}",Ime, Prezime, JMBAG);

        }

    }
}
