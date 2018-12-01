using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca
{
    class Fejs
    {
        List<Osoba> osobe;
        string ime;
        //Napišite klasu Fejs koja predstavlja skupinu Osoba.
        
        //Možete pretpostaviti da neće biti dvije osobe s istim imenom i prezimenom.

        public Fejs(string ime)
        {
            this.ime = ime;
        }

        //Osobe dodajemo funkcijom dodaj koja kao parametar prima ime i prezime osobe.
        internal Osoba dodaj(string ime, string prezime)
        {
            Console.WriteLine(this.ToString());
            Osoba o = Osoba.kreiraj(ime, prezime, this);
            if (osobe == null)
                osobe = new List<Osoba>();
            
            osobe.Add(o);
        
            return o;
        }

        //Napišite i funkciju izbaci kojom izbacujemo određenu osobu s fejsa.
        public void izbaci(Osoba o)//(string ime, string prezime)
        {
            osobe.Remove(o);// (osobe.Single(r => r.ime == ime && r.prezime == prezime));
            foreach (Osoba ooo in osobe)
                ooo.listaprijatelji.Remove(o);
        }

        //Napišite i funkciju medjuPrijatelji, koja će vratiti skup svih međuprijatelja između dvije osobe.
        public List<Osoba> medjuPrijatelji(Osoba a, Osoba b)
        {
            List<Osoba> mp = new List<Osoba>();
            foreach (Osoba prijateljA in a.listaprijatelji)
                foreach (Osoba prijateljB in a.listaprijatelji)
                    if (prijateljA == prijateljB)
                    {
                        mp.Add(prijateljA);

                    }
            return mp;
        }

        public override string ToString()
        {
            return ime;
        }

        
    }
}
