using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class VelikiBroj
    {
        public int[] nizBrojeva;
        
        public VelikiBroj(string niz)
        {
            this.nizBrojeva = new int[niz.Length];
            for(int i = 0; i< niz.Length; i++)
            {
                this.nizBrojeva[niz.Length - i - 1] = niz[i] - 48;
            }
        }
        /*public static VelikiBroj operator +(VelikiBroj a, VelikiBroj b)
        {
            int l = a.nizBrojeva.Length;
            if (b.nizBrojeva.Length > l) l = b.nizBrojeva.Length;
            int carry = 0;

            int[] rezultat = new int[l + 1];
            //VelikiBroj rezultat = new VelikiBroj();

        }
        public static VelikiBroj operator -(VelikiBroj)
        {

        }*/
    }
}
