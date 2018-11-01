using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vjezbe
{
    class D:IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Dispose");
            GC.SuppressFinalize(this); // da GC više ne vodi brigu
        }
    }
}
