using DataStructures;

using DataStructuresIntro;

using System.Data;
using System.Reflection;

using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.ComponentModel;

class Program
{
    public static void Main()
    {
        RedBlackTree<int> tree = new(null);
        RedBlackTree<int> tree2 = new(null);

        List<int> list = new List<int>() {3, 23, 5, 1, 7, 72, 19, 92, 12, 61 };
        List<int> list2 = new List<int>() { 7, 912, 421, 3, 23, 19, 76, 61, 27, 81, 6432, 123 };


        tree.AddRange(list);
        tree2.AddRange(list2);
        var temp = tree.InOrder();
        foreach(var val in temp)
        {
            Console.Write($"{val}, ");
        }
        Console.WriteLine();
        var temp4 = tree2.InOrder();
        foreach(var val in temp4)
        {
            Console.Write($"{val}, ");
        }
        Console.WriteLine();

        RedBlackTree<int> temp2 = (RedBlackTree<int>)tree.Union(tree2);
        RedBlackTree<int> temp3 = (RedBlackTree<int>)tree.Intersection(tree2);

        var temp5 = temp2.InOrder();
        var temp6 = temp3.InOrder();

        foreach(var val in temp5)
        {
            Console.Write($"{val}, ");
        }
        Console.WriteLine();
        foreach (var val in temp6)
        {
            Console.Write($"{val}, ");
        }

        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}