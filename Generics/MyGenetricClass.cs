using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class MyGenericClass<T>
    {
        private T genericMemberVariable;

        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public R ConvertStringToDateTime<R>(string date) where R : IConvertible
        {
            R result = default(R);

            try
            {
                result = (R)Convert.ChangeType(date, typeof(R));
            }
            catch (Exception e)
            {
                throw;
            }
            return result;
        }

        public void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
        {
            T temp;
            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }

        public T genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }

        public T genericProperty { get; set; }
    }
}
