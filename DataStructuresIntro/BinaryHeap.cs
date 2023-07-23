using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class BinaryHeapNode<T>
    {

    }

    class BinaryHeap<T> where T : IComparable<T>
    {
        T[] array = new T[5];

        public void Display()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        public void Insert(T value)
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(default(T)))
                {
                    array[i] = value;
                    HeapifyUp(i);
                    return;
                }
                index = i;
            }
            Array.Resize(ref array, array.Length * 2);
            array[index] = value;
            HeapifyUp(index);
            return;

        }
        private void HeapifyUp(int index)
        {
            if (index == 0) return;

            int parent = (int)Math.Ceiling((index - 1) / 2f);
            while (array[index].CompareTo(array[parent]) < 0)
            {
                T temp = array[index];
                array[index] = array[parent];
                array[parent] = temp;
                parent = (int)Math.Ceiling((parent - 1) / 2f);
            }
        }
    }
}
