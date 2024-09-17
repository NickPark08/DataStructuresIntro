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
        public int Key { get; set; }
    }
    class IKeyableInt : IKeyable
    {
        public int Key { get; set; }

        public IKeyableInt(int key)
        {
            this.Key = key;
        }
    }

    class NonComparativeSorts
    {
        public void BucketSort(ref int[] array)
        {
            int minVal = array.Min();
            int maxVal = array.Max();   
            List<int>[] buckets = new List<int>[array.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }
            
            //check why 83 not being added to a bucket
            int compare = maxVal / buckets.Count();
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < buckets.Count(); j++)
                {
                    if (array[i] < compare * (j + 1))
                    {
                        buckets[j].Add(array[i]);
                        break;
                    }
                }
            }
            foreach(var list in buckets)
            {
                list.Sort();
            }
            int index = 0;
            foreach(var list in buckets)
            {
                foreach(var val in list)
                {
                    array[index] = val;
                    index++;
                }
            }
        }
        public void PigeonholeSort<T>(ref T[] dataset) where T : IKeyable
        {
            if (dataset.Length == 0) return;

            int maxVal = dataset.Max(m => m.Key);
            int minVal = dataset.Min(m => m.Key);
            List<T>[] buckets = new List<T>[maxVal - minVal + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<T>();
            }

            for (int i = 0; i < dataset.Length; i++)
            {
                buckets[dataset[i].Key - minVal].Add(dataset[i]);
            }

            T[] newArray = new T[dataset.Length];
            int index = 0;
            foreach (var list in buckets)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    newArray[index] = list[i];
                    index++;
                }
            }

            dataset = newArray;
        }
        public void CountingSort(ref int[] dataset)
        {
            if (dataset.Length == 0) return;

            int maxVal = dataset.Max();
            int minVal = dataset.Min();
            int[] buckets = new int[maxVal - minVal + 2];

            for (int i = 0; i < dataset.Length; i++)
            {
                buckets[dataset[i] - minVal]++;
            }

            int[] newArray = new int[dataset.Length];
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = 0; j < buckets[i]; j++)
                {
                    newArray[index] = i + minVal;
                    index++;
                }
            }

            dataset = newArray;
        }
        
    }


}
