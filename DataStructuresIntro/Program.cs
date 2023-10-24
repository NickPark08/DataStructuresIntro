using DataStructures;

using DataStructuresIntro;

using System.Data;
using System.Reflection;

class Program
{
    public static void Main()
    {
        UndirectedUnweightedGraph<int> graph = new UndirectedUnweightedGraph<int>();

        Random randy = new Random();

        for(int i = 0; i < randy.Next(0,20); i++)
        {
            graph.AddVertex(new Vertex<int>(randy.Next(0, 101)));
        }

        graph.AddEdge(graph.Vertices[0], graph.Vertices[1]);
        graph.DeleteEdge(graph.Vertices[0], graph.Vertices[1]);

        ;
    }
}