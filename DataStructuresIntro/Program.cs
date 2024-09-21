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
            array[i] = new IKeyableInt(gen.Next(-100, 100));
        }

        int[] array2 = new int[] { -12, 112, -2342, -2342, 123, -23, -1, 1, 3, 5, 6, 8, 99};
        sorts.RadixSort(ref array2);

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