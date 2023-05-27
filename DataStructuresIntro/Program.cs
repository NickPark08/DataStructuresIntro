using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        list.AddLast(1);
        list.AddLast(4);
        list.AddLast(3);
        list.AddLast(2);
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(7);
        DoublyLinkedListNode<int> test = list.Search(3);

        //get enumerator

        //IEnumerator<int> enumerator = list.GetEnumerator();
        //while(enumerator.MoveToNextItem())
        //{
        //    Console.WriteLine(enumerator.CurrentItem.Value);
        //}

        foreach (int value in list)
        {
            Console.WriteLine(value);
        }

        Console.WriteLine(list.IsEmpty());
        Console.WriteLine();
        list.AddAfter(101, test);
        foreach (int value in list)
        {
            Console.WriteLine(value);
        }
    }
}