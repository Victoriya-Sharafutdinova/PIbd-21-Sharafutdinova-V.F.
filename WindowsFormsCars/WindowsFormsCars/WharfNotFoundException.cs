using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    class WharfNotFoundException : Exception
    {
        public WharfNotFoundException(int i) : base("Не найден корабль по месту " + i)         
        { }
    }
}
