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

        Console.WriteLine(tree.Minimum());
        Console.WriteLine(tree.Maximum());
        Console.WriteLine();

        Console.WriteLine(tree.Delete(2));
        Console.WriteLine(tree.Delete(4));
        Console.WriteLine(tree.Delete(10));
        Console.WriteLine(tree.Delete(9));
        Console.WriteLine(tree.Delete(7));
        Console.WriteLine(tree.Delete(6));
        Console.WriteLine(tree.Delete(5));
        Console.WriteLine(tree.Delete(3));

        Console.WriteLine();
        Console.WriteLine(tree.Minimum());
        Console.WriteLine(tree.Maximum());
    }
}