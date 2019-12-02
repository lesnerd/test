using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using test.IEnumerable_IEnumerator;
using test.PolymorphismCode;

namespace test
{
    public class Car<T> where T : new()
    {
        //public Car() { }
    }

    public class Check<T>
    {
        public bool Compare(T x, T y)
        {
            if (x.Equals(y))
                return true;
            return false;
        }
    }

    public static class StaticClass
    {

    }

    //public class Const_VS_Readonly
    //{
    //    public const StaticClass s = null;

    //    public const int I_CONST_VALUE = 2;
    //    public readonly int I_RO_VALUE = 2;
    //    public Const_VS_Readonly()
    //    {
    //        I_RO_VALUE = 3;
    //        I_CONST_VALUE = 2;
    //    }

    //    public void UpdateRO()
    //    {
    //        I_RO_VALUE++;
    //    }

    //    public void UpdateCONST()
    //    {
    //        I_CONST_VALUE++;
    //    }
    //}

    class Program
    {

        public static int ASD(int numOfSubFiles, int[] files)
        {
            List<int> list = new List<int>();
            foreach (var i in files)
            {
                list.Add(i);
            }
            list.Sort();
            int ret = 0;
            while (numOfSubFiles >= 2)
            {
                ret += list[0] + list[1];
                list.Add(list[0] + list[1]);
                list.RemoveAt(0);
                list.RemoveAt(0);
                list.Sort();
                numOfSubFiles--;
            }

            return ret;
        }

