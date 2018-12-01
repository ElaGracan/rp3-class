using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadaca

   
    // Napravite operator indeksiranja, te omogućite da je klasu moguće koristiti u foreach iskazima, te u sortiranju (sortirati osobe po broju prijatleja, pa po prezimenu, pa po imenu).

    //Operator indeksiranja treba vratiti skup svih osoba kojima je prezime jednako indeksu.Na takvom skupu treba biti moguće koristiti indeksiranje, koje će kao indeks koristiti ime osobe.

    

    


    
    //Ukoliko koristimo izbačenu osobu, treba generirati iznimku.

    //Sami osmislite klase i napišite main koji demonstrira njihovu upotrebu.


{
    class Program
    {
        static void Main(string[] args)
        {

            //kreiraj dva fejsa

            Fejs f1 = new Fejs("prvi fejs");
            Fejs f2 = new Fejs("drugi fejs");

            Console.WriteLine(f1.ToString());
            Osoba o11 = f1.dodaj("Ela", "Gracan");
            Osoba o12 = Osoba.kreiraj("Petar", "Talijic", f1);

            //o11 += o12;
            o12.ispisi();
        }
    }
}
