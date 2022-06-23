using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Exceptions
{
    public class ReadingFileException : Exception
    {
        public ReadingFileException() 
            : base(ErrorMessages.ElementoExistenteByName)
        {
        }

        public ReadingFileException(string message)
            : base(message)
        {
        }

    }
}
