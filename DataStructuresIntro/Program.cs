using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Insert(6);
        tree.Insert(5);
        tree.Insert(0);
        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(3);
        tree.Insert(4);

        //fix bugs with deleting the root (don't allow deletion if there is no root/tree to begin with)

        Console.WriteLine(tree.Minimum());
        Console.WriteLine(tree.Maximum());
        Console.WriteLine();

        Console.WriteLine(tree.Delete(6));
        Console.WriteLine(tree.Delete(0));

        Console.WriteLine();
        Console.WriteLine(tree.Minimum());
        Console.WriteLine(tree.Maximum());
    }
}