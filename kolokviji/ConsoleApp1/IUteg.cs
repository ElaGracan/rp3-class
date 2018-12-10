using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokviji
{
    interface IUteg
    {
        double Sirina { get; set; }
        double Gustoca { get; set; }

        double masa();
        double visina();
    }
}
