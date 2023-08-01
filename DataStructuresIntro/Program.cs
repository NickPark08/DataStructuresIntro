using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {
        AVLTree<int> AVLTree = new AVLTree<int>();

        AVLTree.Insert(10);
        AVLTree.Insert(9);
        AVLTree.Insert(8);
        //AVLTree.Insert(7);

        Console.WriteLine(AVLTree.Root.Value);
    }
}