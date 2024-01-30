using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    
    public interface ICache <TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);

        void Put(TKey key, TValue value);
    }

    public class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        LinkedList<TKey> list { get; set; }

        Dictionary<TKey, TValue> map { get; set; }

        bool ICache<TKey, TValue>.TryGetValue(TKey key, out TValue value)
        {
            if (map[key] != null)
            {
                list.Remove(key);
                list.AddFirst(key);
                value = map[key];
                return true;
            }
            value = default;
            return false;
        }

        void ICache<TKey, TValue>.Put(TKey key, TValue value)
        {
            if (map[key] != null)
            {
                map[key] = value;
            }
            else
            {
                LinkedListNode<TKey> node = new LinkedListNode<TKey>(key);
                map.Add(key, value);
                list.AddFirst(node);
            }
        }
    }
}
