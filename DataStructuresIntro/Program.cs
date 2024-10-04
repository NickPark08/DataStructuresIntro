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

        int[] array2 = new int[20];
        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = (gen.Next(0, 1000));
        }
        sorts.MSDRadixSort(array2);


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