using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    class WharfOccupiedPlaceException : Exception
    {
        public WharfOccupiedPlaceException(int i) : base("На месте " + i + " уже стоит корабль")         
        { }
    }
}
