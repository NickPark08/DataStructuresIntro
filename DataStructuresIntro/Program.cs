using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        BinaryHeap<int> heap = new BinaryHeap<int>();
        heap.Insert(10);
        heap.Insert(20);
        heap.Insert(30);
        heap.Insert(12);
        heap.Insert(52);
        heap.Insert(100);
        heap.Insert(8);
        heap.Insert(5);
        heap.Insert(72);
        heap.Insert(43);
        int test = heap.Pop();
        heap.Display();
        Console.WriteLine(test);
    }
}