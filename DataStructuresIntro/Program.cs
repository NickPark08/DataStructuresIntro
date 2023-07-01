using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        Recursion recursion = new Recursion();
        int[] array = new int[] { 2, 323, 5 };
        Console.WriteLine(recursion.SumArray(array));
    }
}