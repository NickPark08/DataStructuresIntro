using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    public class HashMap<TKey, TValue>
    {
        public LinkedList<KeyValuePair<TKey, TValue>>[] array = new LinkedList<KeyValuePair<TKey, TValue>>[2];
        private readonly List<TKey> keys = new List<TKey>();
        private readonly List<TValue> values = new List<TValue>();
        IEqualityComparer<TKey> Comparer;

        public HashMap(IEqualityComparer<TKey> comparer)
        {
            Comparer = comparer;
        }
        public HashMap()
        {
            Comparer = EqualityComparer<TKey>.Default;
            if (Comparer == null)
            {
                throw new ArgumentNullException("Comparer is null");
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (!keys.Contains(key)) throw new Exception("Key does not exist in collection");
   
                return array[Comparer.GetHashCode(key) % array.Length].First.Value.Value;
            }
            set
            {
                int index = Comparer.GetHashCode(key) % array.Length;
                if (array[index] == null)
                {
                    Add(key, value);
                }
                else
                {
                    foreach(var pair in array[index])
                    {
                        if(pair.Key.Equals(key))
                        {
                            array[index].Remove(pair);
                            array[index].AddFirst(new KeyValuePair<TKey, TValue>(pair.Key, value));
                            break;
                        }
                    }
                }
            }
        }

        public ICollection<TKey> Keys => keys;

        public ICollection<TValue> Values => values;

        public int Count => keys.Count;

        public void Add(TKey key, TValue value)
        {
            if (Count == array.Length)
            {
                ReHash();
            }
            int index = Comparer.GetHashCode(key) % array.Length;
            KeyValuePair<TKey, TValue> newPair = new KeyValuePair<TKey, TValue>(key, value);
            if (array[index] == null)
            {
                array[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            else
            {
                foreach (var pair in array[index])
                {
                    if (pair.Key.Equals(key)) throw new Exception("Duplicate keys not allowed");
                }
            }
            keys.Add(key);
            values.Add(value);
            array[index].AddFirst(newPair);
        }

        private void ReHash()
        {
            LinkedList<KeyValuePair<TKey, TValue>>[] newArray = new LinkedList<KeyValuePair<TKey, TValue>>[array.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                int newIndex = Comparer.GetHashCode(keys[i]) % newArray.Length;
                int index = Comparer.GetHashCode(keys[i]) % array.Length;
                newArray[newIndex] = array[index];
            }
            array = newArray;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            array = new LinkedList<KeyValuePair<TKey, TValue>>[10];
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            foreach (var key in keys)
            {
                if (array[Comparer.GetHashCode(key) % array.Length].Contains(item)) return true;
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach(var list in array)
            {
                if(list != null)
                {
                    foreach(var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }


        public bool Remove(TKey key)
        {
            int index = Comparer.GetHashCode(key) % array.Length;

            if (array[index] == null) return false;

            foreach (var pair in array[index])
            {
                if (pair.Key.Equals(key))
                {
                    array[index].Remove(pair);
                    keys.Remove(pair.Key);
                    values.Remove(pair.Value);
                    break;
                }
            }

            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            int index = Comparer.GetHashCode(key) % array.Length;
            foreach(var pair in array[index])
            {
                if(pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            value = default;
            return false;
        }
    }
}
