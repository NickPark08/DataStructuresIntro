using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        Recursion<int> recursion= new Recursion<int>();
        List<int> list = new List<int>() { 5, 1, 123, 7, 32};

        list = recursion.MergeSort(list);

        foreach(int num in list)
        {
            Console.WriteLine(num); 
        }
    }
}