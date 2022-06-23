using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Files.Csv
{
    public interface ICsvManager : IFileManager
    {
        byte[] Generate<T>(IEnumerable<T> source) where T: class;
    }
}
