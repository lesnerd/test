using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.X
{
    class Shape
    {
        protected int x;

        public Shape(int i)
        {
            this.X = i;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public override string ToString()
        {
            return "X= " + X.ToString();
        }
    }
}
