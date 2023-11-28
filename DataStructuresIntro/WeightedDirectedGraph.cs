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
        public bool Blocked;

        public WDEdge(WDVertex<T> start, WDVertex<T> end, float distance)
        {
            StartPoint = start;
            EndPoint = end;
            Distance = distance;
            Blocked = false;
        }
    }
    public class WDVertex<T>
    {
        public T Value;
        public List<WDEdge<T>> Neighbors = new List<WDEdge<T>>();
        public bool isVisited;
        public bool inQueue;
        public WDVertex<T> Founder;
        public float CumulativeDistance;
        public float FinalDistance;
        public int x;
        public int y;
        public int NeighborCount => Neighbors.Count;

        public WDVertex(T value)
        {
            Value = value;
        }
    }
    public class WeightedDirectedGraph<T>
    {
        public List<WDVertex<T>> Vertices = new List<WDVertex<T>>();
        public List<WDEdge<T>> Edges = new List<WDEdge<T>>();
        public int VertexCount => Vertices.Count;


        public (List<WDVertex<T>>,List<WDVertex<T>>) Dijkstra(WDVertex<T> start, WDVertex<T> end)
        {
            foreach (var vertex in Vertices)
            {
                vertex.isVisited = false;
                vertex.inQueue = false;
                vertex.CumulativeDistance = float.PositiveInfinity;
                vertex.Founder = null;
            }
            PriorityQueue<WDVertex<T>, float> queue = new PriorityQueue<WDVertex<T>, float>();
            List<WDVertex<T>> path = new List<WDVertex<T>>();
            List<WDVertex<T>> journey = new List<WDVertex<T>>();
            start.CumulativeDistance = 0f;
            queue.Enqueue(start, start.CumulativeDistance);

            do
            {
                WDVertex<T> current = queue.Dequeue();
                current.isVisited = true;

                for (int i = 0; i < current.NeighborCount; i++)
                {
                    float tentative;
                    if (current.Neighbors[i].EndPoint != current && !current.Neighbors[i].Blocked)
                    {
                        tentative = current.CumulativeDistance + current.Neighbors[i].Distance;
                        if (tentative < current.Neighbors[i].EndPoint.CumulativeDistance)
                        {
                            current.Neighbors[i].EndPoint.CumulativeDistance = tentative;
                            current.Neighbors[i].EndPoint.Founder = current;
                            current.isVisited = false;
                        }
                        if (!current.Neighbors[i].EndPoint.isVisited && !current.Neighbors[i].EndPoint.inQueue)
                        {
                            journey.Add(current.Neighbors[i].EndPoint);
                            queue.Enqueue(current.Neighbors[i].EndPoint, current.Neighbors[i].EndPoint.CumulativeDistance);
                            current.Neighbors[i].EndPoint.inQueue = true;
                        }
                    }
                }
                if (current == end || end.isVisited)
                {
                    break;
                }
            } while (queue.Count > 0);

            WDVertex<T> founder = end;
            while(founder != start)
            {
                path.Add(founder);
                founder = founder.Founder;
            }
            path.Reverse(0, path.Count);
            journey.Remove(start);
            journey.Remove(end);
            path.Remove(start);
            return (path, journey);
        }

        public (List<WDVertex<T>>, List<WDVertex<T>>) AStar(WDVertex<T> start, WDVertex<T> end)
        {
            for(int i = 0; i < VertexCount; i++)
            {
                Vertices[i].CumulativeDistance = Vertices[i].FinalDistance = float.PositiveInfinity;
                Vertices[i].Founder = null;
                Vertices[i].isVisited = false;
            }
            PriorityQueue<WDVertex<T>, float> queue = new PriorityQueue<WDVertex<T>, float>();
            List<WDVertex<T>> path = new List<WDVertex<T>>();
            List<WDVertex<T>> journey = new List<WDVertex<T>>();

            start.CumulativeDistance = 0;
            start.FinalDistance = Heuristic(start, end);
            queue.Enqueue(start, start.FinalDistance);

            do
            {
                WDVertex<T> current = queue.Dequeue();

                for(int i = 0; i < current.NeighborCount; i++)
                {
                    if (current.Neighbors[i].EndPoint != current && !current.Neighbors[i].Blocked)
                    {
                        float tentative = current.CumulativeDistance + current.Neighbors[i].Distance;
                        if (tentative < current.Neighbors[i].EndPoint.CumulativeDistance)
                        {
                            current.Neighbors[i].EndPoint.CumulativeDistance = tentative;
                            current.Neighbors[i].EndPoint.Founder = current;
                            current.Neighbors[i].EndPoint.FinalDistance = Heuristic(current.Neighbors[i].EndPoint, end) + tentative;
                        }
                        if (!current.Neighbors[i].EndPoint.isVisited && !current.Neighbors[i].EndPoint.inQueue)
                        {
                            journey.Add(current.Neighbors[i].EndPoint);
                            queue.Enqueue(current.Neighbors[i].EndPoint, current.Neighbors[i].EndPoint.FinalDistance);
                            current.Neighbors[i].EndPoint.inQueue = true;
                        }
                        current.isVisited = true;
                    }
                }

                if(current == end || end.isVisited)
                {
                    break;
                }
            }
            while (queue.Count > 0);

            WDVertex<T> founder = end;

            while(founder != start)
            {
                path.Add(founder.Founder);
                founder = founder.Founder;
            }
            path.Reverse(0, path.Count);
            path.Remove(start);
            journey.Remove(start);
            journey.Remove(end);

            return (path, journey);
        }

        public float Heuristic(WDVertex<T> node, WDVertex<T> end)
        {
            float x = Math.Abs(node.x - end.x);
            float y = Math.Abs(node.y - end.y);
            float D1 = 1;
            float D2 = (float)(Math.Sqrt(2));
            return D1 * (x + y) + (D2 - 2 * D1) * Math.Min(D1, D2);
        }

        public string CompareCosts(WDVertex<T> start, WDVertex<T> end)
        {
            float lowest;
            float cost1 = DepthFirst(start, end);
            float cost2 = BreadthFirst(start, end);
            if (cost1 < cost2)
            {
                lowest = cost1;
            }
            else
            {
                lowest = cost2;
            }

            return $"DepthFirst: {cost1} \nBreadthFirst: {cost2} \nLowest Cost: {lowest}";
        }

        public float DepthFirst(WDVertex<T> start, WDVertex<T> end)
        {
            float cost = 0;
            if (start.NeighborCount == 0) throw new Exception("Start vertex is not in graph");
            var stack = new Stack<WDVertex<T>>();
            WDVertex<T> Pointer = start;

            stack.Push(start);
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].isVisited = false;
            }
            start.isVisited = true;

            while (stack.Count >= 1)
            {
                for (int i = Pointer.NeighborCount - 1; i >= 0; i--)
                {
                    if (!Pointer.Neighbors[i].EndPoint.isVisited)
                    {
                        stack.Push(Pointer.Neighbors[i].EndPoint);
                    }
                }
                foreach (var edge in Edges)
                {
                    if (edge.StartPoint == Pointer && edge.EndPoint == stack.Peek())
                    {
                        cost += edge.Distance;
                    }
                }
                Pointer = stack.Pop();

                if (!Pointer.isVisited)
                {
                    Pointer.isVisited = true;
                    if (Pointer == end) break;
                }
            }
            return cost;
        }

        public float BreadthFirst(WDVertex<T> start, WDVertex<T> end)
        {
            float cost = 0;
            Queue<WDVertex<T>> traversal = new Queue<WDVertex<T>>();
            List<WDVertex<T>> path = new List<WDVertex<T>>();
            bool endNotFound = true;

            for (int i = 0; i < VertexCount; i++)
            {
                Vertices[i].isVisited = false;
                Vertices[i].Founder = null;
            }
            start.isVisited = true;
            traversal.Enqueue(start);

            while (traversal.Count > 0)
            {
                WDVertex<T> Pointer = traversal.Dequeue();
                for (int i = 0; i < Pointer.NeighborCount; i++)
                {
                    if (!Pointer.Neighbors[i].EndPoint.isVisited && Pointer.Neighbors[i].EndPoint != Pointer)
                    {
                        traversal.Enqueue(Pointer.Neighbors[i].EndPoint);
                        Pointer.Neighbors[i].EndPoint.isVisited = true;
                        Pointer.Neighbors[i].EndPoint.Founder = Pointer;
                        if (Pointer.Neighbors[i].EndPoint == end)
                        {
                            path.Add(Pointer.Neighbors[i].EndPoint);
                            endNotFound = false;
                            break;
                        }
                    }
                }
                if (!endNotFound)
                {
                    break;
                }
            }
            WDVertex<T> founder = path[0];
            while (founder != start)
            {
                foreach (var edge in Edges)
                {
                    if (edge.EndPoint == founder && edge.StartPoint == founder.Founder)
                    {
                        cost += edge.Distance;
                    }
                }
                path.Add(founder.Founder);
                founder = founder.Founder;
            }
            return cost;
        }

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
            if (!Vertices.Contains(vertex)) return false;

            for (int i = 0; i < vertex.NeighborCount; i++)
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
            WDEdge<T> removedEdge = null;
            bool edgeFound = false;
            if (start == null || end == null || !Vertices.Contains(start) || !Vertices.Contains(end)) return false;

            foreach (var edge in Edges)
            {
                if (edge.StartPoint == start && edge.EndPoint == end)
                {
                    removedEdge = edge;
                    edgeFound = true;
                }
            }
            if (edgeFound)
            {
                start.Neighbors.Remove(removedEdge);
                end.Neighbors.Remove(removedEdge);
                Edges.Remove(removedEdge);
            }
            return edgeFound;
        }

        public WDVertex<T> Search(T value)
        {
            int count = -1;
            for (int i = 0; i < VertexCount; i++)
            {
                if (Vertices[i].Value.Equals(value))
                {
                    count = i;
                    break;
                }
            }
            if (count == -1) throw new Exception("Vertex not found in graph");
            else
            {
                return Vertices[count];
            }
        }
        public WDEdge<T> GetEdge(WDVertex<T> start, WDVertex<T> end)
        {
            int count = -1;
            if (start == null || end == null) throw new Exception("Vertex is null");

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].StartPoint == start && Edges[i].EndPoint == end)
                {
                    count = i;
                    break;
                }
            }
            if (count == -1) throw new Exception("Edge not found in graph");
            return Edges[count];
        }
    }


}
