using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        SkipList<int> skipList = new SkipList<int>();

        skipList.Add(3);
        skipList.Add(1);
        skipList.Add(2);
        skipList.Add(4);
        skipList.Add(5);
        skipList.Add(6);
        skipList.Add(7);
        skipList.Add(8);
        skipList.Add(171);
        skipList.Add(20);

        ;
    }
}