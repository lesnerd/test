using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.PolymorphismCode
{
    public class Triangle : Shape
    {
        public override void Print()
        {
            Console.WriteLine(base.ToString());
        }
    }
}
