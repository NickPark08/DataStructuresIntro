using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            while (enumerator.MoveNext())
            {
                map.Add(enumerator.Current, index);
                index++;
            }
            sets = new int[map.Count];
            for (int i = 0; i < sets.Length; i++)
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
            bool union = false;
            int set1 = Find(p);
            int set2 = Find(q);

            if (!AreConnected(p, q))
            {
                for (int i = 0; i < sets.Length; i++)
                {
                    if (sets[i] == set2)
                    {
                        sets[i] = set1;
                        union = true;
                    }
                }
            }
            return union;
        }

        public bool AreConnected(T p, T q)
        {
            return Find(p) == Find(q);
        }
    }

    public class QuickUnion<T>
    {
        IEnumerable<T> collection;
        private int[] parents;
        private Dictionary<T, int> map = new Dictionary<T, int>();
        private List<UUVertex<T>> vertices;

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
            parents = new int[items.Count()];
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }
        }

        public int Find(T p)
        {
            int current = map[p];
            while (parents[current] != current)
            {
                current = parents[current];
            }
            return current;
        }

        public bool Union(T p, T q)
        {
            if (AreConnected(p, q)) return false;

            while (parents[map[q]] != map[q])
            {
                map[q] = parents[map[q]];
            }

            parents[map[q]] = map[p];
            return true;
        }
        public bool AreConnected(T p, T q)
        {
            return Find(p) == Find(q);
        }
    }
}
