using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        ArrayQueue<int> queue = new ArrayQueue<int>(2);

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);

        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
    }
}