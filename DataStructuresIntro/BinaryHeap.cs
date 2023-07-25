﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            array[index + 1] = value;
            HeapifyUp(index + 1);
            return;

        }
        public T Pop()
        {
            int popIndex = array.Length - 1;
            T value = array[popIndex];
            array[0] = value;
            array[popIndex] = default(T);
            HeapifyDown(0);
            return value;
        }
        private void HeapifyUp(int index)
        {
            if (index == 0) return;

            int parent = (index - 1) / 2;
            while (array[index].CompareTo(array[parent]) < 0)
            {
                T temp = array[index];
                array[index] = array[parent];
                array[parent] = temp;
                index = parent;
                parent = (parent - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            if (index >= array.Length - 1) return;

            int mainChild;
            int child1 = (index + 1) * 2;
            int child2 = child1 - 1;
            //fix swapping down

            do
            {
                if (array[child1].CompareTo(array[index]) < 0 && array[child2].CompareTo(array[index]) < 0)
                {
                    if (array[child1].CompareTo(array[child2]) < 0)
                    {
                        mainChild = child1;
                    }
                    else
                    {
                        mainChild = child2;
                    }
                }
                else if (array[child1].CompareTo(array[index]) < 0)
                {
                    mainChild = child1;
                }
                else
                {
                    mainChild = child2;
                }

                if (array[mainChild].CompareTo(array[index]) < 0)
                { 
                    T temp = array[index];
                    array[index] = array[mainChild];
                    array[mainChild] = temp;
                    mainChild = index;
                    index = (index + 1) * 2;
                }
                
            } while (array[mainChild].CompareTo(array[index]) < 0);
        }
    }
}
