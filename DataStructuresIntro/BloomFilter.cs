using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataStructures
{
    public class BloomFilter<T>
    {
        bool[] array;
        List<Func<T, int>> set;

        public BloomFilter(int cap) 
        {
            array = new bool[cap];
            set = new List<Func<T, int>>();
            LoadHashFunc(HashFuncOne);
            LoadHashFunc(HashFuncTwo);
            LoadHashFunc(HashFuncThree);
        }
        public void Insert(T value)
        {
            for(int i = 0; i < set.Count; i++)
            {
                int temp = set[i](value) % array.Length;
                array[temp] = true;
            }
        }

        public bool ProbablyContains(T value)
        {
            for (int i = 0; i < set.Count; i++)
            {
                int temp = set[i](value) % array.Length;
                if (array[temp] == false) return false;
            }
            return true;
        }

        public void LoadHashFunc(Func<T, int> hashFunc)
        {
            set.Add(hashFunc);
        }

        private int HashFuncOne(T value)
        {
            return value.GetHashCode();
        }
        private int HashFuncTwo(T value)
        {
            return value.GetHashCode() * 34;
        }
        private int HashFuncThree(T value) 
        {
            return value.GetHashCode() + 1722;
        }
    }
}
