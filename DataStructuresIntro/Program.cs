using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        //int[] array = { 132, 234, 123, 43, 64643, 434, 788, 23, -23 };

        //Sorts bubbleSort = new Sorts();

        //GenericList<float> genericList = new GenericList<float>(3);
        //genericList.Add(12.4f);
        //genericList.Add(1.1f);
        //genericList.Add(4343.32f);
        //genericList.Add(3243.3f);

        ////genericList.Count = 200000;

        //genericList.Display();


        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        //list.AddFirst(5);
        //list.AddAfter(2, list.Head);
        //list.AddAfter(3, list.Head.Next);
        //list.AddAfter(2, list.Head.Next.Next);
        //list.AddLast(5);
        //list.AddLast(2);
        //list.AddLast(3);
        //list.AddLast(2);
        list.AddFirst(1);

        list.Display();

    }
}