using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.X
{
    class Rectangle : Shape
    {
        private int y;

        public Rectangle(int i, int a) : base(i)
        {
            this.Y = a;
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "Y= " + Y.ToString();
        }


    }
}
