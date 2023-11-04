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

        Vertex<int>[] vertices = new Vertex<int>[8];

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vertex<int>(i);
            graph.AddVertex(vertices[i]);
        }

        graph.AddEdge(vertices[0], vertices[1]);
        graph.AddEdge(vertices[0], vertices[2]);
        graph.AddEdge(vertices[0], vertices[4]);
        graph.AddEdge(vertices[1], vertices[2]);
        graph.AddEdge(vertices[1], vertices[3]);
        graph.AddEdge(vertices[2], vertices[4]);
        graph.AddEdge(vertices[2], vertices[5]);
        graph.AddEdge(vertices[3], vertices[5]);
        graph.AddEdge(vertices[3], vertices[7]);
        graph.AddEdge(vertices[5], vertices[6]);
        graph.AddEdge(vertices[6], vertices[7]);

        graph.DepthFirstRecursive(vertices[0]);
        ;
    }
}