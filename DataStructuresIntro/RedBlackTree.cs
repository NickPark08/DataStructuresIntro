using DataStructuresIntro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures
{
    public class RedBlackTree<T> : ISortedSet<T> where T : IComparable<T>
    {
        private IComparer<T> compare;
        public RedBlackTree(IComparer<T> comparer)
        {
            compare = comparer;
        }
        public IComparer<T> Comparer => compare;

        public RBNode<T> root;
        public int Count { get; private set; }


        public void Insert(T val)
        {
            Count++;
            if (root == null)
            {
                root = new RBNode<T>(val, true);
                return;
            }

            Insert(val, ref root);

            root.isBlack = true;
        }
        private void Insert(T val, ref RBNode<T> currentNode)
        {
            if (currentNode.Left?.isBlack == false && currentNode.Right?.isBlack == false)
            {
                FlipColor(currentNode);
            }
            if (currentNode.Left != null && val.CompareTo(currentNode.Value) < 0)
            {
                Insert(val, ref currentNode.Left);
            }
            else if (currentNode.Right != null)
            {
                Insert(val, ref currentNode.Right);
            }

            else
            {
                if (val.CompareTo(currentNode.Value) < 0)
                {
                    currentNode.Left = new RBNode<T>(val, false);
                }
                else
                {
                    currentNode.Right = new RBNode<T>(val, false);
                }
                if (currentNode.Left != null && currentNode.Right != null && !currentNode.Left.isBlack && !currentNode.Right.isBlack)
                {
                    FlipColor(currentNode);
                }
            }

            if (currentNode.Left != null && currentNode.Right != null && !currentNode.Left.isBlack && !currentNode.Right.isBlack)
            {
                FlipColor(currentNode);
            }
            if (currentNode.Right != null && !currentNode.Right.isBlack)
            {
                RotateLeft(ref currentNode);
            }

            if (currentNode.Left != null && currentNode.Left.Left != null && !currentNode.Left.isBlack && !currentNode.Left.Left.isBlack)
            {
                RotateRight(ref currentNode);
            }
        }
        private void FlipColor(RBNode<T> currentNode)
        {
            currentNode.isBlack = !currentNode.isBlack;
            if (currentNode.Right != null) currentNode.Right.isBlack = !currentNode.Right.isBlack;
            if (currentNode.Left != null) currentNode.Left.isBlack = !currentNode.Left.isBlack;
        }
        private void RotateLeft(ref RBNode<T> currentNode)
        {
            bool originalParent = currentNode.isBlack;
            var temp = currentNode.Right;
            currentNode.Right = temp.Left;
            temp.Left = currentNode;
            temp.isBlack = originalParent;
            currentNode.isBlack = false;
            currentNode = temp;
        }
        private void RotateRight(ref RBNode<T> currentNode)
        {
            bool originalParent = currentNode.isBlack;
            var temp = currentNode.Left;
            currentNode.Left = temp.Right;
            temp.Right = currentNode;
            temp.isBlack = originalParent;
            currentNode.isBlack = false;
            currentNode = temp;
        }

        private void MoveRedRight(ref RBNode<T> currentNode)
        {
            FlipColor(currentNode);
            if (currentNode.Left?.Left?.isBlack == false)
            {
                RotateRight(ref currentNode);
                FlipColor(currentNode);
            }
        }

        private void MoveRedLeft(ref RBNode<T> currentNode)
        {
            FlipColor(currentNode);
            if (currentNode.Right?.Left?.isBlack == false)
            {
                RotateRight(ref currentNode.Right);
                RotateLeft(ref currentNode);
                FlipColor(currentNode);
                if (currentNode.Right.Right?.isBlack == false)
                {
                    RotateLeft(ref currentNode.Right);
                }
            }

        }

        public bool Remove(T val)
        {
            if (root == null) return false;

            bool hasRemoved = false;
            root = Remove(val, root, hasRemoved);
            root.isBlack = true;
            Count--;
            return hasRemoved;
        }

        private RBNode<T> Remove(T val, RBNode<T> currentNode, bool removed)
        {
            if (currentNode != null)
            {
                if (val.CompareTo(currentNode.Value) < 0)
                {
                    if (currentNode.Left != null)
                    {
                        if (currentNode.Left?.isBlack == true && currentNode.Left?.Left?.isBlack == true)
                        {
                            MoveRedLeft(ref currentNode);
                        }

                        currentNode.Left = Remove(val, currentNode.Left, removed);
                    }
                }
                else
                {
                    if (currentNode.Left?.isBlack == false)
                    {
                        RotateRight(ref currentNode);
                    }

                    if (currentNode != null && currentNode.Value.Equals(val) && currentNode.Left == null && currentNode.Right == null)
                    {
                        removed = true;
                        return null;
                    }
                    if (currentNode.Right != null)
                    {
                        if (currentNode.Right?.isBlack == true && isBlack(currentNode.Right.Left))
                        {
                            MoveRedRight(ref currentNode);
                        }

                        if (val.CompareTo(currentNode.Value) == 0)
                        {
                            RBNode<T> minValue = currentNode.Right;
                            while (minValue.Left != null)
                            {
                                minValue = minValue.Left;
                            }

                            currentNode.Value = minValue.Value;
                            minValue.Value = val;

                            Remove(val);
                        }
                        else
                        {
                            currentNode.Right = Remove(val, currentNode.Right, removed);
                        }
                    }

                }
            }
            Fixup(ref currentNode);

            return currentNode;
        }

        public void Fixup(ref RBNode<T> currentNode)
        {
            if (currentNode != null)
            {
                if (!isBlack(currentNode.Right))
                {
                    RotateLeft(ref currentNode);
                }

                if (!isBlack(currentNode.Left) && !isBlack(currentNode.Left.Left))
                {
                    RotateRight(ref currentNode);
                }

                if (!isBlack(currentNode.Right) && !isBlack(currentNode.Left)) FlipColor(currentNode);

                if (!isBlack(currentNode.Right))
                {
                    RotateLeft(ref currentNode);
                }
                if (currentNode.Left != null && !isBlack(currentNode.Left.Right) && isBlack(currentNode.Left.Left))
                {
                    RotateLeft(ref currentNode.Left);
                    if (currentNode.Left.Left != null && currentNode.Left.Left.Left != null && !currentNode.Left.Left
                        .isBlack && !currentNode.Left.Left.Left.isBlack)
                    {
                        RotateRight(ref currentNode);
                    }
                    else if (!isBlack(currentNode.Left))
                    {
                        RotateRight(ref currentNode);
                    }
                }
                if ((currentNode.Left != null) && !isBlack(currentNode.Left.Right) && isBlack(currentNode.Left.Left))
                {
                    if (!isBlack(currentNode.Left))
                    {
                        RotateRight(ref currentNode);
                    }
                }
            }
        }

        private bool isBlack(RBNode<T> currentNode)
        {
            if (currentNode == null || currentNode.isBlack) return true;

            return false;
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Add(T item)
        {
            Insert(item);
            return true;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                Insert(item);
            }
        }

        public bool Contains(T item)
        {
            var list = PreOrder();
            return list.Contains(item);
        }
        private List<T> PreOrder()
        {
            Stack<RBNode<T>> stack = new Stack<RBNode<T>>();
            Queue<T> queue = new Queue<T>();

            stack.Push(root);
            while (stack.Count > 0)
            {
                RBNode<T> currentNode;
                currentNode = stack.Pop();

                queue.Enqueue(currentNode.Value);

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }
            return queue.ToList();
        }


        bool ISortedSet<T>.Remove(T item)
        {
            return Remove(item);
        }

        public T Max()
        {
            var temp = root;
            while(temp.Right != null)
            {
                temp = temp.Right;
            }
            return temp.Value;
        }

        public T Min()
        {
            var temp = root;
            while(temp.Left != null)
            {
                temp = temp.Left;
            }
            return temp.Value;
        }

        public T Ceiling(T item)
        {
            if (item.CompareTo(Max()) > 0) throw new Exception("No ceiling");;
            RecursiveSorts<T> sorts = new RecursiveSorts<T>();
            var list = sorts.MergeSort(PreOrder());

            T ceiling = list[0];

            if (list.Contains(item)) return item;
            else
            {
                int i = 0;
                while (i < list.Count)
                {
                    if (list[i].CompareTo(item) > 0)
                    {
                        ceiling = list[i];
                        break;
                    }
                    i++;
                }
            }
            return ceiling;
        }

        public T Floor(T item)
        {
            if (item.CompareTo(Min()) < 0) throw new Exception("No floor");
            RecursiveSorts<T> sorts = new RecursiveSorts<T>();
            var list = sorts.MergeSort(PreOrder());
            T floor = list[list.Count - 1];

            if (list.Contains(item)) return item;
            else
            {
                int i = list.Count - 1;
                while(i >= 0)
                {
                    if (list[i].CompareTo(item) < 0)
                    {
                        floor = list[i];
                        break;
                    }
                    i--;
                }
            }
            return floor;
        }

        public ISortedSet<T> Union(ISortedSet<T> other)
        {
            var values = new RedBlackTree<T>(Comparer);
            if (other == null) return this;

            foreach(var val in this)
            {
                values.Add(val);
            }
            foreach(var item in other)
            {
                if(Contains(item))
                {
                    values.Remove(item);
                }
                else
                {
                    values.Add(item);
                }
            }

            return values;
        }

        public ISortedSet<T> Intersection(ISortedSet<T> other)
        {
            if (other == null) return this;

            var values = new RedBlackTree<T>(Comparer);

            foreach (var item in other)
            {
                if(Contains(item))
                {
                    values.Add(item);
                }
            }

            return values;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var values = InOrder();
            return values.GetEnumerator();
        }
        public Queue<T> InOrder()
        {
            Queue<T> queue = new Queue<T>();
            InOrder(root, queue);
            return queue;
        }
        private void InOrder(RBNode<T> node, Queue<T> queue)
        {
            if (node != null)
            {
                InOrder(node.Left, queue);
                queue.Enqueue(node.Value);
                InOrder(node.Right, queue);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
