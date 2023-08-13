using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class BinaryTreeNode<T> where T : IComparable<T>
    {
        public T Value;
        public BinaryTreeNode<T> LeftChild;
        public BinaryTreeNode<T> RightChild;
        public BinaryTreeNode<T> Parent;

        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild, BinaryTreeNode<T> parent)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            Parent = parent;
        }
    }
    class BinarySearchTree<T> where T : IComparable<T>
    {
        BinaryTreeNode<T> Root;
        public int Count { get; private set; }

        public Queue<T> PreOrder()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            Queue<T> queue = new Queue<T>();

            stack.Push(Root);
            while (stack.Count > 0)
            {
                BinaryTreeNode<T> currentNode;
                currentNode = stack.Pop();

                queue.Enqueue(currentNode.Value);

                if (currentNode.RightChild != null)
                {
                    stack.Push(currentNode.RightChild);
                }
                if (currentNode.LeftChild != null)
                {
                    stack.Push(currentNode.LeftChild);
                }
            }
            return queue;
        }
        public Queue<T> InOrder()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            Queue<T> queue = new Queue<T>();

            BinaryTreeNode<T> currentNode = Root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = stack.Pop();
                    queue.Enqueue(currentNode.Value);
                    currentNode = currentNode.RightChild;
                }
            }
            return queue;
        }
        public Stack<T> PostOrder()
        {
            Stack<BinaryTreeNode<T>> traversal = new Stack<BinaryTreeNode<T>>();
            Stack<T> stack = new Stack<T>();

            traversal.Push(Root);
            while (traversal.Count > 0)
            {
                BinaryTreeNode<T> node;
                node = traversal.Pop();

                stack.Push(node.Value);

                if (node.LeftChild != null)
                {
                    traversal.Push(node.LeftChild);
                }
                if (node.RightChild != null)
                {
                    traversal.Push(node.RightChild);
                }
            }
            return stack;
        }
        public Queue<T> BreadthFirst()
        {
            Queue<BinaryTreeNode<T>> traversal = new Queue<BinaryTreeNode<T>>();
            Queue<T> queue = new Queue<T>();

            traversal.Enqueue(Root);
            while(traversal.Count > 0)
            {
                BinaryTreeNode<T> node;
                node = traversal.Dequeue();

                queue.Enqueue(node.Value);
                if(node.LeftChild != null)
                {
                    traversal.Enqueue(node.LeftChild);
                }
                if(node.RightChild != null)
                {
                    traversal.Enqueue(node.RightChild);
                }
            }
            return queue;  
        }



        public bool IsLeftChild(BinaryTreeNode<T> child)
        {
            if (child.Parent.RightChild == child) return false;

            else return true;
        }
        public bool IsRightChild(BinaryTreeNode<T> child)
        {
            if (child.Parent.RightChild == child) return true;

            else return false;
        }
        public BinaryTreeNode<T> Search(T value)
        {
            BinaryTreeNode<T> currentNode = Root;
            if (Root == null) throw new ArgumentException("Tree is empty");
            while (true)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }
                else if (value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (value.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    throw new ArgumentException("Value not found in tree");
                }
            }
        }

        public T Minimum()
        {
            BinaryTreeNode<T> currentNode = Root;
            if (Root == null) throw new ArgumentException("Tree is empty");
            while (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }
            return currentNode.Value;
        }
        public T Maximum()
        {
            BinaryTreeNode<T> currentNode = Root;
            if (Root == null) throw new ArgumentException("Tree is empty");
            while (currentNode.RightChild != null)
            {
                currentNode = currentNode.RightChild;
            }
            return currentNode.Value;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(value, null, null, null);
                Count++;
                return;
            }
            BinaryTreeNode<T> currentNode = Root;
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value, null, null, null);
            while (true)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                    }
                    else
                    {
                        currentNode.LeftChild = newNode;
                        newNode.Parent = currentNode;
                        Count++;
                        break;
                    }
                }
                else if (value.CompareTo(currentNode.Value) > 0)
                {
                    if (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                    }
                    else
                    {
                        currentNode.RightChild = newNode;
                        newNode.Parent = currentNode;
                        Count++;
                        break;
                    }
                }
                else
                {
                    while (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                    }
                    if (value.CompareTo(currentNode.Value) > 0)
                    {
                        currentNode.RightChild = newNode;
                        newNode.Parent = currentNode;
                        Count++;
                        break;
                    }
                    else
                    {
                        currentNode.LeftChild = newNode;
                        newNode.Parent = currentNode;
                        Count++;
                        break;
                    }
                }
            }
        }
        public bool Delete(T value)
        {
            BinaryTreeNode<T> deletion = Search(value);
            if (deletion == null || Root == null) return false;

            //0 children
            if (deletion.LeftChild == null && deletion.RightChild == null)
            {
                if (deletion == Root)
                {
                    Root = null;
                }
                else if (IsRightChild(deletion))
                {
                    deletion.Parent.RightChild = null;
                }
                else
                {
                    deletion.Parent.LeftChild = null;
                }
                return true;
            }

            //1 child
            if (deletion == Root)
            {
                if (deletion.RightChild != null && deletion.LeftChild == null)
                {
                    Root = deletion.RightChild;
                    return true;
                }
                else if (deletion.RightChild == null && deletion.LeftChild != null)
                {
                    Root = deletion.LeftChild;
                    return true;
                }
            }
            else if (deletion.RightChild == null && deletion.LeftChild != null)
            {
                if (IsRightChild(deletion))
                {
                    deletion.Parent.RightChild = deletion.LeftChild;
                    deletion.LeftChild.Parent = deletion.Parent;
                    return true;
                }
                if (IsLeftChild(deletion))
                {
                    deletion.Parent.LeftChild = deletion.LeftChild;
                    deletion.LeftChild.Parent = deletion.Parent;
                    return true;
                }
            }
            else if (deletion.RightChild != null && deletion.LeftChild == null)
            {
                if (IsRightChild(deletion))
                {
                    deletion.Parent.RightChild = deletion.RightChild;
                    deletion.RightChild.Parent = deletion.Parent;
                    return true;
                }

                else if (IsLeftChild(deletion))
                {
                    deletion.Parent.LeftChild = deletion.RightChild;
                    deletion.RightChild.Parent = deletion.Parent;
                    return true;
                }
            }
            //2 children
            if (deletion.RightChild != null && deletion.LeftChild != null)
            {
                BinaryTreeNode<T> currentNode = deletion.LeftChild;
                while (currentNode.RightChild != null)
                {
                    currentNode = currentNode.RightChild;
                }
                deletion.Value = currentNode.Value;
                if (currentNode.LeftChild != null)
                {
                    currentNode.Parent.RightChild = currentNode.LeftChild;
                    currentNode.LeftChild.Parent = currentNode.Parent;
                    return true;
                }
                else if (IsRightChild(currentNode))
                {
                    currentNode.Parent.RightChild = null;
                    return true;
                }
                else if (IsLeftChild(currentNode))
                {
                    currentNode.Parent.LeftChild = null;
                    return true;
                }
            }
            return false;
        }
    }
}
