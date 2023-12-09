using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{ 

    class HashMap<T, U> : IDictionary<T, U>
    {
        public LinkedList<U>[] array = new LinkedList<U>[1];
        private List<T> keys = new List<T>();
        private List<U> values = new List<U>();
        IEqualityComparer<T> Comparer;

        public HashMap(IEqualityComparer<T> comparer)
        {
            Comparer = comparer;
        }
        public HashMap()
        {
            Comparer = EqualityComparer<T>.Default;
            if(Comparer == null)
            {
                throw new ArgumentNullException("Comparer is null");
            }
        }

        public U this[T key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<T> Keys => keys;

        public ICollection<U> Values => values;

        public int Count => keys.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public bool Equals(T x, T y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(T obj)
        {
            return Comparer.GetHashCode(obj);
        }
        public void Add(T key, U value)
        {
            if(Count == array.Length)
            {
                ReHash();
            }
            int index = Comparer.GetHashCode(key) % array.Length;
            if (array[index] == null)
            {
                array[index] = new LinkedList<U>();
                array[index].AddFirst(value);
                keys.Add(key);
                values.Add(value);
            }
            else throw new Exception("Duplicate keys not allowed");
        }

        private void ReHash()
        {
            LinkedList<U>[] newArray = new LinkedList<U>[array.Length * 2];
            for(int i = 0; i < Count; i++)
            {
                int newIndex = Comparer.GetHashCode(keys[i]) % newArray.Length;
                int index = Comparer.GetHashCode(keys[i]) % array.Length;
                newArray[newIndex] = array[index];
            }
            array = newArray;
        }

        public void Add(KeyValuePair<T, U> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            array = new LinkedList<U>[1];
        }

        public bool Contains(KeyValuePair<T, U> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(T key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }


        public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public bool Remove(T key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<T, U> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(T key, [MaybeNullWhen(false)] out U value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
