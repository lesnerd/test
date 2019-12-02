using System;

namespace MoreQuestions
{
    class Program 
    {
        private static void Permute(string str, int location, int strSize)
        {
            if (location == strSize)
                Console.WriteLine(str);
            else
            {
                for (int i = location; i <= strSize; i++)
                {
                    str = Swap(str, location, i);
                    Permute(str, location + 1, strSize); 
                    str = Swap(str, location, i);
                }
            }
        }


        public static string Swap(string a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        public static void Main()
        {
            string str = "ABC";
            int n = str.Length;
            Permute(str, 0, n - 1);
            Console.ReadKey();
        }
    }

}
