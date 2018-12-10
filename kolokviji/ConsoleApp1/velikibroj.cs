using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokviji
{
    class velikibroj:IEnumerable<int>
    {
        public int[] broj;

        public velikibroj(string b)
        {
            int i = 0;
            broj = new int[b.Length];
            foreach(char c in b)
            {
                Console.WriteLine("{0} {1}", c, (int)c - 48);
                broj[i] = ((int)c - 48);
                i++;
            }
        }
        public velikibroj(int b):this( b.ToString() )
        { }
       
        public static velikibroj operator +(velikibroj b1, velikibroj b2)
        {
            int pamti = 0;
            string rez = "" ;

            int[] p1 = new int[b1.broj.Length];
            int[] p2 = new int[b2.broj.Length];
            p1 = b1.broj;
            p2 = b2.broj;
            Array.Reverse(p1);
            Array.Reverse(p2);
            

            if (p1.Length > p2.Length)
            {
                for (int i = 0; i < p2.Length; i++)
                {
                    if (p1[i] + p2[i] + pamti >= 10)
                    {
                        
                        rez += (p1[i] + p2[i] + pamti) - 10;
                        pamti = 1;
                    }


                    else {  rez += (p1[i] + p2[i] + pamti); pamti = 0; }
                    
                }
                rez += p1[p2.Length] + pamti;
                for (int i = p2.Length+1; i < p1.Length; i++)
                {
                    rez += p1[i];
                }
            }
            else
            {
                if (p1.Length < p2.Length)
                {
                    for (int i = 0; i < p1.Length; i++)
                    {
                        if (p1[i] + p2[i] + pamti >= 10)
                        {
                            rez += (p1[i] + p2[i] + pamti) - 10;
                            pamti = 1;
                        }


                        else
                        {
                            
                            rez += (p1[i] + p2[i] + pamti);
                            pamti = 0;
                        }
                    }
                    rez += p2[p1.Length] + pamti;
                    for (int i = p1.Length + 1; i < p2.Length; i++)
                    {
                        rez += p2[i];
                    }
                }
                else
                {
                    
                    for (int i = 0; i < p2.Length; i++)
                    {
                        if (p1[i] + p2[i] + pamti >= 10)
                        {
                            
                            rez += (p1[i] + p2[i] + pamti) - 10;
                            pamti = 1;
                            
                        }

                        else
                        {
                            
                            rez += (p1[i] + p2[i] + pamti);
                            pamti = 0;
                            
                        }
                    }
                    if(pamti == 1)
                        rez += pamti;

                        
                    

                }

                

            }
            
            velikibroj b = new velikibroj(rez);
            Array.Reverse(b.broj);
            return b;

            

                
            
        }

        public override string ToString()
        {
            return String.Join("", broj).ToString();
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int b in broj)
                yield return b;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int this[int i]
        {
            get { return broj[i];  }
            set { broj[i] = value; }
        }

    }
}
