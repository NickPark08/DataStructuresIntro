using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class SkipListNode<T> where T : IComparable<T>
    {
        public T Value;
        public SkipListNode<T> Next;
        public SkipListNode<T> Bottom;
        public int Height;
        public SkipListNode(T value, SkipListNode<T> next, SkipListNode<T> bottom, int height)
        {
            Value = value;
            Next = next;
            Bottom = bottom;
            Height = height;
        }
    }
    class SkipList<T> : ICollection<T> where T : IComparable<T>
    {
        SkipListNode<T> Head = new SkipListNode<T>(default, null, null, 0);
        public int GenerateRandomHeight()
        {
            Random rnd = new Random();
            int newHeight = 0;

            while (newHeight != Head.Height + 1)
            {
                if (rnd.Next(2) == 0)
                {
                    newHeight++;
                }
                else break;
            }
            if(Head.Height < newHeight)
            {
                SkipListNode<T> temp = Head;
                Head.Bottom = temp;
                Head.Height = newHeight;
            }
            return newHeight;
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T value)
        {
            int randHeight = GenerateRandomHeight();
            SkipListNode<T> Pointer = Head;
            while(Pointer.Height != randHeight)
            {
                Pointer = Pointer.Bottom;
            }
            SkipListNode<T> newNode = new SkipListNode<T>(value, null, null, Pointer.Height);

            //do
            //{
            //    if (Pointer.Value)
            //}
          
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
