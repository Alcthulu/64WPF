using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64WPF.Model
{
    public class ChipForCollection
    {
        public string Valor { get; set; }
        public string Fila { get; set; }
        public string Columna { get; set; }

        public ChipForCollection(int v, int f, int c)
        {
            Valor = v.ToString();
            Fila = f.ToString();
            Columna = c.ToString();
        }


    }
}
