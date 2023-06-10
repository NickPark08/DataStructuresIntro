using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class LinkedListQueue<T>
    {
        public int Count => queueList.Count;
        LinkedList<T> queueList = new LinkedList<T>();

        public void Enqueue(T value)
        {
            queueList.AddLast(value);
        }
        public T Dequeue()
        {
            T value = queueList.First.Value;
            queueList.RemoveFirst();
            return value;
        }
        public T Peek()
        {
            return queueList.First.Value;
        }
    }
}
