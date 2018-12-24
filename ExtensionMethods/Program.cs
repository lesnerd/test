using System;
using System.Collections.Generic;
using System.Text;
using ExtensionMethods;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(12345.Length());

            List<int> list = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            list.Where(item => item % 2 == 0).ForEach<int>(Console.WriteLine);

            list.Where(foo).ForEach<int>(Console.WriteLine);

            string testStr = "David";
            bool test = testStr.FindIfThereIsI(FindI);

            string s = "dasdasdasdasdDoronkjasdkjhasdkjasd";
            Console.WriteLine(s.FindDoron());

        }

        public static bool foo(int i)
        {
            return i % 2 == 0;
        }

        public static bool FindI(string str)
        {
            if (str.Contains("i"))
                return true;
            return false;
        }

    }

}
