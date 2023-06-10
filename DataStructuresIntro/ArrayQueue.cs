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
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            array = tempArray;
        }

        public void Enqueue(T value)
        {
            if (tail == head)
            {
                Resize(array.Length * 2);
                tail = Count;
            }

            array[tail] = value;
            Count++;
            tail = (tail + 1) % array.Length;
        }
        public T Dequeue() //test dequeue and simplifying the array
        {
            if (Count / 4 <= array.Length)
            {
                Resize(array.Length / 2);
            }
            T value = array[head];
            head += 1;
            Count--;
            return value;
        }
        public T Peek()
        {
            return array[head];
        }
    }
}
