using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class WDEdge<T>
    {
        public WDVertex<T> StartPoint;
        public WDVertex<T> EndPoint;
        public float Distance;

        public WDEdge(WDVertex<T> start, WDVertex<T> end, float distance)
        {
            StartPoint = start;
            EndPoint = end;
            Distance = distance;
        }
    }
    public class WDVertex<T>
    {
        public T Value;
        public List<WDEdge<T>> Neighbors;
        public int NeighborCount => Neighbors.Count;

        public WDVertex(T value)
        {
            Value = value;
        }
    }
    class WeightedDirectedGraph<T>
    {
        public List<WDVertex<T>> Vertices;
        public List<WDEdge<T>> Edges;
        public int VertexCount => Vertices.Count;

        public bool AddVertex(WDVertex<T> newVertex)
        {
            if (newVertex == null || newVertex.NeighborCount != 0) return false;

            foreach (var vertex in Vertices)
            {
                if (newVertex == vertex) return false;
            }

            Vertices.Add(newVertex);
            return true;
        }

        public bool AddEdge(WDVertex<T> start, WDVertex<T> end, float distance)
        {
            bool vertA = false;
            bool vertB = false;
            if (start == null || end == null) return false;
            foreach (var vertex in Vertices)
            {
                if (vertex == start)
                {
                    vertA = true;
                }
                else if (vertex == end)
                {
                    vertB = true;
                }
            }
            if (vertA && vertB)
            {
                WDEdge<T> newEdge = new WDEdge<T>(start, end, distance);
                Edges.Add(newEdge);
                start.Neighbors.Add(newEdge);
                end.Neighbors.Add(newEdge);
            }
            return vertA && vertB;
        }
        public bool DeleteVertex(WDVertex<T> vertex)
        {
            if(!Vertices.Contains(vertex)) return false;

            for(int i = 0; i < vertex.NeighborCount; i++)
            {
                if (vertex.Neighbors[i].EndPoint == vertex)
                {
                    Edges.Remove(vertex.Neighbors[i]);
                    vertex.Neighbors.RemoveAt(i);
                }
            }
            Vertices.Remove(vertex);
            return true;
        }
        public bool DeleteEdge(WDVertex<T> start, WDVertex<T> end)
        {
            WDEdge<T> removedEdge;
            bool edgeFound = false;
            if (start == null || end == null || !Vertices.Contains(start) || !Vertices.Contains(end)) return false;

            foreach (var edge in Edges)
            {
                if (edge.StartPoint == start && edge.EndPoint == end)
                {
                    removedEdge = //edge
                    edgeFound = true;
                }
            }
            if(edgeFound)
            {

            }
        }
    }


}
