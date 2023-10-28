using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Vertex<T>
    {
        public T Value;
        public List<Vertex<T>> Neighbors;
        public int NeighborCount => Neighbors.Count;
        public bool isVisited;

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
            isVisited = false;
        }
    }
    class UndirectedUnweightedGraph<T>
    {
        public List<Vertex<T>> Vertices = new List<Vertex<T>>();
        public int VertexCount => Vertices.Count;

        public bool AllVisited()
        {
            for(int i = 0; i < Vertices.Count; i++)
            {
                if (!Vertices[i].isVisited) return false;
            }

            return true;
        }

        public void DepthFirst(Vertex<T> start)
        {
            if (start.NeighborCount == 0) throw new Exception("Start vertex is not in graph");
            var stack = new Stack<Vertex<T>>();
            Vertex<T> Pointer = start;

            stack.Push(start);
            for(int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].isVisited = false;
            }
            start.isVisited = true;
            Console.WriteLine(start.Value);

            while (stack.Count != 0)
            {
                for (int i = Pointer.NeighborCount - 1; i >= 0; i--)
                {
                    if (!Pointer.Neighbors[i].isVisited)
                    {
                        stack.Push(Pointer.Neighbors[i]);
                    }
                }
                if (!AllVisited())
                {
                    Pointer = stack.Pop();

                    if (!Pointer.isVisited)
                    {
                        Pointer.isVisited = true;
                        Console.WriteLine(Pointer.Value);
                    }
     
                }
            }
        }

        public bool AddVertex(Vertex<T> newVertex)
        {
            if (newVertex == null || newVertex.NeighborCount != 0) return false;

            foreach (var vertex in Vertices)
            {
                if (newVertex == vertex) return false;
            }

            Vertices.Add(newVertex);
            return true;
        }
        public bool AddEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        {
            bool vertA = false;
            bool vertB = false;
            if (vertexA == null || vertexB == null) return false;

            for (int i = 0; i < VertexCount; i++)
            {
                if (Vertices[i] == vertexA)
                {
                    vertA = true;
                }
                else if (Vertices[i] == vertexB)
                {
                    vertB = true;
                }
            }
            if (vertA && vertB)
            {
                vertexA.Neighbors.Add(vertexB);
                vertexB.Neighbors.Add(vertexA);
            }
            return vertA && vertB;
        }
        public bool DeleteVertex(Vertex<T> vertex)
        {
            bool vertexInList = false;
            foreach (Vertex<T> vert in Vertices)
            {
                if (vert == vertex)
                {
                    vertexInList = true;
                }
                if (vert.Neighbors.Contains(vertex))
                {
                    vert.Neighbors.Remove(vertex);
                }
            }

            if (vertexInList)
            {
                vertex.Neighbors.Clear();
                Vertices.Remove(vertex);

            }
            return vertexInList;
        }
        public bool DeleteEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        {
            bool vertA = false;
            bool vertB = false;
            for (int i = 0; i < VertexCount; i++)
            {
                if (Vertices[i] == vertexA && vertexA.Neighbors.Contains(vertexB))
                {
                    vertA = true;
                }
                else if (Vertices[i] == vertexB && vertexB.Neighbors.Contains(vertexA))
                {
                    vertB = true;
                }
            }

            if (vertA && vertB)
            {
                vertexA.Neighbors.Remove(vertexB);
                vertexB.Neighbors.Remove(vertexA);
            }
            return vertA && vertB;
        }
        public Vertex<T> Search(T value)
        {
            int index = -1;
            for (int i = 0; i < VertexCount; i++)
            {
                if (Vertices[i].Value.Equals(value))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1) return null;

            return Vertices[index];
        }
    }
}
