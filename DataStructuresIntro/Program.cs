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
        WeightedDirectedGraph<string> graph = new WeightedDirectedGraph<string>();
        Random randy = new Random();

        List<WDVertex<string>> vertices = new List<WDVertex<string>>();

        string airportVertices = File.ReadAllText(@"..\..\..\AirportVertices.txt");
        string airportEdges = File.ReadAllText(@"..\..\..\AirportEdges.txt");

        var arr =  JsonSerializer.Deserialize<string[]>(airportVertices);
        var arr2 = JsonSerializer.Deserialize<AirportEdge[]>(airportEdges);

        foreach (string vertex in arr)
        {
            graph.AddVertex(new WDVertex<string>(vertex));
        }
        foreach(var edge in arr2)
        {
            var start = graph.Search(edge.Start);
            var end = graph.Search(edge.End);

            graph.AddEdge(start, end, edge.Distance);
        }

        graph.Dijkstra(graph.Search("SEA"), graph.Search("PHL"));
        graph.AStar(graph.Search("PDX"), graph.Search("DCA"));
    }
}