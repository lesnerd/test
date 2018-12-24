using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.X
{
    class Circle : Shape
    {
        private static double Pi = 3.14159265;

        public Circle(int i) : base(i)
        {
                
        }
        public override string ToString()
        {
            return base.ToString() + "Pi= " + Pi.ToString();
        }
    }
}