        static void Main(string[] args)
        {
            int [] arra = new int[]{20, 4, 8, 2};
            ASD(arra.Length, arra);
            arra = new int[]{1,2,5,10,35,89};
            ASD(arra.Length, arra);
            Hashtable h = new Hashtable(); 

            Fill(/*ref*/ h); 

            Console.WriteLine(h.Count); 



            var a1 = "a df df d".Split(' ');
            var a3 = "h df ddf ad".Split(' ');


            var rest = a3.All(q => a3.Any(w => w == q));

            Hashtable ht = new Hashtable();
            ht.Add(1, 1);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(1, 2);

            ////////////////////////////////////////////////

            var i1 = 5;
            var i2 = new[] { 1,2,3};

            var zz = i2.Select(au => au * i1);

            foreach (var ty in zz)
            {
                i1 = ty;
                Console.WriteLine(ty);
            }
            ////////////////////////////////////////////
            
            

            try
            {
                throw new SpecificEx();
            }
            catch (CustomException e)
            {

            }
            catch (Exception ex)
            {
            }


            Fruit aa = new Fruit();
            Fruit bb = new Mango();
            Mango cc = new Mango();

            aa.MyName();
            bb.MyName();
            cc.MyName();

            aa.func();
            bb.func();
            cc.func();



            bool isEqual = FindIfSumOfNumbersIsEqualToN(new int[] {1, 2, 3, 9}, 8);
            isEqual = FindIfSumOfNumbersIsEqualToN(new int[] { 1, 2, 4, 4 }, 8);

            var resultArray = IncreaseNumberByOne(new int [] { 9, 9, 9});
            resultArray = IncreaseNumberByOne(new int[] { 7, 4, 9 });
            resultArray = IncreaseNumberByOne(new int[] { 9, 2, 9, 3 });
            resultArray = IncreaseNumberByOne(new int[] { 8, 2, 9, 3 });

            printBinary(4);

            IntoToBinaryAndCountZeros(9);

            RotationAarrayKTimes(new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 3);


            int splitAnswers;
            splitAnswers = SplitInHalfBarackets("(())(()");
            splitAnswers = SplitInHalfBarackets("()()((()))(()");
            splitAnswers = SplitInHalfBarackets("((((((()))))))");


            FastPowerSet<string>(new string[] {"abc"});
            PowerSet("abc");


            Console.WriteLine(IsFirstLetterUpperAndAllOtherabc("David"));
            Console.WriteLine(IsFirstLetterUpperAndAllOtherabc("dAvid"));
            Console.WriteLine(IsFirstLetterUpperAndAllOtherabc("D@vid"));
            Console.WriteLine(IsFirstLetterUpperAndAllOtherabc("123D"));

            TernaryTree ternaryST = new TernaryTree();
            ternaryST.Add("abba");
            ternaryST.Add("abc");


            var ans = Split("9.0.5");

            PrintStack ps = new PrintStack();
            ps.Build();
            ps.root.print(ps.root);

            int i = 5;
            object o_i = i;
            i = 3;
            Console.WriteLine(o_i);

            A a = new A();
            B b = new B();
            A a2 = new B();
            Console.WriteLine(a.GetInt());
            Console.WriteLine(b.GetInt());
            Console.WriteLine(((A)b).GetInt());
            Console.WriteLine(a2.GetInt());
            Console.WriteLine("=====================================================");
            Console.WriteLine(a.GetBool());
            Console.WriteLine(b.GetBool());
            Console.WriteLine(((A)b).GetBool());
            Console.WriteLine(a2.GetBool());

            Console.WriteLine(Multiply(3, 4));

            LINQ();

            Output();

            minimizeArray();

            var aans = func("abcdef", "", "b");


            subString("ababcabaa", "abc");
            Car<object> c = new Car<object>(); //Object has default ctor.
            //Car<string> c = new Car<string>(); //String doesnt have default ctor.
            Convert.ToString("ss"); //Can handle nulls
            "dfdfdf".ToString(); //Cant handle nulls

            Check<int> comInt = new Check<int>();
            comInt.Compare(1, 2);
            Check<string> comStr = new Check<string>();
            comStr.Compare("David", "David");

            int result;
            result = verify("---(++++)----"); // -> 1 
            Console.WriteLine("The string is: {0} output: {1}", "---(++++)----", result);

            result = verify(""); // -> 1 
            Console.WriteLine("The string is: {0} output: {1}", "", result);

            result = verify("before ( middle []) after "); // -> 1 
            Console.WriteLine("The string is: {0} output: {1}", "before ( middle []) after ", result);

            result = verify(") ("); // -> 0 
            Console.WriteLine("The string is: {0} output: {1}", ") (", result);

            result = verify("} {"); // -> 1 //no, this is not a mistake. 
            Console.WriteLine("The string is: {0} output: {1}", "} {", result);

            result = verify("<(   >)"); // -> 0 
            Console.WriteLine("The string is: {0} output: {1}", "<(   >)", result);

            result = verify("(  [  <>  ()  ]  <>  )"); // -> 1 
            Console.WriteLine("The string is: {0} output: {1}", "(  [  <>  ()  ]  <>  )", result);

            result = verify("   (      [)"); // -> 0
            Console.WriteLine("The string is: {0} output: {1}", "   (      [)", result);


            //--------------------IEnumerable IEnumerator START-----------------------

            Person[] peopleArray = new Person[]
            {
                new Person("David", "Lesner"),
                new Person("Some", "Other"),
                new Person("Ampty", "Dumpty"),
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
            {
                Console.WriteLine(p.firstName + " " + p.lastName);
            }

            //--------------------IEnumerable IEnumerator END-----------------------

            List<Shape> shapes_list = new List<Shape>();
            shapes_list.Add(new Triangle());
            shapes_list.Add(new Circle());
            shapes_list.Add(new Rectangle());

            foreach (var shape in shapes_list)
            {
                shape.Print();
            }
        }

        private static bool FindIfSumOfNumbersIsEqualToN(int[] data, int sum)
        {
            HashSet<int> complements = new HashSet<int>();

            for (int i = 0; i < data.Length; i++)
            {
                if (complements.Remove(data[i]))
                    return true;
                complements.Add(sum - data[i]);
            }
            return false;
        }

        private static int [] IncreaseNumberByOne(int[] ints)
        {
            if (ints == null || ints.Length == 0)
                return null;
            int[] result = new int[ints.Length];

            int carry = 1;
            for (int i = ints.Length - 1; i >= 0; i--)
            {
 
                if (ints[i] + carry >= 10)
                {
                    carry = 1;
                    result[i] = 0;
                }
                else
                {
                    result[i] = (ints[i] + carry) % 10;
                    carry = 0;          
                }
                if (carry == 1 && i == 0)
                {
                    int[] bigger = new int[ints.Length + 1];
                    for (int j = result.Length - 1; j > 1; j--)
                    {
                        bigger[j] = result[j];
                    }
                    bigger[0] = 1;
                    return bigger;
                }
            }

            return result;
        }

        public static T[][] FastPowerSet<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // starting only with empty set
            for (int i = 0; i < seq.Length; i++)
            {
                var cur = seq[i];
                int count = 1 << i; // doubling list each time
                for (int j = 0; j < count; j++)
                {
                    var source = powerSet[j];
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (int q = 0; q < source.Length; q++)
                        destination[q] = source[q];
                    destination[source.Length] = cur;
                }
            }
            return powerSet;
        }

        private static List<string> PowerSet(string input)
        {
            int n = input.Length;
            // Power set contains 2^N subsets.
            int powerSetCount = 1 << n;
            var ans = new List<string>();

            for (int setMask = 0; setMask < powerSetCount; setMask++)
            {
                var s = new StringBuilder();
                for (int i = 0; i < n; i++)
                {
                    // Checking whether i'th element of input collection should go to the current subset.
                    if ((setMask & (1 << i)) > 0)
                    {
                        s.Append(input[i]);
                    }
                }
                Console.WriteLine(s.ToString());
                ans.Add(s.ToString());
            }

            return ans;
        }

