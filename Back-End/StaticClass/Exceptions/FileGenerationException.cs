using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Exceptions
{
    public class FileGenerationException : Exception
    {
        public FileGenerationException() 
            : base(ErrorMessages.ElementoExistenteByName)
        {
        }

        public FileGenerationException(string message)
            : base(message)
        {
        }

    }
}
