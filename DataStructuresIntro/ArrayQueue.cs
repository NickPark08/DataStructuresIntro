using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class ArrayQueue<T>
    {
        public int Count { get; set; }
        T[] array;
        private int head;
        private int tail;
        int Capacity;

        public ArrayQueue(int capacity = 10)
        {
            Capacity = capacity;
            array = new T[Capacity];
            head = 0;
            tail = 0;
        }

        private void Resize(int size)
        {
            T[] tempArray = new T[size];
            int j = 0;

            int lastItem = array.Length;
            if (tail > head)
            {
                lastItem = tail;
            }
            for (int i = head; i < lastItem; i++)
            {
                tempArray[j] = array[i];
                j++;
            }
            if (lastItem == array.Length)
            {
                for (int i = 0; i < tail; i++)
                {
                    tempArray[j] = array[i];
                    j++;
                }
            }
            array = tempArray;
            tail = Count;
            head = 0;
        }

        public void Enqueue(T value)
        {
            if (tail == head)
            {
                Resize(array.Length * 2);
            }

            array[tail] = value;
            Count++;
            tail = (tail + 1) % array.Length;
        }
        public T Dequeue() //test dequeue and simplifying the array
        {
            if(Count == 0) throw new InvalidOperationException("Queue is empty");
            
            if (Count <= array.Length / 4)
            {
                Resize(array.Length / 2);
            }

            T value = array[head];
            if (head != array.Length - 1)
            {
                head += 1;
            }
            else
            {
                head = 0;
            }
            Count--;
            return value;
        }
        public T Peek()
        {
            if(Count == 0) throw new InvalidOperationException("Queue is empty");
            
            return array[head];
        }
    }
}
