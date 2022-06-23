using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Exceptions
{
    public class ProcessingFileException : Exception
    {
        public ProcessingFileException() 
            : base(ErrorMessages.ElementoExistenteByName)
        {
        }

        public ProcessingFileException(string message)
            : base(message)
        {
        }

    }
}
