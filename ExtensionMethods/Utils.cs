using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class Utils
    {

        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {

            List<T> result = new List<T>();

            foreach (var item in source)
            {
                if (condition(item))
                    result.Add(item);
            }

            return result;
        }


        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {

            foreach (var item in source)
            {
                action(item);    
            }
            
            return source;
        }

        public static int Length(this int integ)
        {
            return integ.ToString().Length;
        }

        public static bool FindIfThereIsI(this string source, Func<string, bool> condition)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (condition(source))
                    return true;
            }
            return false;
        }
    }
}
