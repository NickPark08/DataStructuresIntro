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

        List<int> list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 12};
        List<int> list2 = new List<int>() { 1, 3, 5, 7, 9, 11, 13 };


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
        Console.WriteLine();


        var union = tree.Union(tree2);
        foreach(var val in union)
        {
            Console.Write($"{val}, ");
        }

        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}