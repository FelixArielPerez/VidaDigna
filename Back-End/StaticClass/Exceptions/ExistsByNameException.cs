using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Exceptions
{
    public class ExistsByNameException : Exception
    {
        public ExistsByNameException() 
            : base(ErrorMessages.ElementoExistenteByName)
        {
        }

        public ExistsByNameException(string message)
            : base(message)
        {
        }

    }
}
