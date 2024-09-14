using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    interface IKeyable
    {
        public int Key { get; }
    }
    class NonComparativeSorts
    {
        public void CountingSort<T>(ref int[] dataset)
        {
            if (dataset.Length == 0) return;

            int maxVal = dataset.Max();
            int minVal = dataset.Min();
            int[] buckets = new int[maxVal - minVal + 2];

            for(int i = 0; i < dataset.Length; i++)
            {
                buckets[dataset[i] - minVal]++;
            }

            int[] newArray = new int[dataset.Length];
            int index = 0;
            for(int i = 0; i < buckets.Length; i++)
            {
                for(int j = 0; j < buckets[i]; j++)
                {
                    newArray[index] = i + minVal;
                    index++;
                }
            }

            dataset = newArray;
        }
        public void PigeonholeSort<T>(ref T[] dataset) where T : IKeyable
        {
            if (dataset.Length == 0) return;

            int maxVal = dataset.Max(m => m.Key);
            int minVal = dataset.Min(m => m.Key);
            T[] buckets = new T[maxVal - minVal + 2];

            for (int i = 0; i < dataset.Length; i++)
            {
                //buckets[dataset[i].Key - minVal]++;
            }

            T[] newArray = new T[dataset.Length];
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = 0; j < buckets[i].Key; j++)
                {
                    //newArray[index].Key = i + minVal;
                    index++;
                }
            }

            dataset = newArray;
        }
    }


}
