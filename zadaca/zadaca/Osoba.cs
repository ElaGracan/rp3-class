using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca
{
    class Osoba:IComparable<Osoba>
    {
        internal string ime;
        public string prezime;
        internal Fejs f;
        internal List<Osoba> listaprijatelji;
        internal bool flag;
        //Napišite klasu Osoba, koja ima ime i prezime, te privatni konstruktor.


        private Osoba(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
            listaprijatelji = new List<Osoba>();
            f = new Fejs("");
            flag = false;
                   
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
            provjera();
            return listaprijatelji.Count;

        }

        public List<Osoba> prijatelji()
        {
            provjera();
            return listaprijatelji;

        }

       
        public static Osoba operator +(Osoba a, Osoba b)
        {
            if (a.f.Equals(b.f))
            {
                a.provjera();
                b.provjera();
                a.listaprijatelji.Add(b);


                b.listaprijatelji.Add(a);
                return a;
            }
            else throw new InvalidOperationException("Osobe " + a.ToString() + " i " +b.ToString() + " nisu na istom fejsu");
        }

        //Napišite i operatore += pomoću kojeg sprijateljimo dvije osobe, te -= s kojim ih posvađamo.
        public static Osoba operator -(Osoba a, Osoba b) //Ukoliko je neka osoba ostala bez prijatelja, treba ju izbaciti s fejsa.
        {
            a.provjera();
            b.provjera();
            a.listaprijatelji.Remove(b);
            b.listaprijatelji.Remove(a);
            if (a.listaprijatelji.Count == 0)
            {
                a.f.izbaci(a);
                a.flag = true;
            }

            if (b.listaprijatelji.Count == 0)
            {
                b.f.izbaci(b);
                b.flag = true;
            }
                
            return a;
        }

        public override string ToString()
        {
            provjera();
            return ime + " " + prezime + ", broj prijatelja: " + brojPrijatelja().ToString(); 
        }

        public void ispisi()
        {
            provjera();
            Console.WriteLine(this.ToString());


            if (listaprijatelji != null)
            {
                Console.WriteLine("****************************");
                Console.WriteLine("Lista prijatelja:\n");
                foreach(Osoba o in listaprijatelji)
                    Console.WriteLine("{0}\n", o.ToString());
                Console.WriteLine("****************************");
            }
        }

        //Ukoliko koristimo izbačenu osobu, treba generirati iznimku.
        void provjera()
        {
            if(this.flag)
               throw new InvalidOperationException("Osobu nije moguće koristiti jer je izbacena s fejsa");
        }

       // te u sortiranju(sortirati osobe po broju prijatleja, pa po prezimenu, pa po imenu).

        public int CompareTo(Osoba o)
        {
            int rez = this.brojPrijatelja().CompareTo(o.brojPrijatelja());
            if (rez == 0)
                rez = this.prezime.CompareTo(o.prezime);
            if (rez == 0)
                rez = this.ime.CompareTo(o.ime);
            return rez;
        }

        public bool Equals(Osoba other)
        {
            if (other == null) return false;
            return (ime.Equals(other.ime) && prezime.Equals(other.prezime));
        }

        public override int GetHashCode()
        {
            return ime.GetHashCode() + prezime.GetHashCode();
        }

        
    }
}
