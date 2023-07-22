using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        RecursiveSorts<int> sorts = new RecursiveSorts<int>();
        List<int> list = new List<int>() { 1, 2, 3, 4, 6 };
        int[] array = new[] { 55, 55, 55, 55, 55, 190, 11, 34};

        sorts.QuickSortHoare(array, 0, array.Length - 1);

        foreach (int num in array)
        {
            Console.WriteLine(num);
        }
    }
}