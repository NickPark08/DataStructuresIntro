using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
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
            for(int i = 0; i < sets.Length; i++)
            {
                sets[i] = i;
            }
        }

        public int Find(T p)
        {
            return sets[map[p]];
        }

        public bool Union(T p, T q)
        {
            var enumerator = collection.GetEnumerator();
            bool union = false;
            while(enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (map[item] == map[p] && !AreConnected(item, p))
                {
                    map[item] = map[q];
                    union = true;
                }
            }
            return union;
        }

        public bool AreConnected(T p, T q)
        {
            return map[p] == map[q];
        }
    }

    public class QuickUnion<T>
    {
        IEnumerable<T> collection;
        private int[] parents;
        private Dictionary<T, int> map = new Dictionary<T, int>();

        public QuickUnion(IEnumerable<T> items)
        {
            collection = items;
            var enumerator = collection.GetEnumerator();
            int index = 0;
            while (enumerator.MoveNext())
            {
                map.Add(enumerator.Current, index);
                index++;
            }
            parents = new int[map.Count];
            for(int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }    
        }

        public int Find(T p)
        {
            int current = map[p];
            while (current != parents[current])
            {
                current = parents[current];
            }
            return current;
        }

        public bool Union(T p, T q)
        {
            if (!AreConnected(p, q))
            {
                map[p] = parents[map[q]];
                return true;
            }
            return false;
        }
        public bool AreConnected(T p, T q)
        {
            return map[p] == map[q];
        }
    }
}
