using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class Node<T>
    {
        public T Value;
        public Node<T> Next;

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
    }

    class LinkList<T>
    {
        public Node<T> Head;
        public Node<T> Tail;
        public int Count { get; private set; }

        public void Display()
        {

            for (Node<T> Pointer = Head; Pointer != null; Pointer = Pointer.Next)
            {
                Console.WriteLine(Pointer.Value);
            }
        }
        public void AddFirst(T value)
        {
            Node<T> Pointer = new Node<T>(value, Head);
            Head = Pointer;
            if (Head.Next == null)
            {
                Tail = Head;
            }
            Count++;
        }
        public void AddLast(T value)
        {
            Node<T> Pointer = new Node<T>(value, null);
            if (Tail == null)
            {
                Head = Tail = Pointer;
            }
            else
            {
                Tail.Next = Pointer;
                Tail = Pointer;
            }
            Count++;
        }

        public void AddBefore(T value, Node<T> node)
        {
            if (node == null) throw new ArgumentNullException("Node is null");
            Node<T> Pointer = Head;
            Node<T> headNode = new Node<T>(value, Head);
            if (node == Head)
            {
                headNode.Next = node;
                Head = headNode;
                Count++;
                return;
            }

            while (Pointer.Next != node)
            {
                if (Pointer == null) throw new ArgumentException("Node not contained in list");
                Pointer = Pointer.Next;
            }
            Node<T> newNode = new Node<T>(value, node);
            Pointer.Next = newNode;
            Count++;
        }
        public void AddAfter(T value, Node<T> node)
        {
            if (node == null) throw new ArgumentNullException("Node is null");

            Node<T> Pointer = Head;
            while (Pointer != node)
            {
                if (Pointer == null) throw new ArgumentException("Node not contained in list");

                Pointer = Pointer.Next;
            }
            Node<T> newNode = new Node<T>(value, Pointer.Next);
            Pointer.Next = newNode;
            if (newNode.Next == null)
            {
                Tail = newNode;
            }
            Count++;



        }
        public bool RemoveFirst()
        {
            if (Count == 0) return false;
            else if (Count <= 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
            }

            Count--;
            return true;
        }
        public bool RemoveLast()
        {
            Node<T> Pointer = Head;
            if (Count == 0) return false;
            else if (Count <= 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                while (Pointer.Next != Tail)
                {
                    Pointer = Pointer.Next;
                }
                Tail = Pointer;
                Tail.Next = null;
            }
            Count--;
            return true;
        }
        public bool Remove(T value)
        {
            Node<T> Pointer = Head;
            if (Count == 0) return false;
            if (Head.Value.Equals(value))
            {
                RemoveFirst();
                Count--;
                return true;
            }
            while (!Pointer.Next.Value.Equals(value))
            {
                if (Pointer == null) return false;
                Pointer = Pointer.Next;
            }

            Pointer.Next = Pointer.Next.Next;
            if (Pointer.Next == null)
            {
                Tail = Pointer;
            }
            Count--;
            return true;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            Node<T> Pointer = Head;
            while(!Pointer.Value.Equals(value))
            {
                if (Pointer.Next == null) return false;
                Pointer = Pointer.Next;
            }
            return true;
        }

        public Node<T> Search(T value)
        {
            Node<T> Pointer = Head;
            while(!Pointer.Value.Equals(value))
            {
                if(Pointer.Next == null) return null;
                Pointer = Pointer.Next;
            }
            return Pointer;
        }
    }
}
