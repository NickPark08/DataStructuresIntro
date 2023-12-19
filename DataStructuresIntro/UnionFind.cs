using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class UnionFind
    {

    }
    public class QuickFind<T>
    {
        IEnumerable<T> collection;
        private int[] sets;
        private Dictionary<T, int> map = new Dictionary<T, int>();
        public QuickFind(IEnumerable<T> items) 
        {
            collection = items;
            var enumerator = collection.GetEnumerator();
            int index = 0;
            while(enumerator.MoveNext())
            {
                map.Add(enumerator.Current, index);
                index++;
            }
            sets = new int[map.Count];
        }

        public int Find(T p)
        {
            return sets[map[p]];
        }

        public bool Union(T p, T q)
        {
            var enumerator = collection.GetEnumerator();
            while(enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (map[item] == map[p])
                {
                    map[item] = map[q];
                }
            }
            return false;
        }
    }
}
