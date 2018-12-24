using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CSharp7.X
{
    class Program
    {
        static void Main(string[] args)
        {
            //Out variables
            GetNumbet("455");

            //Pattern matching
            var shapes = new Shape[] {new Circle(3), new Rectangle(5,6) };
            foreach (var shape in shapes)
            {
                PrintShapes(shape);
            }

            //Tuples
            var numbersToMultipleAndAdd = new List<int>() {1,2,3,4,5,6,7,8,9};
            var AddAndMultipleAtOnceRESULT =  AddAndMultipleAtOnce(numbersToMultipleAndAdd);
            Console.WriteLine("Addition: " + AddAndMultipleAtOnceRESULT.addition + " Multiplication: " + AddAndMultipleAtOnceRESULT.multiplication);

            //Deconstruct - way to consume tuples is to deconstruct them
            var p = new Point(6,7);
            (var myX, var myY) = p; // calls Deconstruct(out myX, out myY);
            Console.WriteLine("myX= " + myX + " myY= " + myY);
            (_, var justY) = p; //Dont care '_' about x

            //Local functions
            var filteredList = Filter(numbersToMultipleAndAdd, i => i == 5 || i == 9);
            Console.WriteLine(String.Join(", ", filteredList.Where(i => true)));

            //Literal improvements - improves readability
            var b = 0b1010_1011_1100_1101_1110_1111;
            Console.WriteLine(b);

            //Ref return and locals
            var intArray = new[] {5,6,8,2,1,4,6,3};
            ref int place = ref Find(1, intArray);
            place = 100;
            intArray.ToList().ForEach(i => Console.Write(i + ","));

            //
            var person = new Person("David");
        }

        public static ref int Find(int number, int [] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; //Return the storage location not the value
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }

        //Out variables - no need to declare x before tryparse
        public static int GetNumbet(string stringNumber)
        {
            if (int.TryParse(stringNumber, out int x))
                return x;
            throw new ArithmeticException("Not a number...");

        }

        //Pattern matching - now switch cases can differentiate between reference types
        public static void PrintShapes(Shape shape)
        {
            switch (shape)
            {
                case Circle c:
                    Console.WriteLine($"circle with radius {c.ToString()}");
                    break;
                case Rectangle s when (s.X == s.Y):
                    Console.WriteLine($"{s.X} x {s.Y} square");
                    break;
                case Rectangle r:
                    Console.WriteLine(r.ToString() + " rectangle");
                    break;
                default:
                    Console.WriteLine("<unknown shape>");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }
        }

        //Tuple is now a 'NUGET' package, value type, item1 item2 and so on are still exits but gen have a meaningfull name
        static (int addition, int multiplication) AddAndMultipleAtOnce(List<int> numbersList)
        {
            return (numbersList.Sum(item => item), numbersList.Aggregate((x, y) => x * y));
        }

        //Local functions
        static IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            return Iterator();

            IEnumerable<T> Iterator()
            {
                foreach (var element in source)
                {
                    if (filter(element))
                        yield return element;
                }
            }
        }


    }
}
