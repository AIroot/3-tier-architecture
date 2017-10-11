using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.Utils
{
    public static class ServicesExtentions
    {
        public static string FormatJsonListString(this string josonStr, string methodName)
        {
            string ss1 = josonStr.Replace(methodName + "Result", String.Empty);
            return ss1.Substring(4, ss1.Length - 5);
        }
    }
}
