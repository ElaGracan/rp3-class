using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokviji
{
    
    class Sipka
    {
        List<IUteg> desno;
        List<IUteg> lijevo;

        public Sipka()
        {
            desno = new List<IUteg>();
            lijevo = new List<IUteg>();
        }

        public void DodajDesno(IUteg u)
        {
            desno.Add(u);
        }

        public void DodajLijevo(IUteg u)
        {
            lijevo.Add(u);
        }

        public bool istaMasa()
        {
            double sum1 = 0, sum2 = 0;
            foreach (IUteg u in desno)
                sum1 += u.masa();
            foreach (IUteg u in lijevo)
                sum2 += u.masa();

            if (sum1 == sum2)
                return true;
            else return false;
        }

        public bool istaVisina()
        {
            double max1 = 0, max2 = 0;
            foreach (IUteg u in desno)
                if (max1 > u.visina()) max1 = u.visina();
                
            foreach (IUteg u in lijevo)
                if (max2 > u.visina()) max2 = u.visina();
                

            if (max1 == max2)
                return true;
            else return false;
        }
    }
}
