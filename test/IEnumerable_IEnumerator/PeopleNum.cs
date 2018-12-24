using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.IEnumerable_IEnumerator
{
    public class PeopleNum : IEnumerator
    {
        public Person[] _people;
        private int position = -1;

        public PeopleNum(Person [] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;

            return position < _people.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public object Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                   throw new InvalidOperationException();
                }
            }
        }
    }
}
