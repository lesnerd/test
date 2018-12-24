using System;
using System.Net.Http.Headers;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "David";
            var str2 = "Dav";

            MyGenericClass<string> myGenericClass = new MyGenericClass<string>("David");
            myGenericClass.genericMethod("Lesner");

            Console.WriteLine("Before swapping: str1={0} str2={1}", str1, str2);         
            myGenericClass.SwapIfGreater(ref str1, ref str2);
            Console.WriteLine("After swapping: str1={0} str2={1}", str1, str2);

            var dateNow = DateTime.Today.Date.ToString();
            Console.WriteLine("Today date is: {0}", dateNow);
            var myDate = myGenericClass.ConvertStringToDateTime<DateTime>(dateNow);

            Console.ReadKey();
        }
        
    }
}
