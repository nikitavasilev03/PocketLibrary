using System.Collections.Generic;
using System.Linq;

namespace PL.Extensions
{
    public static class BaseExtensions
    {
        public static string ItemsToString<T>(this IEnumerable<T> collection)
        {
            string str = "";
            foreach (var x in collection)
                str += x.ToString() + " ";
            str = str.Remove(str.Length - 1, 1);
            return str;
        }
        public static IEnumerable<T> Copy<T>(this IEnumerable<T> collection)
        {
            List<T> ts = new List<T>();
            foreach (var x in collection)
                ts.Add(x);
            return ts.AsEnumerable();
        }
    }
}
