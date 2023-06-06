using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class LinkedListStack<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        private LinkedList<T> stackList = new LinkedList<T>();

        public void Push(T value)
        {
            stackList.AddFirst(value);
        }
        public T Pop()
        {
            var head = stackList.First.Value;
            stackList.RemoveFirst();
            return head;
        }
        public T Peek()
        {
            return stackList.First.Value;
        }
        public void Clear()
        {
            stackList.Clear();
        }
        public bool IsEmpty()
        {
            if(stackList.Count <= 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> Pointer = stackList.First;
            if (Pointer != null)
            {
                while (Pointer.Next != null)
                {
                    yield return Pointer.Value;
                    Pointer = Pointer.Next;
                }
                yield return Pointer.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //implement Linked-List backed Stack
}
