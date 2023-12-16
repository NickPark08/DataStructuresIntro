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
        WeightedDirectedGraph<char> graph = new WeightedDirectedGraph<char>();
        Random randy = new Random();

        HashMap<int, string> map = new HashMap<int, string>();

        map.Add(0, "zero");
        map.Add(1, "one");
        map.Add(2, "two");

        var enumerator = map.GetEnumerator();

        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current.Value);
        }

        ;
        //string airportVertices = File.ReadAllText(@"..\..\..\AirportVertices.txt");
        //string airportEdges = File.ReadAllText(@"..\..\..\AirportEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(airportVertices);
        //var arr2 = JsonSerializer.Deserialize<AirportEdge[]>(airportEdges);
    }
}