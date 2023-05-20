using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        //list.AddLast(1);
        //list.AddLast(4);
        //list.AddLast(3);
        //list.AddLast(2);
        //list.AddLast(7);
        //DoublyLinkedListNode<int> test = list.Search(3);

        //get enumerator
        EnumeratorObject<int> enumerator = list.GetEnumerator();
        while(enumerator.MoveToNextItem())
        {
            Console.WriteLine(enumerator.CurrentItem.Value);
            //enumerator.MoveToNextItem();
        }
        //use enumerator to loop through list
        //print each item in list as you loop through it

        Console.WriteLine(list.IsEmpty());
        Console.WriteLine();

        list.Clear();

        //list.Display();
        Console.WriteLine(list.IsEmpty());
    }
}