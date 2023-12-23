using DataStructures;

using DataStructuresIntro;

using System.Data;
using System.Reflection;

using System.IO;
using System.Text.Json;

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

        QuickUnion<string> union = new QuickUnion<string>(arr);

        foreach (var edge in arr2)
        {
            union.Union(edge.FriendA, edge.FriendB);
        }
        List<int> list = new List<int>();
        // find largest and smallest sets
        foreach (var val in arr)
        {
            if (!list.Contains(union.Find(val)))
            {

                list.Add(union.Find(val));
            }
        }
        Console.WriteLine(list.Count);



    }
}