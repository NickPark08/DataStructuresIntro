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
        queue.Enqueue(6);
        queue.Enqueue(7);
        queue.Enqueue(8);
        queue.Enqueue(9);
        queue.Enqueue(10);

        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(queue.Dequeue());
        }
        Console.WriteLine(queue.Peek());

        queue.Enqueue(11);
        queue.Enqueue(12);
        queue.Enqueue(13);
        queue.Enqueue(14);
        queue.Enqueue(15);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(queue.Dequeue());
            queue.Enqueue(48);
        }

        for (int i = 0; i < 13; i++)
        {
            Console.WriteLine(queue.Dequeue());
        }
    }
}