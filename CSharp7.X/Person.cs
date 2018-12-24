using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CSharp7.X
{
    //More expression bodied members - accessors, constructors and finalizers to the list of things that can have expression bodies
    //Throw expressions - throw as an expression in certain places
    class Person
    {
        private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
        private int _id = 1;
        private int _salary;

        public Person(int id, string name, int salary)
        {
            _salary = salary;
            _id = id;
            names.TryAdd(id, name);
        }

        public Person(int id, string name) => names.TryAdd(id, name);
        
        public Person(string name) => NotNullableName = name ?? throw new ArgumentNullException();

        public double salaryAfterTAXES() => _salary - _salary * 0.35;

        ~Person() => names.TryRemove(_id, out _);

        public string Name
        {
            get => names[_id];
            set => names[_id] = value;
        }

        public string NotNullableName { get; }
    }
}
