using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class Recursion
    {
        public int Countdown(int startNum, int endNum)
        {
            if (startNum < endNum) throw new ArgumentException("Cannot count up");

            if(startNum == endNum)
            {
                return endNum;
            }
            Console.WriteLine(startNum);
            return Countdown(startNum - 1, endNum);
        }
        public int SumArray(int[] array)
        {
            if (array == null) throw new ArgumentException("Array is null");

            return SumArray(array, 0, 0);
        }

        private int SumArray(int[] array, int sum, int index)
        {
            if (index == array.Length) return sum;

            sum += array[index];
            return SumArray(array, sum, index + 1);
        }

        public string ReverseString(string word)
        {
            return ReverseString(word);
        }
        //strings are char arrays, word[0] = __
        private string ReverseString(string word, string revWord)
        {
            
        }
    }
}
