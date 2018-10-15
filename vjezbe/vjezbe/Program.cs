using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Program
    {
        static void Main(string[] args)
        {
            vjezbe1();

            vjezbe2();

            vjezbe3();
        }

        static void vjezbe3()
        {

        }

        static void vjezbe2()
        {
            Osoba o = new Osoba();
            o.Ime = "Marko";
            o.Prezime = "Markovic";
            Osoba o1 = new Osoba() { Ime = "jkjk", Prezime = "ii" };
            Osoba o2 = new Osoba("111", "222");
            //o1.IspisiDetalje();
            Osoba.IspisiSveOsobe();

            //zad 2
            brojN a = new brojN(7, 17), b = new brojN(13, 17);
            b += b; Console.WriteLine(b);
            a = a - b; Console.WriteLine(a);
            //a += new brojN(5);
            a += 5;

            Console.WriteLine(a);
            a *= b;
            Console.WriteLine(a);

            a /= b;
            Console.WriteLine(a);
        }
        static void vjezbe1()
        {
            //Console.WriteLine("hello");
            NajmanjiProstVeci(12);

            Console.WriteLine(pal("nekarijec"));
        }

        

        public static bool isProst(int broj)
        {
            if (broj < 2) return false;
            //for (int i = 2; i <= Math.Sqrt(broj); ++i)
            for (int i = 2; i * i <= broj; ++i)
                if (broj % i == 0) return false;
            return true;
        }
        static void NajmanjiProstVeci(int n)
        {
            int br = n + 1;
            while(!isProst(br))
            { br++; }
            Console.WriteLine(br);
            
        }
        static string pal(string s)
        {
            string ret = s;
            foreach (char c in s.Reverse())
                ret += c;
            return ret;
            //return s + string.Join("", s.Reverse());
        }
    }
}
