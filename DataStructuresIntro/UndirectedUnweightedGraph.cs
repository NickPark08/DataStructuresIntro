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
        public Vertex<T> Founder;
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

        public void DepthFirst(Vertex<T> start)
        {
            if (start.NeighborCount == 0) throw new Exception("Start vertex is not in graph");
            var stack = new Stack<Vertex<T>>();
            Vertex<T> Pointer = start;

            stack.Push(start);
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].isVisited = false;
            }
            start.isVisited = true;
            Console.WriteLine(start.Value);

            while (stack.Count >= 1)
            {
                for (int i = Pointer.NeighborCount - 1; i >= 0; i--)
                {
                    if (!Pointer.Neighbors[i].isVisited)
                    {
                        stack.Push(Pointer.Neighbors[i]);
                    }
                }
                Pointer = stack.Pop();

                if (!Pointer.isVisited)
                {
                    Pointer.isVisited = true;
                    Console.WriteLine(Pointer.Value);
                }
            }
        }

        public void DepthFirstRecursive(Vertex<T> start)
        {
            var stack = new Stack<Vertex<T>>();
            if (start.NeighborCount == 0) return;
            Console.WriteLine(start.Value);

            for (int i = VertexCount - 1; i >= 0; i--)
            {
                Vertices[i].isVisited = false;
            }
            start.isVisited = true;
            DepthFirstRecursive(start, stack);

            for (int i = 0; i < stack.Count; i++)
            {
                Console.WriteLine(stack.Pop().Value);
            }
        }
        private void DepthFirstRecursive(Vertex<T> start, Stack<Vertex<T>> stack)
        {
            for (int i = start.NeighborCount - 1; i >= 0; i--)
            {
                if (!start.Neighbors[i].isVisited)
                {
                    stack.Push(start.Neighbors[i]);
                }
            }

            if (stack.Count == 0) return;

            if (!stack.Peek().isVisited)
            {
                stack.Peek().isVisited = true;
                Console.WriteLine(stack.Peek().Value);
            }
            DepthFirstRecursive(stack.Pop(), stack);
            return;
        }
        public List<Vertex<T>> BreadthFirst(Vertex<T> start)
        {
            Queue<Vertex<T>> traversal = new Queue<Vertex<T>>();
            List<Vertex<T>> path = new List<Vertex<T>>();

            for (int i = 0; i < VertexCount; i++)
            {
                Vertices[i].isVisited = false;
            }
            start.isVisited = true;
            traversal.Enqueue(start);
            Console.WriteLine(start.Value);

            while (traversal.Count > 0)
            {
                Vertex<T> Pointer = traversal.Dequeue();
                for (int i = 0; i < Pointer.NeighborCount; i++)
                {
                    if (!Pointer.Neighbors[i].isVisited)
                    {
                        traversal.Enqueue(Pointer.Neighbors[i]);
                        Pointer.Neighbors[i].isVisited = true;
                        Console.WriteLine(Pointer.Neighbors[i].Value);
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
