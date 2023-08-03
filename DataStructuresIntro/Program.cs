using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        AVLTree<int> AVLTree = new AVLTree<int>();

        AVLTree.Insert(5);
        AVLTree.Insert(3);
        AVLTree.Insert(4);

        Console.WriteLine(AVLTree.Root.Value);
        Console.WriteLine(AVLTree.Root.GetBalance());
    }
}