using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Maze<T>
    {
        public Maze() 
        {
            
        }

        public List<WDEdge<T>> MazeGenerator(WeightedDirectedGraph<T> graph, WDVertex<T> start, WDVertex<T> end)
        {
            var union = new QuickUnion<WDVertex<T>>(graph.Vertices);
            var edges = graph.Edges;
            var removedEdges = new List<WDEdge<T>>();
            Random randy = new Random();

            while (!union.AreConnected(start, end))
            {
                int ran = randy.Next(0, edges.Count);
                WDEdge<T> edge = edges[ran];
                if(!union.AreConnected(edge.StartPoint, edge.EndPoint))
                {
                    union.Union(edge.StartPoint, edge.EndPoint);
                    edges.Remove(edge);
                    removedEdges.Add(edge);
                }
            }
            return removedEdges;
        }
    }
}
