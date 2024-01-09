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
        UndirectedUnweightedGraph<char> graph = new UndirectedUnweightedGraph<char>();
        Random randy = new Random();


        string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

        QuickFind<string> union = new QuickFind<string>(arr);

        foreach (var edge in arr2)
        {
            union.Union(edge.FriendA, edge.FriendB);
        }
        List<int> list = new List<int>();
        int[] ints = new int[arr.Length];

        foreach (var val in arr)
        {
            if (!list.Contains(union.Find(val)))
            {
                list.Add(union.Find(val));
            }
            ints[union.Find(val)]++;
            Console.WriteLine(val + " --> " + union.Find(val));

        }
        Console.WriteLine(list.Count);
        Console.WriteLine();
        int largest = ints[0];
        int smallest = 10;
        for (int i = 0; i < ints.Length; i++)
        {
            if (ints[i] > largest)
            {
                largest = i;
            }
            if (ints[i] != 0 && ints[i] < smallest)
            {
                smallest = i;
            }
        }

        Console.WriteLine("Largest:");
        foreach (var val in arr)
        {
            if (union.Find(val) == largest)
            {
                Console.WriteLine(val);
            }
        }
        Console.WriteLine();

        Console.WriteLine("Smallest:");
        foreach (var val in arr)
        {
            if (union.Find(val) == smallest)
            {
                Console.WriteLine(val);
            }
        }

        Console.WriteLine();
        Console.WriteLine(union.AreConnected("Phoebe", "Rachel"));
        Console.WriteLine(union.AreConnected("Michael", "Pam"));
        Console.WriteLine(union.AreConnected("Chandler", "Creed"));
        Console.WriteLine();

        for (int i = 1; i < arr.Length; i++)
        {
            if (ints[i] != 0)
            {
                Console.Write($"Group {i}: ");
                foreach (var val in arr)
                {
                    if (union.Find(val) == i)
                    {
                        Console.Write(val + ", ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}