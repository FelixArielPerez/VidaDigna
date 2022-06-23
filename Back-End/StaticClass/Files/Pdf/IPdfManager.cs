using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Files.Pdf
{
    public interface IPdfManager: IFileManager
    {
        byte[] Generate<T>(string title, string subtitle, IEnumerable<T> source) where T : class;
    }
}
