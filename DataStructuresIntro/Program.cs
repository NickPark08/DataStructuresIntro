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
        heap.Display();
    }
}