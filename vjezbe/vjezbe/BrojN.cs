using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class brojN
    {
        int i, n;
        public brojN(int a, int b = 0) { i = a; n = b; } // mogao bih i ovdje raditi provjeru je li broj a u zadanom intervalu

        static int checkMod(brojN a, brojN b)
        {
            if (a.n == 0)
            {
                if (b.n == 0) throw new Exception();
                else return b.n;
            }
            else
            {
                if (b.n == 0 || b.n == a.n) return a.n;
                throw new Exception();
            }
        }

        public static brojN operator +(brojN a, brojN b)
        {
            int m = checkMod(a, b);
            return new brojN((a.i + b.i) % m, m);
        }
        public static brojN operator -(brojN a, brojN b)
        {
            int m = checkMod(a, b);
            return new brojN((a.i + m - b.i) % m, m);
        }
        public static brojN operator *(brojN a, brojN b)
        {
            int m = checkMod(a, b);
            return new brojN((a.i * b.i) % m, m);
        }

        public static brojN operator /(brojN a, brojN b)
        {
            int m = checkMod(a, b);
            for (int i = 0; i < m; ++i)
                if (i * b.i % m == a.i) return new brojN(i, m);
            throw new DivideByZeroException();
            ///  ili koristeæi ovo, a*x=b, odnosno x = b/a
            ///  pa je dijeljenje ustvari rješavanje kongruencije
            ///  a za to imamo vrlo efikasan euklidov algoritam
        }

        public override string ToString()
        {
            return string.Format("{0} (mod {1})", i, n);
            //return base.ToString();
        }
        public static implicit operator brojN(int c)
        {
            return new brojN(c);
        }
    }
}
