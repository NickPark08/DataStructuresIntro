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
        HashSet<T> set;

        public BloomFilter(int cap) 
        {
            array = new bool[cap];
            set = new HashSet<T>();
        }
        public void Insert(T value)
        {

        }

        public void LoadHashFunc(Func<T, int> hashFunc)
        {
            //hashFunc
            //delegate intro
        }

        private int HashFuncOne(T value)
        {
            return value.GetHashCode();
        }
        private int HashFuncTwo(T value)
        {
            return value.GetHashCode() * 88;
        }
        private int HashFuncThree(T value) 
        {
            return value.GetHashCode() + 82932;
        }
    }
}
