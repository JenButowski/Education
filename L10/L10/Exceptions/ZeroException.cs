using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10.Exceptions
{
    class ZeroException : Exception
    {
        public ZeroException(string message = "One of the parameters is 0") : base(message)
        { }
    }
}
