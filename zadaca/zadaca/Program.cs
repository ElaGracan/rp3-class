using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca


//Sami osmislite klase i napišite main koji demonstrira njihovu upotrebu.


{
    class Program
    {
        static void Main(string[] args)
        {

            //kreiraj dva fejsa

            Fejs f1 = new Fejs("prvi fejs");
            Fejs f2 = new Fejs("drugi fejs");


            Osoba o11 = f1.dodaj("Ela", "Gracan");
            Osoba o12 = f1.dodaj("Petar", "Talijic");
            Osoba o13 = f1.dodaj("Sandra", "Gracan");
            Osoba o14 = f1.dodaj("Iva", "Talijic");
            Osoba o15 = f1.dodaj("Vido", "Talijic");
            Osoba o16 = f1.dodaj("Marijana", "Talijic");
            Osoba o17 = f1.dodaj("Tomislav", "Gracan");
            Osoba o18 = f1.dodaj("Ena", "Gutic");
            Osoba o19 = f1.dodaj("Dino", "Komadina");
            Osoba o10 = f1.dodaj("Dora", "Segovic");

            Osoba o21 = f2.dodaj("Netko", "Nepoznat");


            o11 += o12;
            o13 += o15;
            o13 += o16;
            o18 += o19;

            o17 += o16;
            o10 += o17;
            o11.ispisi();

            try
            {
                o11 += o21;
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

            o11 -= o12;

            try
            {
                o11 += o12;
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }
            Console.WriteLine("****************************\n");

            f1.popisLjudi();
            

            try
            {
                SortedDictionary<string, Osoba> l1 = f1["Talijic"];
                Console.WriteLine("Indeksiranje po imenu: {0}", l1["Iva"].ToString());
                Console.WriteLine("****************************\n");
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

            Console.WriteLine("Ispis bez sortiranja:");
            Console.WriteLine("****************************");
            foreach (Osoba o in f1)
            {
                
                Console.WriteLine(o.ToString());
                Console.WriteLine();
            }
            
            Console.WriteLine("****************************");
            f1.Sort();


            Console.WriteLine("Ispis sa sortiranjem:");
            Console.WriteLine("****************************");

            foreach (Osoba o in f1)
            {
                
                
                Console.WriteLine(o.ToString());
                
                Console.WriteLine();
            }

            Console.WriteLine("****************************");

            try
            {
                o13 += o15;
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

            try
            {
                o13 -= o10;
            }
            catch (InvalidOperationException e) { Console.WriteLine(e.Message); }

            Osoba o1 = f1.dodaj("Marijana", "Talijic");
            Osoba o2 = f1.dodaj("Tomislav", "Gracan");

            //o1 += o2;
            Console.WriteLine("****************************\n");
            f1.funkcija_fejs();
            
                
        }

    }
}
