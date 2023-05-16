using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class GenericList<T>
    {
        private int count;
        public int Count 
        {
            get
            {
                return count;
            }
            private set
            {
                if (value > 0)
                {
                    count = value;
                }
            }
        }

        T[] array;
        public GenericList(int length)
        {
            array = new T[length];
            Count = array.Length;
        }

        public GenericList(params T[] array)
            : this(array.Length)
        {

        }

        public void Add(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    array[i] = item;
                    return;
                }
            }
            T[] tempArray = array;
            if(tempArray.Length == Count)
            {
                array = new T[Count * 2];
                for(int i = 0; i < tempArray.Length; i++)
                {
                    array[i] = tempArray[i];
                }
                array[Count] = item;
            }
            else
            {
                array[Count] = item;
            }
            Count++;
        }

        public void Display()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
