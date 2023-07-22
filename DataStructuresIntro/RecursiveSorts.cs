using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

        //QUICK SORT (Lomuto Partition)
        public void QuickSortLomuto(T[] array, int left, int right)
        {
            if (left >= right) return;

            int pivot = LomutoPartition(array, left, right);
            QuickSortLomuto(array, left, pivot - 1);
            QuickSortLomuto(array, pivot + 1, right);
        }
        private static int LomutoPartition(T[] array, int left, int right)
        {
            int wall = left - 1;
            int pivot = right;

            for (int i = left; i < right; i++)
            {
                if (array[i].CompareTo(array[pivot]) < 0)
                {
                    wall++;
                    T temp = array[i];
                    array[i] = array[wall];
                    array[wall] = temp;
                }
            }
            T temp2 = array[pivot];
            array[pivot] = array[wall + 1];
            array[wall + 1] = temp2;

            return wall + 1;
        }

        //QUICK SORT (Hoare Partition)

        public void QuickSortHoare(T[] array, int left, int right)
        {
            if (left >= right) return;

            int pivot = HoarePartition(array, left, right);
            QuickSortHoare(array, left, pivot);
            QuickSortHoare(array, pivot + 1, right);

        }
        private static int HoarePartition(T[] array, int left, int right)
        {
            int pivot = left;
           /* while (true)
            {
                
                bool found = false;
                for (int i = left + 1; i < right; i++)
                {
                    if (array[i].Equals(array[pivot]))
                    {
                        found = true;
                    }
                }
                if (found) break;
            }*/

            while (true)
            {
                //if (array[left].Equals(array[right]))
                //{
                //    return left;
                //}
                while (left != pivot && array[left].CompareTo(array[pivot]) <= 0)
                {
                    left++;
                }
                while (right != pivot && array[right].CompareTo(array[pivot]) >= 0)
                {
                    right--;
                }

                int tempIndex = pivot;

                if (pivot == left)
                {
                    tempIndex = right;
                }
                else if (pivot == right)
                {
                    tempIndex = left;
                }

                T temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                pivot = tempIndex;

                if (left >= right) return right;
            }
        }
    }
}

