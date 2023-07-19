using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        RecursiveSorts<int> sorts= new RecursiveSorts<int>();
        List<int> list = new List<int>() { 1, 2, 3, 4, 6 }; 

        list = sorts.MergeSort(list);

        foreach(int num in list)
        {
            Console.WriteLine(num); 
        }
    }
}