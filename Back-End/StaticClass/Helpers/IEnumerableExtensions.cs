using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Map<T>(this IEnumerable<T> source, Func<T, T> function)
        {
            foreach (var item in source)
            {
                yield return function(item);
            }
        }
    }
}
