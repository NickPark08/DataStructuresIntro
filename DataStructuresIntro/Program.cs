using DataStructures;

using DataStructuresIntro;

using System.Data;
using System.Reflection;

using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        RedBlackTree<int> tree= new RedBlackTree<int>();
        AVLTree<int> testTree = new AVLTree<int>();

        //tree.Insert(10);
        //tree.Insert(5);
        //tree.Insert(15);
        //tree.Insert(20);
        //tree.Insert(2);
        //tree.Insert(3);
        //tree.Insert(4);

        testTree.Insert(17);
        testTree.Insert(3);
        testTree.Insert(20);
        testTree.Insert(1);
        testTree.Insert(2);
        testTree.Insert(12);
        testTree.Insert(18);
        testTree.Insert(19);
        testTree.Insert(47);


        tree.Insert(17);
        tree.Insert(3);
        tree.Insert(20);
        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(12);
        tree.Insert(18);
        tree.Insert(19);
        tree.Insert(47);

        ;
        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}