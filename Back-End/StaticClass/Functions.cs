using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    public static class Functions
    {
        public static string GetErrorMessage(Exception ex)
        {
            string ret = "";

            if (ex.InnerException != null)
                ret = GetErrorMessage(ex.InnerException);
            else
                ret = ex.Message;

            return ret;
        }
    }
}
