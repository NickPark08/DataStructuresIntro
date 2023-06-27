using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Insert(6);
        tree.Insert(7);
        tree.Insert(3);
        tree.Insert(4);
        tree.Insert(5);
        tree.Insert(2);
        tree.Insert(10);
        tree.Insert(9);

        Queue<int> Traversal = tree.InOrder();
        foreach(int val in Traversal)
        {
            Console.WriteLine(val);
        }
    }
}