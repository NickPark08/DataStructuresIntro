using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();
        ArrayStack<int> stack = new ArrayStack<int>(3);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        foreach (int value in stack)
        {
            Console.WriteLine(value);
        }
        Console.WriteLine();

        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());

        Console.WriteLine();
        foreach (int value in stack)
        {
            Console.WriteLine(value);
        }


        //get enumerator

        //IEnumerator<int> enumerator = list.GetEnumerator();
        //while(enumerator.MoveToNextItem())
        //{
        //    Console.WriteLine(enumerator.CurrentItem.Value);
        //}

        //foreach (int value in list)
        //{
        //    Console.WriteLine(value);
        //}

        //foreach (int value in list)
        //{
        //    Console.WriteLine(value);
        //}

    }
}