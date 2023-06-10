using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class ArrayStack<T>
    {
        public int Capacity;
        public int Count { get; private set; }
        T[] stackArray;
        public ArrayStack(int capacity = 10) 
        {
            Capacity = capacity;
            stackArray = new T[Capacity];
        }        


        public void Push(T value)
        {
            if(Count < Capacity)
            {
                stackArray[Count] = value;
                Count++;
            }
            else
            {
                Resize(Capacity * 2);
                stackArray[Count] = value;
                Count++;
            }
        }
        public T Pop()
        {
            T value = stackArray[Count-1];
            stackArray[Count-1] = default;
            Count--;
            return value;
        }
        public T Peek()
        {
            return stackArray[Count-1];
        }
        private void Resize(int size)
        {
            T[] tempArray = new T[size];
            for(int i = 0; i < stackArray.Length; i++)
            {
                tempArray[i] = stackArray[i];
            }
            stackArray = tempArray;
        }
    }
}
