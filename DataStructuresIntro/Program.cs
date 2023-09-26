using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        SkipList<int> skipList = new SkipList<int>();
        int[] ints = new int[10];

        skipList.Add(3);
        skipList.Add(1);
        skipList.Add(2);
        skipList.Add(4);
        skipList.Add(5);
        skipList.Add(6);
        skipList.Add(7);
        skipList.Add(8);
        skipList.Add(9);
        skipList.Add(10);
        skipList.Remove(5);
        skipList.Remove(6);
        skipList.Remove(2);
        skipList.Remove(8);

        foreach (int num in skipList)
        {
            Console.WriteLine(num);
        }
        ;
    }
}