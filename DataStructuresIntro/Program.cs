using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Main()
    {

        AVLTree<int> AVLTree = new AVLTree<int>();

        AVLTree.Insert(17);
        AVLTree.Insert(5);
        AVLTree.Insert(7);
        AVLTree.Insert(3);
        AVLTree.Insert(4);
        AVLTree.Insert(20);
        AVLTree.Insert(22);
        AVLTree.Insert(2);
        AVLTree.Insert(1);
        AVLTree.Insert(6);
        AVLTree.Delete(7);
        AVLTree.Insert(6);
        AVLTree.Insert(6);
        AVLTree.Insert(23);
        AVLTree.Delete(6);
        AVLTree.Delete(23);
        AVLTree.Delete(6);
        AVLTree.Insert(0);
        AVLTree.Insert(2);
        AVLTree.Delete(3);
        AVLTree.Delete(4);
        AVLTree.Delete(2);
        AVLTree.Delete(2);
        AVLTree.Delete(5);
        AVLTree.Delete(20);
        AVLTree.Delete(17);
        AVLTree.Delete(22);
        AVLTree.Delete(6);

        ;


    }
}