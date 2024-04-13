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
        RedBlackTree<double> tree= new RedBlackTree<double>();

        //17, 3, 20, 1, 2, 12, 18, 19, 47, 49, 50
        tree.Insert(17);
        tree.Insert(3);
        tree.Insert(20);
        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(12);
        tree.Insert(18);
        tree.Insert(19);
        tree.Insert(47);
        //tree.Insert(49);
        tree.Insert(50);
        //tree.Remove(3);
        //tree.Remove(50);
        tree.Insert(0);
        tree.Insert(1.5);
        tree.Insert(13);
        tree.Insert(.5);
        //tree.Insert(.25);
        tree.Insert(2.25);
        tree.Insert(1.25);

        tree.Remove(50);
        ;
        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}