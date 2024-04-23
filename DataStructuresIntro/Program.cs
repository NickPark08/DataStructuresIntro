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

        ////17, 10, 20, 5, 8, 12, 18, 19, 40, 50, 0, 7, 13, 4, 9, 6, 47, 53, 46, 48, 52, 54 
        //tree.Insert(17);
        //tree.Insert(3);
        //tree.Insert(20);
        //tree.Insert(1);
        //tree.Insert(2);
        //tree.Insert(12);
        //tree.Insert(18);
        //tree.Insert(19);
        //tree.Insert(47);
        ////tree.Insert(49);
        //tree.Insert(50);
        ////tree.Remove(3);
        ////tree.Remove(50);
        //tree.Insert(0); //< 1 -> 0
        //tree.Insert(1.5); // < 2 -> 7
        //tree.Insert(13); 
        //tree.Insert(.5); //  < 1 -> 4
        ////tree.Insert(.25);
        //tree.Insert(2.25); // < 3 -> 9
        //tree.Insert(1.25); // < 2 -> 6
        //tree.Insert(49); // 47
        //tree.Insert(51); // 53
        //tree.Insert(48); // 46
        //tree.Insert(49.5); // 48
        //tree.Insert(50.5); // 52
        //tree.Insert(17.5);
        //tree.Insert(18.5);
        //tree.Insert(19.5);
        //tree.Insert(21);

        //tree.Insert(52); // 54

        tree.Insert(46);
        tree.Insert(19);
        tree.Insert(50);
        tree.Insert(15);
        tree.Insert(23);
        tree.Insert(48);
        tree.Insert(52);
        tree.Insert(14);
        tree.Insert(16);
        tree.Insert(22);
        tree.Insert(24);
        //tree.Insert(47);
        //tree.Insert(49);
        //tree.Insert(51);
        //tree.Insert(53);
        tree.Insert(12);
        tree.Insert(11);


        tree.Remove(15);
        ;
        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}