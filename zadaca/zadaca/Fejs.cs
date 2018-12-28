using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca
{
    class Fejs:IEnumerable<Osoba>, IComparer<Osoba>, IComparable<Fejs>
    {
        List<Osoba> osobe;
        string ime;
        //Napišite klasu Fejs koja predstavlja skupinu Osoba.
        
        //Možete pretpostaviti da neće biti dvije osobe s istim imenom i prezimenom.

        public Fejs(string ime)
        {
            this.ime = ime;
            osobe = new List<Osoba>();
        }

        // Napravite operator indeksiranja
        public SortedDictionary<string, Osoba> this[string prezime]
        {
            get
            {
                SortedDictionary<string, Osoba> l = new SortedDictionary<string, Osoba>();
                foreach (Osoba o in osobe)
                    if (o.prezime == prezime)
                        l.Add(o.ime, o);
                return l;
            }

            set
            {

            }
        }


        //te omogućite da je klasu moguće koristiti u foreach iskazima
        public IEnumerator<Osoba> GetEnumerator()
        {
            foreach(Osoba o in this.osobe)
            {
                yield return o;
            }
        }
        

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       



        //Osobe dodajemo funkcijom dodaj koja kao parametar prima ime i prezime osobe.
        internal Osoba dodaj(string ime, string prezime)
        {
            
            Osoba o = Osoba.kreiraj(ime, prezime, this);
                  
            osobe.Add(o);
        
            return o;
        }

        //Napišite i funkciju izbaci kojom izbacujemo određenu osobu s fejsa.
        internal void izbaci(Osoba o)//(string ime, string prezime)
        {
            osobe.Remove(o);
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

        public void popisLjudi()
        {
            Console.WriteLine("Osobe na fejsu {0}", this.ToString());
            foreach (Osoba o in osobe)
                Console.WriteLine("{0}\n", o.ToString());
        }

        public int Compare(Osoba x, Osoba y)
        {
            return x.CompareTo(y);
        }

        public void Sort()
        {
            osobe.Sort();
        }

        public int CompareTo(Fejs other)
        {
            return ime.CompareTo(other.ime);
        }

        public bool Equals(Fejs other)
        {
            if (other == null) return false;
            return ime.Equals(other.ime);
        }

        public override int GetHashCode()
        {
            return ime.GetHashCode();
        }

        public void funkcija_fejs()
        {
            
            foreach (Osoba o in osobe)
            {
                int i = 0;
                int j = 0;
                foreach (Osoba p in o.prijatelji())
                {
                    //Console.WriteLine("{0} {1}", i, j);
                    i += p.ime.Length;
                    j += p.prezime.Length;
                }
                if (i > j)
                    Console.WriteLine(o.ToString());



            }


                    
        }
    }
}
