using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca
{
    class Osoba
    {
        internal string ime;
        internal string prezime;
        internal Fejs f;
        internal List<Osoba> listaprijatelji;
        //Napišite klasu Osoba, koja ima ime i prezime, te privatni konstruktor.


        private Osoba(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
                   
        }

        internal static Osoba kreiraj(string ime, string prezime, Fejs fejs)
        {
            Osoba o = new Osoba(ime, prezime);
            o.f = fejs;
            return o;
        }

        //Na klasi osoba napišite funkcije brojPrijatelja, te prijatelji, koja će vratiti skup svih prijatelja određene osobe. 
        public int brojPrijatelja()
        {
            if (listaprijatelji != null)

                return listaprijatelji.Count;

            else
                return 0;
        }

        public List<Osoba> prijatelji()
        {
            

                return listaprijatelji;

            

        }

        

        //mozda ovdje, mozda u fejsu
        public static Osoba operator +(Osoba a, Osoba b)
        {
            a.listaprijatelji.Add(b);
            b.listaprijatelji.Add(a);
            return a;
        }

        //Napišite i operatore += pomoću kojeg sprijateljimo dvije osobe, te -= s kojim ih posvađamo.
        public static Osoba operator -(Osoba a, Osoba b) //Ukoliko je neka osoba ostala bez prijatelja, treba ju izbaciti s fejsa.
        {
            a.listaprijatelji.Remove(b);
            if (a.listaprijatelji.Count == 0)
                a.f.izbaci(a);

            b.listaprijatelji.Remove(a);
            if (b.listaprijatelji.Count == 0)
                b.f.izbaci(a);
            return a;
        }

        public override string ToString()
        {
            return "fejs: " + f.ToString() + "\nime: " + ime + "\nprezime: " + prezime + "\nbrojPrijatelja: " + brojPrijatelja().ToString(); 
        }

        public void ispisi()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("****************************");
            Console.WriteLine("Lista prijatelja:");
            if(listaprijatelji != null)
                foreach (Osoba o in listaprijatelji)
                    Console.WriteLine(o.ToString());
        }
    }
}
