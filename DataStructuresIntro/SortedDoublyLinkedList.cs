using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class SortedDoublyLinkedListNode<T> where T : IComparable<T>
    {
        public T Value;
        public SortedDoublyLinkedListNode<T> Previous;
        public SortedDoublyLinkedListNode<T> Next;

        public SortedDoublyLinkedListNode(T value, SortedDoublyLinkedListNode<T> previous, SortedDoublyLinkedListNode<T> next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }
    class SortedDoublyLinkedList<T> where T : IComparable<T>
    {
        SortedDoublyLinkedListNode<T> Head = new SortedDoublyLinkedListNode<T>(default, null, null);
        SortedDoublyLinkedListNode<T> Tail = new SortedDoublyLinkedListNode<T>(default, null, null);
        public SortedDoublyLinkedList()
        {
            Head.Next = Tail;
            Tail.Previous = Head;
        }

        public void Display()
        {
            SortedDoublyLinkedListNode<T> Pointer = Head.Next;
            while (Pointer.Next != null)
            {
                Console.WriteLine(Pointer.Value);
                Pointer = Pointer.Next;
            }
        }
        public void Insert(T value)
        {
            SortedDoublyLinkedListNode<T> current = Head;
            SortedDoublyLinkedListNode<T> newNode = new SortedDoublyLinkedListNode<T>(value, Head, null);
            do
            {
                if(current.Next == Tail)
                {
                    ConnectNodes(current, newNode, Tail);
                    break;
                }
                if (value.CompareTo(current.Next.Value) < 0)
                {
                    current = current.Next;
                    newNode.Previous = current;
                }
                else
                {
                    ConnectNodes(newNode.Previous, newNode, current.Next);
                    break;
                }
            }
            while (current != Tail);
        }
        private void ConnectNodes(SortedDoublyLinkedListNode<T> previous, SortedDoublyLinkedListNode<T> newNode, SortedDoublyLinkedListNode<T> next)
        {
            previous.Next = newNode;
            newNode.Previous = previous;
            newNode.Next = next;
            next.Previous = newNode;
        }

        public void Delete(T value)
        {
            SortedDoublyLinkedListNode<T> current = Head.Next;
            while(current != Tail || !current.Value.Equals(value))
            {
                current = current.Next;
            }
            DeleteLinks(current);
        }

        private void DeleteLinks(SortedDoublyLinkedListNode<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }
    }
}
