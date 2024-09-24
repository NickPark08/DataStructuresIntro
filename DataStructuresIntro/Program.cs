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
        Random gen = new Random();

        IKeyableInt[] array = new IKeyableInt[10];
        for (int i = array.Length - 1; i >= 0; i--)
        {
            array[i] = new IKeyableInt(gen.Next(-1000, 1000));
        }

        string[] array2 = new string[] { "001", "010", "100", "0110", "110"};
        //int[] arary3 = new int[] { 0, 1, 2, 3, 4, 5 };
        sorts.BitwiseRadixSort(ref array2);


        foreach (var val in array2)
        {
            Console.WriteLine(val);
        }


        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}