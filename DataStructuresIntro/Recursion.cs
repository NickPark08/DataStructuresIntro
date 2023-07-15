using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataStructuresIntro
{
    class Recursion<T> where T : IComparable
    {
        public int Countdown(int startNum, int endNum)
        {
            if (startNum < endNum) throw new ArgumentException("Cannot count up");

            if (startNum == endNum)
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
            return ReverseString(word, "", word.Length - 1);
        }
        private string ReverseString(string word, string revWord, int index)
        {
            if (index < 0) return revWord;

            revWord += word[index];
            return ReverseString(word, revWord, index - 1);
        }

        public string IncreasingTriangle()
        {
            return IncreasingTriangle(10, 1);
        }
        private string IncreasingTriangle(int spaces, int stars)
        {
            string triangle = "";
            if (spaces < 0 && stars > 9) return triangle;

            for (int i = 0; i < spaces; i++)
            {
                triangle += " ";
            }
            for (int i = 0; i < stars; i++)
            {
                triangle += "*";
            }

            Console.WriteLine(triangle);
            return IncreasingTriangle(spaces - 1, stars + 2);
        }
        public List<T> MergeSort(List<T> list)
        {
            if (list.Count < 2)
            {
                return list;
            }

            List<T> list1 = new List<T>();
            List<T> list2 = new List<T>();

            for (int i = 0; i < list.Count / 2; i++)
            {
                list1.Add(list[i]);
            }
            for (int i = list.Count / 2; i < list.Count; i++)
            {
                list2.Add(list[i]);
            }
            MergeSort(list1);
            MergeSort(list2);

            return Merge(list1, list2, list);
        }
        //fix sorting list
        private List<T> Merge(List<T> list1, List<T> list2, List<T> sortedList)
        {
            for(int i = 0, j = 0; i < list1.Count && j < list2.Count;)
            {
                if (list1[i].CompareTo(list2[j]) < 0)
                {
                    sortedList.Add(list1[i]);
                    i++;
                }
                else if (list2[j].CompareTo(list1[i]) < 0)
                {
                    sortedList.Add(list2[j]);
                    j++;
                }
            }
            return sortedList;
        }
    }
}
