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
    class EnumeratorObject<T>
    {
        public int Count;
        int count = -1;
        public DoublyLinkedListNode<T> CurrentItem;
        public DoublyLinkedListNode<T> Head;
        public EnumeratorObject(int count, DoublyLinkedListNode<T> head)
        {
            Count = count;
            Head = head;
            if (head != null)
            {
                CurrentItem = head.Previous;
            } //fix CurrentItem = null error
            //ask about interfaces (IEnumerable)
        }
        public bool MoveToNextItem()
        {
            CurrentItem = CurrentItem.Next;
            count++;
            if (count >= Count)
            {
                return false;
            }
            else return true;
        }
    }
    class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head;
        public int Count { get; private set; }

        //Enumerator helper object/class
        public EnumeratorObject<T> GetEnumerator()
        {
            return new EnumeratorObject<T>(Count, Head);
        }
        public void AddFirst(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value, Head, null);
            if (Head == null)
            {
                Head = newNode;
                Head.Previous = Head.Next = newNode;
            }
            else
            {
                newNode.Previous = Head.Previous;
                newNode.Previous.Next = newNode;
                newNode.Next.Previous = newNode;
                Head = newNode;
            }
            Count++;
        }
        public void AddLast(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value, null, null);
            if (Head == null)
            {
                Head = newNode;
                Head.Previous = Head.Next = newNode;
            }
            else
            {
                newNode.Next = Head;
                newNode.Previous = Head.Previous;
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

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value, node.Next, node);
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
            int count = 0;
            DoublyLinkedListNode<T> Pointer = Head;
            if (Count == 0) return false;

            while (!Pointer.Value.Equals(value))
            {
                if (count > Count) return false;
                Pointer = Pointer.Next;
                count++;
            }

            Pointer.Previous.Next = Pointer.Next;
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
            int count = 0;
            DoublyLinkedListNode<T> Pointer = Head;
            while (!Pointer.Value.Equals(value))
            {
                if (count > Count) throw new ArgumentException("Value you are looking for is not contained in this list");
                Pointer = Pointer.Next;
                count++;
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
