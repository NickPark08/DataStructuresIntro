using DataStructures;

using DataStructuresIntro;

using System.Data;
using System.Reflection;

class Program
{
    public static void Main()
    {
        WeightedDirectedGraph<int> graph = new WeightedDirectedGraph<int>();
        Random randy = new Random();

        WDVertex<int>[] vertices = new WDVertex<int>[8];

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new WDVertex<int>(i);
            graph.AddVertex(vertices[i]);
        }

        graph.AddEdge(vertices[0], vertices[1], 10);
        graph.AddEdge(vertices[0], vertices[2], 11);
        graph.AddEdge(vertices[0], vertices[3], 12);
        graph.AddEdge(vertices[1], vertices[3], 13);
        graph.AddEdge(vertices[2], vertices[1], 14);
        graph.AddEdge(vertices[2], vertices[4], 15);
        graph.AddEdge(vertices[2], vertices[5], 16);
        graph.AddEdge(vertices[3], vertices[5], 17);
        graph.AddEdge(vertices[4], vertices[7], 18);
        graph.AddEdge(vertices[5], vertices[1], 19);
        graph.AddEdge(vertices[5], vertices[6], 20);
        graph.AddEdge(vertices[6], vertices[2], 21);
        graph.AddEdge(vertices[6], vertices[4], 22);
        graph.AddEdge(vertices[7], vertices[4], 23);
        graph.AddEdge(vertices[7], vertices[5], 24);

        List<WDVertex<int>> path = graph.Dijkstra(vertices[0], vertices[7]);

        for(int i = path.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(path[i].Value);
        }
    }
}