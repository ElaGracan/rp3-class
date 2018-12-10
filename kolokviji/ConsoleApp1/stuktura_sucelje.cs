using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokviji
{
    interface IPohranjivo
    {
        void Citaj();
        int Status { get; set; }
    }
    public struct test:IPohranjivo
    {
        public void Citaj()
        {
            Console.WriteLine("Citaj");
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
