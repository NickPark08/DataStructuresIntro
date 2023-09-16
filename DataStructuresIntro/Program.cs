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
        ;
    }
}