        public static int IntoToBinaryAndCountZeros(int N) //Int to binary then count the max number of 0 between 2 1's
        {
            int countZero = 0;
            int countMaxZero = 0;

            string s = Convert.ToString(N, 2);

            int index1 = s.IndexOf('1'); //Gets the first index of 1
            int index2;
            if (index1 != -1)
            {
                while (index1 < s.Length && index1 != -1)
                {
                    index2 = s.IndexOf('1', index1 + 1); //Gets the next index
                    if (index2 != -1)
                    {
                        countZero = index2 - index1 - 1;
                        if (countZero > countMaxZero) countMaxZero = countZero;
                    }
                    index1 = index2;
                }
            }
            return countMaxZero;
        }

        public static int[] RotationAarrayKTimes(int[] A, int K) //Rotation A - array k times
        {

            if (A.Length == 0 || A.Length == 1 || K == 0)
                return A;

            if (K >= A.Length)
                K = K % A.Length;
            int indexResult = 0;
            int[] result = new int[A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                result[indexResult++] = A[(A.Length + i - K) % A.Length];
            }
            return result;
        }



        static int SplitInHalfBarackets(string inputString)
        {
            int result = 0;
            int tmpResult = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '(')
                    tmpResult++;
                if (inputString[i] == ')')
                {
                    if (tmpResult > 0)
                    {
                        if (tmpResult > result)
                            result = tmpResult;
                        tmpResult--;
                    }
                }

            }

