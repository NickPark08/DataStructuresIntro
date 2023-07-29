using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        BinaryHeap<int> heap = new BinaryHeap<int>();

        List<int> list = new List<int>();
        List<int> result = new List<int>();

        Random rnd = new Random();
        for(int i = 0; i < 21; i++)
        {
            list.Add(rnd.Next(-100, 100));
        }
        for(int i = 0; i < list.Count; i++)
        {
            heap.Insert(list[i]);
        }
        for (int i = 0; i < list.Count - 1; i++)
        {
            result.Add(heap.Pop());
        }

        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
}