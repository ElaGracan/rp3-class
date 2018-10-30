using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class Matrica
    {
        public int dim1;
        public int dim2;
        public int[,] vrijednosti;

        public Matrica(int dim1, int dim2)
        {
            this.dim1 = dim1;
            this.dim2 = dim2;
            this.vrijednosti = new int[dim1, dim2];
            for(int i = 0; i<dim1; i++)
            {
                for(int j =0;j<dim2;j++)
                {
                    vrijednosti[i, j] = 0;
                }
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= vrijednosti.GetLength(0) || j < 0 || j >= vrijednosti.GetLength(1)) throw new Exception("neka poruka");
                return vrijednosti[i, j];
            }
            set
            {
                if (i < 0 || i >= vrijednosti.GetLength(0) || j < 0 || j >= vrijednosti.GetLength(1)) throw new Exception("neka poruka");
                vrijednosti[i, j] = value;
            }
        }
        public void Ispisi()
        {
            
            for(int i = 0;i<dim1;i++)
            {
                for (int j = 0; j < dim2; j++)
                    Console.Write("{0} ", vrijednosti[dim1, dim2]);
            }
            Console.WriteLine();
        }
    }
}
