using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if (Head.Height < newHeight)
            {
                SkipListNode<T> newHead = new SkipListNode<T>(Head.Value, null, Head, newHeight);
                Head = newHead;


                //SkipListNode<T> Pointer = Head;
                //while (Pointer.Height != 0)
                //{
                //    Pointer.Bottom = new SkipListNode<T>(Pointer.Value, Pointer.Next, null, Pointer.Height - 1);
                //    Pointer = Pointer.Bottom;
                //}
            }
            return newHeight;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T value)
        {
            int randHeight = GenerateRandomHeight();
            SkipListNode<T> Pointer = Head;
            while (Pointer.Height != randHeight)
            {
                Pointer = Pointer.Bottom;
            }
            SkipListNode<T> newNode = new SkipListNode<T>(value, null, null, Pointer.Height);

            do
            {
                if (Pointer.Next == null)
                {
                    ConnectNodes(Pointer, newNode);
                    break;
                }
                if (Pointer.Value.CompareTo(value) > 0)
                {
                    Pointer = Pointer.Next;
                }
                else
                {
                    ConnectNodes(Pointer, newNode);
                    break;
                }
            }
            while (Pointer != null);
            Count++;
        }

        public void ConnectNodes(SkipListNode<T> previous, SkipListNode<T> current)
        {
            current.Next = previous.Next;
            if (previous.Height == current.Height)
            {
                previous.Next = current;
            }
            //else
            //{
            //    SkipListNode<T> temp = Head;
            //    while(temp.Height != current.Height)
            //    {
            //        temp = temp.Bottom;
            //    }

            //    while(temp.Next != null)
            //    {
            //        temp = temp.Next;
            //    }
            //    temp.Next = current;
            //}
            SkipListNode<T> Pointer = current;
            SkipListNode<T> temp = previous.Bottom;
            while (Pointer.Height != 0)
            {
                Pointer.Bottom = new SkipListNode<T>(Pointer.Value, Pointer.Next, null, Pointer.Height - 1);
                Pointer = Pointer.Bottom;
            }
            while (temp.Next != null && !temp.Next.Value.Equals(Pointer.Value))
            {
                temp = temp.Next;
            }
            temp.Next = Pointer;
            temp = temp.Bottom;
            //while (temp.Next != null && temp.Next.Value.CompareTo(Pointer.Value) < 0)
            //{
            //    temp = temp.Next;
            //}
            //temp.Next = Pointer;


            //if (previous.Height == current.Height && current.Height > 0)
            //{
            //    previous.Bottom.Next = current.Bottom;
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
