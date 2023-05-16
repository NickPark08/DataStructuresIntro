using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class DoublyLinkedListNode<T>
    {
        public T Value;
        public DoublyLinkedListNode<T> Next;
        public DoublyLinkedListNode<T> Previous;

        //public DoublyLinkedList<T> Owner;
             
        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T> next, DoublyLinkedListNode<T> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }

    //continue making changes to make a doubly linked list

    class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head;
        public int Count { get; private set; }

        public void Display()
        {
            DoublyLinkedListNode<T> Pointer = Head;
            while (Pointer != Head.Previous)
            {
                Console.WriteLine(Pointer.Value);
            }
        }
        public void AddFirst(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value, Head, Head.Previous);
            if (Head == null)
            {
                Head = newNode;
                Head.Previous = Head.Next = newNode;
            }
            else
            {
                newNode.Previous.Next = newNode;
                newNode.Next.Previous = newNode;
                Head = newNode;
            }
            Count++;
        }
        public void AddLast(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value, Head, Head.Previous);
            if (Head == null)
            {
                Head = newNode;
                Head.Previous = Head.Next = newNode;
            }
            else
            {
                newNode.Previous.Next = newNode;
                newNode.Next.Previous = newNode;
            }
            Count++;
        }

        public void AddBefore(T value, DoublyLinkedListNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("Node is null");

            if (!Contains(node)) throw new ArgumentException("Node not contained in list");

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value, node, node.Previous);

            newNode.Previous.Next = newNode;
            newNode.Next.Previous = newNode;

            if (node == Head)
            {
                Head = newNode;
                Count++;
                return;
            }
            Count++;
        }
        public void AddAfter(T value, DoublyLinkedListNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("Node is null");

            if (!Contains(node)) throw new ArgumentException("Node not contained in list");

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value, node, node.Previous);
            newNode.Previous.Next = newNode;
            newNode.Next.Previous = newNode;
            Count++;
        }
        public bool RemoveFirst()
        {
            if (Count == 0) return false;
            else if (Count <= 1)
            {
                Head = null;
            }
            else
            {
                Head.Previous.Next = Head.Next;
                Head.Next.Previous = Head.Previous;
                Head = Head.Next;
            }

            Count--;
            return true;
        }
        public bool RemoveLast()
        {
            if (Count == 0) return false;
            else if (Count <= 1)
            {
                Head = null;
            }
            else
            {
                Head.Previous.Previous.Next = Head;
                Head.Previous = Head.Previous.Previous;
            }
            Count--;
            return true;
        }
        public bool Remove(T value)
        {
            DoublyLinkedListNode<T> Pointer = Head;
            if (Count == 0) return false;

            while (!Pointer.Value.Equals(value))
            {
                if (Pointer == Head) return false;
                Pointer = Pointer.Next;
            }

            Pointer.Previous = Pointer.Next;
            Pointer.Next.Previous = Pointer.Previous;
            Count--;
            return true;
        }
        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            DoublyLinkedListNode<T> Pointer = Head;
            while (!Pointer.Value.Equals(value))
            {
                if (Pointer.Next == Head) return false;
                Pointer = Pointer.Next;
            }
            return true;
        }
        public bool Contains(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> Pointer = Head;
            while (Pointer != node)
            {
                if(Pointer.Next == Head) return false;
                Pointer = Pointer.Next;
            }
            return true;
        }

        public DoublyLinkedListNode<T> Search(T value)
        {
            DoublyLinkedListNode<T> Pointer = Head;
            while (!Pointer.Value.Equals(value))
            {
                if (Pointer.Next == null) return null;
                Pointer = Pointer.Next;
            }
            return Pointer;
        }

        public bool IsEmpty()
        {
            if(Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
