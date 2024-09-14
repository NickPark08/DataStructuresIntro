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
        NonComparativeSorts sorts = new NonComparativeSorts();

        int[] array = new int[] { 50, 50, 50, 50, 50, 50, 50, 50, 50, 50};

        sorts.CountingSort(ref array);

        foreach(var val in array)
        {
            Console.WriteLine(val);
        }


        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}