            return result * 2; //They wanted the opening and the closing
        }

        static bool IsFirstLetterUpperAndAllOtherabc(string s)
        {
            if (s == null)
                return false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < 'a' && s[i] > 'Z' || s[i] < 'A' || s[i] > 'z')
                    return false;
                if (i == 0 && !Char.IsUpper(s[i]))
                    return false;
                if (i != 0 && Char.IsUpper(s[i]))
                    return false;
            }
            return true;
        }

        static int func(string s, string a, string b)
        {
            var match_empty = '\0';
            if (s.Contains(match_empty))
            {
                return -1;
            }
            else
            {
                var i = s.Length - 1;
                var aIndex = -1;
                var bIndex = -1;

                while ((aIndex == -1) && (bIndex == -1) && (i >= 0))
                {
                    if (s.Substring(i, 1) == a)
                        aIndex = i;

                    if (s.Substring(i, 1) == b)
                        bIndex = i;
                    i--;
                }
                if (aIndex != -1)
                {
                    if (bIndex == -1)
                        return aIndex;
                    else
                        return Math.Max(aIndex, bIndex);
                }
                else
                {
                    if (bIndex != -1)
                        return bIndex;
                    else
                        return -1;
                }
            }
        }


        static int solutionfunc(string s, string a, string b)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i].ToString() == a || s[i].ToString() == b)
                    return i;
            }

            return -1;
        }



        static string Split(string str)
        {


            return str.Substring(2, 1);
        }

        static string Substring(string str, int x, int y)
        {
            string answer = "";
            int idx = 0;
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i >= x && idx < y)
                {
                    answer += arr[i];
                    idx++;
                }
            }
            return answer;
        }

        static int verify(string S)
        {
            Stack<char> stack = new Stack<char>();
            char c = '-';
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(' || S[i] == '[' || S[i] == '<')
                    stack.Push(S[i]);
                if (S[i] == ')' || S[i] == ']' || S[i] == '>')
                {
                    if (stack.Count > 0)
                        c = stack.Pop();
                    if ((c == '(' && S[i] == ')') || (c == '[' && S[i] == ']') || (c == '<' && S[i] == '>'))
                        continue;
                    stack.Push(c);
                }
            }
            return stack.Count == 0 ? 1 : 0;
        }

        static int verify1(string S)
        {
            int current_max = 0; // current count
            int max = 0; // overall maximum count

            // Traverse the input string
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    current_max++;

                    // update max if required
                    if (current_max > max)
                        max = current_max;
                }
                else if (S[i] == ')')
                {
                    if (current_max > 0)
                        current_max--;
                    else
                        return -1;
                }
            }
            // finally check for unbalanced string
            if (current_max != 0)
                return -1;

            return max;
        }



        //Async await
        public static async void SomeMethod()
        {
            await Task.Run(new Action(Dynamic));
            Console.WriteLine("Sync and await comes together to make sure 'Dynamic' function finish running!");
        }

        public static void Dynamic() //Dynamic objects
        {
            dynamic var = new ExpandoObject();
            var.Name = "david";
            var.Age = 32;
            Console.WriteLine(var);
        }

        public static int subString(string str, string substr)
        {
            int res = 0;
            if (str == null || substr == null)
                return -1;

            int sStr = 0;
            int sSubstr = 0;

            while (sStr < str.Length)
            {
                int oldsStr = sStr;
                while (sStr < str.Length && sSubstr < substr.Length && str[sStr] == substr[sSubstr])
                {
                    sStr++;
                    sSubstr++;
                }
                if (sSubstr == substr.Length)
                    return res;
                sStr = oldsStr + 1;
                sSubstr = 0;
                res++;
            }

            return -1;
        }

        public static int Multiply(int x, int y)
        {
            if (y == 1)
                return x;
            return x + Multiply(x, y - 1);
        }

        //void findKth(btree tree, int k)
        //{
        //    if(tree == null)
        //        return;
        //    findKth(tree.left, k);
        //    if(k == 0)
        //        return tree;
        //    k--;
        //    findKth(tree.right, k);
        //}

        public static void Fill(/*ref*/ Hashtable ht)
        {
            ht.Add("a", "b");
            ht = null; 
        }

        public static void Output()
        {
            List<Func<int>> list = new List<Func<int>>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(() => i);
            }


            foreach (var func in list)
            {
                Console.WriteLine(func());
            }
        }

        public static void LINQ()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] strings = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eigth", "nine"};

            var textNums = numbers.Select(a => strings[a]).Where(b => b.Contains("i"));

            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }

        public static void minimizeArray()
        {
            object[] arr = {1, 1, 3, 3, 3, 5, 7, 7, 7};

            bool endOfArr = false;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int j = i + 1;

                while ((arr[j] == null) || ((int) arr[j] == (int) arr[i]))
                {
                    arr[j] = null;

                    j++;

                    if (j == arr.Length)
                    {
                        endOfArr = true;
                        break;
                    }
                }

                if (!endOfArr)
                    arr[i + 1] = arr[j];
                else
                    break;
            }

        }


        /// <summary>
        /// Print all binary numbers in the length of 'n'
        /// </summary>
        /// <param name="n"></param>
        public static void printBinary(int n)
        {
            binaryHelper(n, "");
        }

        public static void binaryHelper(int n, String s)
        {
            if (s.Length == n)
                Console.WriteLine(s);
            else
            {
                binaryHelper(n, s + "0");
                binaryHelper(n, s + "1");
            }

        }

        /// <summary>
        /// 
        /// </summary>

        public abstract class Abc
        {
            public abstract void Metho();

            protected void Metho1()
            {
                Console.WriteLine("a");
            }
        }

        public class A
        {
            public int i;
            public bool f;
            public string s;

            public int GetInt()
            {
                Console.WriteLine("A");
                return i;

            }

            public virtual bool GetBool()
            {
                Console.WriteLine("A");
                return f;
            }

            protected virtual void Do1()
            {

            }
        }

        public class CustomException : Exception
        {
            private DateTime df;
            public void Do(int a, string s)
            {
               var sd =  MyEnum.A & MyEnum.B;
            }

            public void Do(int a, ref string s)
            {
            }
        }

        public class SpecificEx : CustomException
        {

        }

        public interface IInterface : IInterface2
        {
            
        }

        public interface IInterface2
        {
            
        }

        public enum MyEnum
        {
            A,
            B
        }

        public class B : A
        {
            public override bool GetBool()
            {
                Console.WriteLine("B");
                return f;
            }

            public int GetInt()
            {
                Console.WriteLine("B");
                return i = 10;
            }
        }


        public class Fruit
        {
            public void MyName()
            {
                Console.WriteLine("Fruit1");
            }

            public virtual void func()
            {
                Console.WriteLine("Fruit2");
            }

        }

        public class Mango : Fruit
        {
            public void MyName()
            {
                Console.WriteLine("Mango1");
            }

            public override void func()
            {
                Console.WriteLine("Mango2");
            }

        }

        public sealed class Singleton
        {
            private static readonly Singleton instance = new Singleton();
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Singleton()
            {
            }

            private Singleton()
            {
            }

            public static Singleton Instance
            {
                get
                {
                    return instance;
                }
            }
        }



        public class ObjectReader
        {
            const string selectQTamplate = "select {0} from {1}";



            static void Main2(string[] args)
            {

                A a = ReadData<A>();
            }

            object o = new object();

            public static T ReadData<T>()
            {
                T result = Activator.CreateInstance<T>();
                Type type = typeof(T);

                string fields = string.Empty;

                type.GetProperties().ToList().ForEach(a => fields += a.Name + ", ");

                if (fields.EndsWith(","))
                    fields.Remove(fields.LastIndexOf(','));


                string query = string.Format(selectQTamplate, fields, type.Name);

                return result;
            }

        }
    }
}
