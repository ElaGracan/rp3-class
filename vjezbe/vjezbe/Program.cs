using System;
using System.Linq;
using System.Threading;

namespace vjezbe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vjezbe1();
            //Vjezbe2();
            //Vjezbe3();
            //Vjezbe4();
            Vjezbe5();
        }

        static void Vjezbe5()
        {
           /* Thread[] threads = new Thread[10];
            Account acc = new Account(1000); // zajednicki objekt za threadove
            for (int i = 0; i < 10; i++)
                threads[i] = new Thread(new ThreadStart(acc.DoTransactions));
            for (int i = 0; i < 10; i++) threads[i].Start();
            for (int i = 0; i < 10; ++i) threads[i].Join();
            Console.ReadKey();*/


            Thread[] threads = new Thread[10];
            Account acc = new Account(); // acc će biti zajednički objekt
            for (int i = 0; i < 2; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.Radi));
                t.Name = i.ToString();
                threads[i] = t;
            }
            for (int i = 0; i < 2; i++)
            {
                threads[i].Start();
            }
            Console.WriteLine("threadovi zapoceli");
            acc.a.Set();
            Thread.Sleep(100);
            acc.a.Set();
            acc.a.Reset();
        }
    

        static void Vjezbe4()
        {
            Matrica m = new Matrica(2, 3);
           // m[]
            m.Ispisi();
        }
        static void Vjezbe3()
        {
            Pravokutnik p = new Pravokutnik(3, 4);
            PravokutniTrokut pt = new PravokutniTrokut(3, 4);
            Krug k = new Krug(1);
            Romb r = new Romb(2, 1);

            k.IspisImena();
            Console.WriteLine("opseg = {0}, povrsina = {1}", k.Opseg(), k.Povrsina());

            p.IspisImena();
            Console.WriteLine("opseg = {0}, povrsina = {1}", p.Opseg(), p.Povrsina());

            pt.IspisImena();
            Console.WriteLine("opseg = {0}, povrsina = {1}", pt.Opseg(), pt.Povrsina());

            r.IspisImena();
            Console.WriteLine("opseg = {0}, povrsina = {1}", r.Opseg(), r.Povrsina());
        }

        static void Vjezbe2()
        {
            Osoba o = new Student();
            o.Ime = "Marko";
            o.Prezime = "Markovic";
            Osoba o1 = new Profesor() { Ime = "jkjk", Prezime = "ii" };
            Osoba o2 = new Student("111", "222", "eofokepof");
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
        static void Vjezbe1()
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
