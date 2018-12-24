using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public interface ICache<T> //1. All the items (T) has to be the same (all the T's have to be the same).
    {
        void Put(string key, T value);
        T Get(string key);
        T GetAndIfDontExistAss(string key, Func<string, T> takeFromElseWhere);
    }

    public class Cache<T> : ICache<T>   
    {
        IDictionary<string, T> dictionary = new ConcurrentDictionary<string, T>(); //2. Here for instance, all T's will be defined when new instance of the class is created.
        public void Put(string key, T value)
        {
            throw new NotImplementedException();
        }

        public T Get(string key)
        {
            throw new NotImplementedException();
        }

        public T GetAndIfDontExistAss(string key, Func<string, T> missing_name)
        {
            throw new NotImplementedException();
        }
    }
}
