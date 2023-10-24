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

        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
        }
    }
    class UndirectedUnweightedGraph<T>
    {
        public List<Vertex<T>> Vertices = new List<Vertex<T>>();
        public int VertexCount => Vertices.Count;


        public Queue<T> DepthFirst()
        {
            var queue = new Queue<T>();


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
                if(vert.Neighbors.Contains(vertex))
                {
                    vert.Neighbors.Remove(vertex);
                }
            }

            if(vertexInList)
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
            for(int i = 0; i < VertexCount; i++)
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
