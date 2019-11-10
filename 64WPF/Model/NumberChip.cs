using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64WPF.Model
{
    public class NumberChip
    {
        int value;

        public NumberChip(int v)
        {
            value = v;
        }
        public void setValue(int v)
        {
            value = v;
        }
        public int getValue()
        {
            return value;
        }

        
    }
}
