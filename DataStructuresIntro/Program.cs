﻿using DataStructuresIntro;

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
        AVLTree.Delete(2);
        AVLTree.Delete(7);

        ;

  
    }
}