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
        WeightedDirectedGraph<int> graph = new WeightedDirectedGraph<int>();
        Random randy = new Random();

        WDVertex<int>[] vertices = new WDVertex<int>[7];

        //A = 1, G = 7

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new WDVertex<int>(i);
            graph.AddVertex(vertices[i]);
        }

        graph.AddEdge(vertices[0], vertices[1], 1f);
        graph.AddEdge(vertices[2], vertices[0], 1f);
        graph.AddEdge(vertices[3], vertices[2], 1f);
        graph.AddEdge(vertices[1], vertices[4], 1f);
        graph.AddEdge(vertices[4], vertices[5], 1f);
        graph.AddEdge(vertices[5], vertices[1], 1f);
        graph.AddEdge(vertices[5], vertices[6], 1f);

        (bool cycle, List<WDVertex<int>> journey) result = graph.BellmanFord(vertices[3], vertices[6]);
        Console.WriteLine("Has negative cycle: " + !result.cycle);
        Console.WriteLine();
        if (result.cycle)
        {
            foreach (var vertex in result.journey)
            {
                Console.WriteLine(vertex.Value);
            }
        }

        //string airportVertices = File.ReadAllText(@"..\..\..\AirportVertices.txt");
        //string airportEdges = File.ReadAllText(@"..\..\..\AirportEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(airportVertices);
        //var arr2 = JsonSerializer.Deserialize<AirportEdge[]>(airportEdges);

        //foreach (string vertex in arr)
        //{
        //    graph.AddVertex(new WDVertex<string>(vertex));
        //}
        //foreach (var edge in arr2)
        //{
        //    var start = graph.Search(edge.Start);
        //    var end = graph.Search(edge.End);

        //    graph.AddEdge(start, end, edge.Distance);
        //}

        //graph.Dijkstra(graph.Search("SEA"), graph.Search("PHL"));
        //graph.AStar(graph.Search("PDX"), graph.Search("DCA"));





    }
}