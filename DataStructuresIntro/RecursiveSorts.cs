using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class RecursiveSorts<T> where T : IComparable<T>
    {
        //MERGE SORT

        public List<T> MergeSort(List<T> list)
        {
            if (list.Count < 2)
            {
                return list;
            }

            List<T> list1 = new List<T>();
            List<T> list2 = new List<T>();
            int mid = list.Count / 2;

            for (int i = 0; i < list.Count; i++)
            {
                if (i < mid)
                {
                    list1.Add(list[i]);
                }
                else
                {
                    list2.Add(list[i]);
                }
            }

            return Merge(MergeSort(list1), MergeSort(list2));
        }
        private static List<T> Merge(List<T> list1, List<T> list2)
        {
            List<T> sortedList = new List<T>();
            bool list1Added = true;
            int i, j = 0;
            for (i = 0, j = 0; i < list1.Count && j < list2.Count;)
            {
                if (list1[i].CompareTo(list2[j]) < 0)
                {
                    sortedList.Add(list1[i]);
                    i++;
                    list1Added = true;
                }
                else if (list2[j].CompareTo(list1[i]) < 0)
                {
                    sortedList.Add(list2[j]);
                    j++;
                    list1Added = false;
                }
                else
                {
                    sortedList.Add(list1[i]);
                    sortedList.Add(list2[j]);
                    i++;
                    j++;
                }
            }

            if (list1Added)
            {
                for (int x = j; x < list2.Count; x++)
                {
                    sortedList.Add(list2[x]);
                }
            }
            else
            {
                for (int x = i; x < list1.Count; x++)
                {
                    sortedList.Add(list1[x]);
                }
            }

            return sortedList;
        }

        //QUICK SORT (Hoare Partition)

        public T[] QuickSort()
        {

        }
    }
}
