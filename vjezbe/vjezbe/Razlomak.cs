using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Razlomak
    {
        int m_p, m_q;
        static int gcd(int a, int b)
        {
            while (b > 0)
            {
                int t = b; b = a % b; a = t;
            }
            return a;
        }
        void skratiMe()
        {
            if (m_q < 0) { m_q = -m_q; m_p = -m_p; }
            int g = gcd(m_p, m_q);
            if (g > 1) { m_p /= g; m_q /= g; }
        }

        public Razlomak(int p, int q)
        {
            m_p = p; m_q = q; skratiMe();

        }
        public int Brojnik
        {
            get { return m_p; }
            set { m_p = value; skratiMe(); }
        }
        public int Nazivnik
        {
            get { return m_q; }
            set { if (m_q == 0) throw new Exception(); m_q = value; skratiMe(); }
        }
        public static Razlomak operator +(Razlomak a, Razlomak b)
        {
            return new Razlomak(a.m_p * b.m_q + b.m_p * a.m_q, a.m_q * b.m_q);
        }
        public override string ToString()
        {
            return m_p.ToString() + "/" + m_q.ToString();
            //return base.ToString();
        }
        /*public static implicit operator double(Razlomak c)
        {
            return (double)c.m_p / c.m_q;
        }*/
        public static explicit operator double(Razlomak c)
        {
            return (double)c.m_p / c.m_q;
        }
    }
}
