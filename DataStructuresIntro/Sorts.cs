using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    internal class Sorts
    {
        public static void BubbleSort(int[] array)
        {
            bool isSwapped;
            int temp;
            for (int j = 0; j < array.Length - 1; j++)
            {
                isSwapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }
                if (!isSwapped) return;
            }
        }

        public static void SelectionSort(int[] array)
        {
            int smallestNum;
            int temp;
            for (int j = 0; j < array.Length; j++)
            {
                smallestNum = j;
                for (int i = j + 1; i < array.Length; i++)
                {
                    if (array[i] < array[smallestNum])
                    {
                        smallestNum = i;
                    }
                }
                temp = array[j];
                array[j] = array[smallestNum];
                array[smallestNum] = temp;
            }
        }
        public static void InsertionSort(int[] array)
        {
            int temp;
            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = j + 1; i > 0; i--)
                {
                    if (array[i] < array[i - 1])
                    {
                        temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                    else break;
                }
            }
        }
    }
}
