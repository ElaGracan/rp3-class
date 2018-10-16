using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    public class Osoba
    {
        public string Ime;
        public string Prezime;
        public int Starost;
        public string Spol;
        public string Zanimanje;

        private DateTime VrijemeInstanciranja = DateTime.Now;

        public void IspisiDetalje()
        {
            Console.WriteLine("Objekt klase Osoba - detalji:");
            Console.WriteLine(
                "Ime: " + Ime + "\n" +
                "Prezime: " + Prezime + "\n" +
                "Starost: " + Starost + "\n" +
                "Spol: " + Spol + "\n" +
                "Zanimanje: " + Zanimanje + "\n" +
                "Vrijeme instanciranja: " + VrijemeInstanciranja.ToLongTimeString() + "\n"
                );
        }

        //    static int broj;
        static List<Osoba> lo = new List<Osoba>();
        public Osoba() { lo.Add(this); }
        public Osoba(string ime, string prezime) : this() { Ime = ime; Prezime = prezime; }

        public static void IspisiSveOsobe()
        {
            foreach (Osoba o in lo)
                o.IspisiDetalje();
        }

        public virtual void Ispisi()
        {
            Console.WriteLine("Ime: {0}, Prezime: {1}", Ime, Prezime)
        }
    }
}
