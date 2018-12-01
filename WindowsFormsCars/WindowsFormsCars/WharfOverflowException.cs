using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    class WharfOverflowException : Exception
    {
        public WharfOverflowException() : base("На причале нет свободных мест")         
        { }
    }
}
