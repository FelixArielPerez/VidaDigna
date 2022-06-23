using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Exceptions
{
    public class PriceApplingException : Exception
    {
        public PriceApplingException() 
            : base(ErrorMessages.ElementoExistenteByName)
        {
        }

        public PriceApplingException(string message)
            : base(message)
        {
        }

    }
}
