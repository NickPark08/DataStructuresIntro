using DataStructuresIntro;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public WDEdge(WDVertex<T> start, WDVertex<T> end, float distance, bool block)
        {
            StartPoint = start;
            EndPoint = end;
            Distance = distance;
            Blocked = block;
        }

        public override string ToString()
        {
            return $"S = ({StartPoint}) E = ({EndPoint}) {(Blocked ? "Blocked" : "")}";
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

        public override string ToString()
        {
            return $"({x}, {y}) Edges = {NeighborCount}";
        }
    }
    public class WeightedDirectedGraph<T>
    {
        public List<WDVertex<T>> Vertices = new List<WDVertex<T>>();
        public List<WDEdge<T>> Edges = new List<WDEdge<T>>();
        public int VertexCount => Vertices.Count;


        public List<WDVertex<T>> Dijkstra(WDVertex<T> start, WDVertex<T> end)
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
            while (founder != start)
            {
                path.Add(founder);
                founder = founder.Founder;
            }
            path.Reverse(0, path.Count);
            journey.Remove(start);
            journey.Remove(end);
            path.Remove(start);

            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine(path[i].Value);
            }
            return path;
        }

        //delegates: https://sharplab.io/#v2:CYLg1APgAgTAjAWAFBQAwAIpwCwG5lqZwB0AMgJYB2AjvkgPT3ACmANswOYCGALs5tnQAVABZUOATwAUASjrJGLdtz7CASswDOAV1Y90AcWY8+AJwA8QgDTqtungD4pQ9FznICMdAGFeyAN7I6MGYAMzoVPoAghzMdCFhRBgAclwAtnFBIVnBUOG+PFKRrrE2WBiU6cwyOeiBSAkJMfwAvCWZDY3BqRnobZUZ8SEAvrW1eQLoAAqmkbK19V25cACcUgAkAEQF6APMwHU9zMPtB/7Nw5ty2Z3Bo7fo4+FQgkY8APKsLKbzD4tLzTAYFwNwS93uHhQzy83jqkISWAAbJMACIAewAyjxtAAzHG/BL/Lq1BGrKSbTTYvFXIZ3eEhJGTAq+AAO2NMzCkaO0+iwXgARmj+TU/iSEjsAFbkNJongiCR9XbMADuPl4UgArKgbJsogBjPVaTQANXIaNYvDNlAAogAPQ1sq009CMNJcADW/ClMrlEhsmmM6B4aKVytYCqo5B45C4rHIAC99ug9bx0IgHuLUxK0SJKLL5YrKCq1YU4Nr0JspmJWM7XR6vTm877/YHg+hvfmFQBaBzoAM8TRBkMp/TppaPDMhYpcRVwWmNYr8xVcefEyfBQVLtrZ3Od4gzSKrkKb9BgbfSvdvT7fI/BMW5QQACTYrDRBKWRPHrkVQP5t8aWBrG4/73OO97oCeZ7oM+rCvv+tSMAkMGvrI8Hru2jZ7s0s6oLgiFFqqBRSGWOr6oamgmmaFrRmiNr2swjq0bW9A7k2Bb9kOobhhElBRjGcaJgcI7oDAtSgaCDIwF4CwkuB9JrmB6HgYw06KnwaQssQACSlAAG5op65JllwNJyehkQANoALroMAvBcDObQWRqNgkWmLkieWMAalZaHjsUlDaGkOF+UsulcKY6AcjoeiKnZPAOcQADqIjMByUjBS0vb+BBaLmt+bTBQApLsQV9G0uGYAA7K4uAnDIxBCGiUSmKYXDSO4SldeOOJohyXB6iI6BSOFkVRswwVUFFdh6CK46fuOgFFOp1x3uh4kKUs4F8rlf6IW06JYriOKhV0jAnm0yFokejCIbtp5tIBt6IZBB2YlSJ1indr27aud0TuO51CtpekGZynWA/QqlvUdeKnZmPCsuynLcvom4Q4096Iaxe4HpQhQY5j6GbiD+mGYTXQkzpZPgyCa1gsgwxAA
        public List<WDVertex<T>> AStar(WDVertex<T> start, WDVertex<T> end, Func<WDVertex<T>, WDVertex<T>, float> heuristic = null, Func<WDVertex<T>, WDVertex<T>, bool> endFunc = null)
        {
            endFunc = endFunc ?? ((current, endVert) => current == endVert);
            heuristic = heuristic ?? Heuristic;

            for (int i = 0; i < VertexCount; i++)
            {
                Vertices[i].CumulativeDistance = Vertices[i].FinalDistance = float.PositiveInfinity;
                Vertices[i].Founder = null;
                Vertices[i].isVisited = false;
                Vertices[i].inQueue = false;
            }
            PriorityQueue<WDVertex<T>, float> queue = new PriorityQueue<WDVertex<T>, float>();
            List<WDVertex<T>> path = new List<WDVertex<T>>();
            List<WDVertex<T>> journey = new List<WDVertex<T>>();

            start.CumulativeDistance = 0;
            start.FinalDistance = heuristic(start, end);
            queue.Enqueue(start, start.CumulativeDistance + start.FinalDistance);

            WDVertex<T> current;
            do
            {
                current = queue.Dequeue();
                for (int i = 0; i < current.NeighborCount; i++)
                {
                    if (!current.Neighbors[i].Blocked)
                    {

                    }
                    if (current.Neighbors[i].EndPoint != current && !current.Neighbors[i].Blocked)
                    {
                        float tentative = current.CumulativeDistance + current.Neighbors[i].Distance;
                        if (tentative < current.Neighbors[i].EndPoint.CumulativeDistance)
                        {
                            current.Neighbors[i].EndPoint.CumulativeDistance = tentative;
                            current.Neighbors[i].EndPoint.Founder = current;
                            current.Neighbors[i].EndPoint.FinalDistance = heuristic(current.Neighbors[i].EndPoint, end) + tentative;
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

                if (queue.Count <= 0)
                {
                    return null;
                }
            }
            while (!endFunc(current, end));

            WDVertex<T> founder = current;

            while (founder != start)
            {
                path.Add(founder.Founder);
                founder = founder.Founder;
            }
            path.Reverse(0, path.Count);
            path.Remove(start);
            journey.Remove(start);
            journey.Remove(end);

            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine(path[i].Value);
            }
            return path;
        }

        public (bool, List<WDVertex<T>>) BellmanFord(WDVertex<T> start, WDVertex<T> end)
        {
            foreach (var vertex in Vertices)
            {
                vertex.CumulativeDistance = float.PositiveInfinity;
                vertex.Founder = null;
            }

            start.CumulativeDistance = 0;

            for (int i = 0; i < VertexCount - 1; i++)
            {
                foreach (var edge in Edges)
                {
                    if (edge.StartPoint.CumulativeDistance + edge.Distance < edge.EndPoint.CumulativeDistance && !edge.Blocked)
                    {
                        edge.EndPoint.CumulativeDistance = edge.StartPoint.CumulativeDistance + edge.Distance;
                        edge.EndPoint.Founder = edge.StartPoint;
                    }
                }
            }

            foreach (var edge in Edges)
            {
                if (edge.StartPoint.CumulativeDistance + edge.Distance < edge.EndPoint.CumulativeDistance && !edge.Blocked)
                {
                    return (false, null);
                }
            }

            List<WDVertex<T>> path = new List<WDVertex<T>>();
            WDVertex<T> current = end;
            while (current != null)
            {
                path.Add(current);
                current = current.Founder;
            }

            path.Reverse();

            return (true, path);
        }

        // delegate explanation
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

        public bool AddEdge(WDVertex<T> start, WDVertex<T> end, float distance, bool isBlocked)
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
                WDEdge<T> newEdge = new WDEdge<T>(start, end, distance, isBlocked);
                Edges.Add(newEdge);
                start.Neighbors.Add(newEdge);
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



