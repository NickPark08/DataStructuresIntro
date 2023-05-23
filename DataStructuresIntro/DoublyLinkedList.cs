using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    //https://sharplab.io/#v2:C4LgTgrgdgNAJiA1AHwAICYCMBYAUKgBgAJVMAWAbj0JMwDoBhAewBsWBTAY2AEsmoAzlXzFSdADI8oAR2F4pwdmABmAQ07siASQaqoAcXbAAchAC2AIyV4A3niIOiCooZPmrYABQBKYQF88eShFFXVNLQAJVQFTSyUiEG1dAyNYj1tHIntHZzT4mwBzIwoA3FLA3AUlNQ1tKIEAFQB3JjywAQSkvVc222yHZ1cAeWAACyU2n38K6nQiAGVgMCkCiNY4eMTI6LaYOujm1vclAT7cTNJicZY4ReWoAuFM/qdg/ZjjsDo2ogBeAD4XKlPlMKs9zo5UABmBZLFZrG5KTyXIjXW5wh7eP6AsY8AR0NF3FZ/VHsG5Eh5yCEOaGvYBAtxxLzeF52amZEgAdjpdAACqp2uxPISMQVfC9yuzaYMjCNxmBJiz2WyOZDuSL7gUJOwHmMno5SpKMNpggiNmBOtsPky9qQoQAeBT/M6ZZwRMlwLTBfUOF7St4/AFEd03L3AH1ZKUwsNmpHONFhrFBkOet6/Umh70vP3RgCiUHMSlUwCYYEdwUBrnzhbAxdLPlZLwu3Kg7CaRGrZiLJa8uIE4vZpXBmS0ne7pdoULoVYLXdrPYbyqbaqIrfbY/n9b7A8yQ8cObpDMVjfZzeDHrDEb3vqjJDmG7rFq2D575eAzqXp/3X4GbwEwGLTR0wICMR1NdZ4gABwFHVwzBVUSBhZwGAgMAwFgohCmKIgBGKa8OSYCwACsuHpUdZ3HL4ULQjCg2o9Csx/SMEMQjsKM3LwYwgi0FFjMAlRYlUWMcaCGPpdNeO40CEPo2iiFE2C6BTS9hIQ+DVUlFjaQsJhWCIABZJgADd2GMdgAA9gEXQTVOE5dVR4ZQiE8f9AL+dNMCxVBuTUFhcOk1V7I5VzFEQRAAo5byiCWCB2AoWyOSC/DhwQ2lUDIIgACV2Fwqyk0BEKgKIECgqCtKMoAETxSCmFwnxMPww0ZlwCo0rmBhMOai5MAANhIDLeXuRkPHtBpAU8BonEUMwsSaeVNEmrZ6l2d5DjaU5Py0zAAE5PB4abp2BJkfB3A11LvOYTxYyR/zfQEFA6dM13qmwAFY9kwAgPveoh0C+37Xr8CKgq4xELVGbiSTXE1gD4zxOVOwKmIpVZIZ0iwobbWFNThgAidAAA5cd8BLvyC5RS3YdRRk8IyBSm9gzFeVFuIEhChNU0hdv2xnEY5ZLvxYin0Op5y6Z46bmYetnVQ54Sub26a+d3IKUtUiU8D8IA=
    // ^enumeration & interface demo

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
    class EnumeratorObject<T> where T : IEnumerator<T>
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
            }
            //ask about interfaces (IEnumerable)
            //implement interfaces (IEnumerable) into linked list
        }
        public bool MoveToNextItem()
        {
            if (CurrentItem == null) return false;
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
        public IEnumerator<T> GetEnumerator()
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
