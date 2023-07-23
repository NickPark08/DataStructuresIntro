using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        RecursiveSorts<int> sorts= new RecursiveSorts<int>();
        List<int> list = new List<int>() { 1, 2, 3, 4, 6 };
        int[] array = new[] { 1, 5, 3, 7, 11, 9, 13, 2 }; 

        sorts.QuickSortLomuto(array, 0, array.Length - 1);

        foreach(int num in array)
        {
            Console.WriteLine(num); 
        }
    }
}