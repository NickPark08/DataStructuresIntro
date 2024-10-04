using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        //public void MSDRadixSort(ref int[] array)
        //{
        //    // start MSD radix sort
        //    // first digit into buckets, then recurse and keep adding to buckets until size <= 1
        //    // think bitwise instead of decimal

        //    int[] buckets = new int[10];
        //    int max = array.Max();
        //    int digit = 1;
        //    while(max >= 10)
        //    {
        //        max /= 10;
        //        digit++;
        //    }
        //    array = MSDRadixHelper(array, 0, array.Length - 1, 0);

        //}
        //private int[] MSDRadixHelper(int[] array, int low, int high, int digit)
        //{
        //    if (low >= high) return array;

        //    while(low != high)
        //    { 
        //        int temp = array[low];
        //        int count = 0;
        //        while (temp != 0)
        //        {
        //            temp >>= 1;
        //            count++;
        //        }
        //        count -= digit;
        //        if ((array[low] & count) == 1)
        //        {
        //            var temp2 = array[low];
        //            array[low] = array[high];
        //            array[high] = temp;
        //            high--;
        //        }
        //        else
        //        {
        //            low++;
        //        }
        //    }

        //    MSDRadixHelper(array, low, high, digit - 1);

        //    return array;
        //}


        private int GetDigit(int number, int digitPosition)
        {
            return (number / (int)Math.Pow(10, digitPosition)) % 10;
        }

        private int GetMaxDigits(int[] array)
        {
            int max = array[0];
            foreach (int num in array)
            {
                if (num > max) max = num;
            }
            return max.ToString().Length;
        }
        private void MSDRadixSortHelper(int[] array, int left, int right, int digitPosition)
        {
            if (left >= right || digitPosition < 0)
                return;

            List<int>[] buckets = new List<int>[10];
            for (int i = 0; i < 10; i++)
                buckets[i] = new List<int>();

            for (int i = left; i <= right; i++)
            {
                int digit = GetDigit(array[i], digitPosition);
                buckets[digit].Add(array[i]);
            }

            int index = left;
            for (int i = 0; i < 10; i++)
            {
                if (buckets[i].Count > 0)
                {
                    foreach (int num in buckets[i])
                        array[index++] = num;

                    MSDRadixSortHelper(array, index - buckets[i].Count, index - 1, digitPosition - 1);
                }
            }
        }

        public void MSDRadixSort(int[] array)
        {
            int maxDigits = GetMaxDigits(array);
            MSDRadixSortHelper(array, 0, array.Length - 1, maxDigits - 1);
        }

        public void BitwiseRadixSort(ref uint[] array)
        {
            // &, |, ^, ~, >>, <<

            int[] buckets = new int[2];
            uint[] output = new uint[array.Length];
            uint max = array.Max();
            uint index = 1;
            int shift = 0;

            for(int j = 0; j < max; j++)
            {
                foreach (var val in array)
                {
                    //buckets[(val) % (digit * 10) / digit]++;
                    uint temp = (val & index) >> shift;
                    buckets[temp]++;
                }
                for (int i = 1; i < buckets.Length; i++)//offset
                {
                    buckets[i] += buckets[i - 1];
                }
                for (int i = output.Length - 1; i >= 0; i--)
                {
                    //buckets[(array[i] - minVal) % (digit * 10) / digit]--;
                    //output[buckets[(array[i] - minVal) % (digit * 10) / digit]] = array[i];
                    uint temp = (array[i] & index) >> shift;
                    buckets[temp]--;
                    output[buckets[temp]] = array[i];
                }
                for (int i = 0; i < output.Length; i++)
                {
                    array[i] = output[i];
                }
                //output = new uint[array.Length];
                buckets = new int[2];
                index*=2;
                shift++;
                //if (index > (max / 2) + 1) break;
            }
        }
        public void PostmanSort(ref string[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i].ToLower();
            }

            int[] buckets = new int[26];
            int index = 1;
            string[] output = new string[array.Length];
            int max = array.Max(m => m.Length);

            while (index <= max) // change later
            {
                foreach (var str in array)
                {
                    int temp = str[str.Length - index] - 97;
                    buckets[temp]++;
                }
                for (int i = 1; i < buckets.Length; i++)//offset
                {
                    buckets[i] += buckets[i - 1];
                }
                for (int i = output.Length - 1; i >= 0; i--)
                {
                    int temp = 0;
                    if (array[i].Length >= index)
                    {
                        temp = array[i][array[i].Length - index] - 97;
                    }
                    buckets[temp]--;
                    output[buckets[temp]] = array[i];
                }
                for (int i = 0; i < output.Length; i++)
                {
                    array[i] = output[i];
                }
                output = new string[array.Length];
                buckets = new int[26];
                index++;
            }
        }
        public void KeyedRadixSort<T>(ref T[] array) where T : IKeyable
        {
            int[] buckets = new int[10];
            int digit = 1;
            int[] output = new int[array.Length];
            int maxVal = array.Max(m => m.Key);
            int minVal = array.Min(m => m.Key);

            while (digit < maxVal * 10)
            {
                foreach (var val in array)
                {
                    buckets[(val.Key - minVal) % (digit * 10) / digit]++;
                }
                for (int i = 1; i < buckets.Length; i++)//offset
                {
                    buckets[i] += buckets[i - 1];
                }
                for (int i = output.Length - 1; i >= 0; i--)
                {
                    buckets[(array[i].Key - minVal) % (digit * 10) / digit]--;
                    output[buckets[(array[i].Key - minVal) % (digit * 10) / digit]] = array[i].Key;
                }
                for (int i = 0; i < output.Length; i++)
                {
                    array[i].Key = output[i];
                }
                output = new int[array.Length];
                buckets = new int[10];
                digit *= 10;
            }
        }
        public void RadixSort(ref int[] array)
        {
            int[] buckets = new int[10];
            int digit = 1;
            int[] output = new int[array.Length];
            int maxVal = array.Max();
            int minVal = array.Min();

            while(digit < maxVal * 10)
            {
                foreach (var val in array)
                {
                    buckets[(val - minVal) % (digit * 10) / digit]++;
                }
                for (int i = 1; i < buckets.Length; i++)//offset
                {
                    buckets[i] += buckets[i - 1];
                }
                for (int i = output.Length - 1; i >= 0; i--)
                {
                    buckets[(array[i] - minVal) % (digit * 10) / digit]--;
                    output[buckets[(array[i] - minVal) % (digit * 10) / digit]] = array[i];
                }
                for(int i = 0; i < output.Length; i++)
                {
                    array[i] = output[i];
                }
                output = new int[array.Length];
                buckets = new int[10];
                digit *= 10;
            }

        }
        public void KeyedBucketSort<T>(ref T[] array) where T : IKeyable
        {
            int minVal = array.Min(m => m.Key);
            int maxVal = array.Max(m => m.Key);
            List<int>[] buckets = new List<int>[array.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            int compare = (maxVal + (10 - maxVal % 10)) / buckets.Count();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < buckets.Count(); j++)
                {
                    if (array[i].Key < compare * (j + 1))
                    {
                        buckets[j].Add(array[i].Key);
                        break;
                    }
                }
            }
            foreach (var list in buckets)
            {
                list.Sort();
            }
            int index = 0;
            foreach (var list in buckets)
            {
                foreach (var val in list)
                {
                    array[index].Key = val;
                    index++;
                }
            }
        }

        public void BucketSort(ref int[] array)
        {
            int minVal = array.Min();
            int maxVal = array.Max();   
            List<int>[] buckets = new List<int>[array.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }
            
            int compare = (maxVal + (10 - maxVal % 10)) / buckets.Count();
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
