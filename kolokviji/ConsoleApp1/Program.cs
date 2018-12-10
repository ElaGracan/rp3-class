using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokviji
{
    class A
    {
        public A() { Console.WriteLine("A "); }
        public A(int x) { Console.WriteLine("A{0}", x); }

        static A() { Console.WriteLine("sA "); }
    }
    class B
    {
        A a = new A(1);
        public B() { Console.WriteLine("B "); }
        
    }

    class C:B
    {
        A a = new A(2);
        B b = new B();
        public C() { a = new A(3); Console.WriteLine("C "); }

    }

    class D : C
    {
        A a = new A(4);
        
        public D() {  Console.WriteLine("D "); }
        static D() { Console.WriteLine("sD "); }
    }
    class Program
    {
        static void Main(string[] args)
        {

            D d = new D();
            // zad1_2015();
            //kol2_2015();
            // kol3_2015();

            //zad2_uteg();

            //primjer_sucelje_struktura();
            //palindrom();
        }
        public static void palindrom()
        {
            string s = Console.ReadLine();
            List<string> palin = new List<string>();
            int i = 0, j = s.Length;
            while (i < s.Length)
            {
                j = s.Length - i;
                while (j >= 1)
                {
                    string ss = s.Substring(i, j);
                    Console.WriteLine(ss);
                    if (IsPalindrom(ss) && !palin.Contains(ss))
                        palin.Add(ss);

                    j--;
                }
                i++;
            }

            Console.WriteLine(string.Join(", ", palin));
        }

        public static bool IsPalindrom(string s)
        {
            int min = 0, max = s.Length - 1;
            bool p = true;
            while(min<=max)
            {
                if (s[min] != s[max])
                {
                    p = false;
                    break;
                }
                    
                min++;
                max--;
            }
            return p;

        }

        public static void primjer_sucelje_struktura()
        {
            test ts = new test();
            ts.Status = 0;
            Console.WriteLine(ts.Status);

            ts.Status = 1;
            Console.WriteLine(ts.Status);

            IPohranjivo ip = ts;
            ip.Status = 2;

            Console.WriteLine("ts: {0}, ip: {1}", ts.Status, ip.Status);

            ts.Status = 3;
            Console.WriteLine("ts: {0}, ip: {1}", ts.Status, ip.Status);

        }

        public static void zad2_uteg()
        {
            KruzniUteg kr = new KruzniUteg(0.5, 10, 0.1);
            CetvrtastiUteg cu = new CetvrtastiUteg(1, 10, 0.1);

            KruzniUteg kr2 = new KruzniUteg(0.5, 10, 0.1);
            CetvrtastiUteg cu2 = new CetvrtastiUteg(1, 10, 0.1);

            Sipka s = new Sipka();
            s.DodajDesno(kr);
            s.DodajDesno(cu2);
            s.DodajLijevo(cu);
            s.DodajLijevo(kr2);

            if (s.istaMasa()) Console.WriteLine("Utezi imaju istu masu");
            else Console.WriteLine("Utezi nemaju istu masu");

            if (s.istaVisina()) Console.WriteLine("Utezi imaju istu visinu");
            else Console.WriteLine("Utezi nemaju istu visinu");
        }
        public static void zad1_2015()
        {
            string s = "";
            List<string> l1 = new List<string>();
            while(s != "kraj")
            {
                s = Console.ReadLine();
                if(s!="kraj") l1.Add(s);
            }

            s = "";

            SortedDictionary<string, int> l2 = new SortedDictionary<string, int>();
            List<string> nemanista = new List<string>();
            List<string> imanesto = new List<string>();
            while (s != "kraj")
            {
                s = Console.ReadLine();
                if (s != "kraj") l2.Add(s, 0);
            }

            int i = 0;
            int flag = 0;
            foreach (string ss in l1)
            {
                flag = 0;
                foreach (string sss in l2.Keys.ToList())
                {
                    i = 0;
                    foreach (char c in sss)
                    {

                        if (ss.Substring(i).IndexOf(c) >= i)
                            i = ss.Substring(i).IndexOf(c) ;
                        else { i = -1; break; }
                    }

                    if (i >= 0)
                    {
                        l2[sss] += 1;
                        flag = 1;
                    }
                    
                }

                if (flag == 1) imanesto.Add(ss);
                else nemanista.Add(ss);

            }

            Console.WriteLine(String.Join(", ", imanesto).ToString());
            Console.WriteLine(String.Join(", ", nemanista).ToString());
            Console.WriteLine(String.Join("\n", l2.OrderBy(v => v.Value)).ToString());

        }
        static void kol2_2015()
        {
            velikibroj b = new velikibroj("1234567890");
            velikibroj b1 = new velikibroj(1234567890);
            Console.WriteLine(String.Join("",b.broj));
            //  Console.WriteLine(b1);

            b += b1;

            Console.WriteLine(b[3].ToString());

            foreach(int z in b)
            {
                Console.WriteLine(z);
            }

        }

        //static void f1(A a)
        //{
        //    --a.x;
        //}
        //static void f1(ref A a)
        //{
        //    --a.x;
        //}
        //static void f2(A a)
        //{
        //    ++a.x; a = new A(); a.x = 10; --a.x;//pazi
        //}
        //static void f2(ref A a)
        //{
        //    ++a.x; a = new A(); a.x = 20; --a.x;
        //}
        //static void kol3_2015()
        //{
        //    A x = new A();
        //    x.x = 0;
        //    f1(x); Console.WriteLine(x.x);
        //    f1(ref x); Console.WriteLine(x.x);
        //    f2(x); Console.WriteLine(x.x);
        //    f2(ref x); Console.WriteLine(x.x);

        //}
    }
}
