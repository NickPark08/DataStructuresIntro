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
        BTree<int> tree = new BTree<int>();

        tree.Insert(1);
        tree.Insert(6);
        tree.Insert(7);
        tree.Insert(4);

        tree.Insert(2);
        tree.Insert(6);
        //tree.Insert(5);
        //tree.Insert(4);
        //tree.Insert(7);
        //tree.Insert(8);
        //tree.Insert(9);
        //tree.Insert(10);
        //tree.Insert(11);
        //tree.Insert(12);


        ;
        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}