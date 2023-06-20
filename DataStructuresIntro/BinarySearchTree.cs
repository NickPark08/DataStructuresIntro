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
            while (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }
            return currentNode.Value;
        }
        public T Maximum()
        {
            BinaryTreeNode<T> currentNode = Root;
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
                    currentNode.RightChild = newNode;
                    newNode.Parent = currentNode;
                    Count++;
                }
            }
        }
        public bool Delete(T value)
        {
            BinaryTreeNode<T> deletion = Search(value);
            if (deletion == null) return false;

            if (deletion.LeftChild == null && deletion.RightChild == null)
            {
                if(deletion == Root)
                {
                    deletion.LeftChild.Parent = null;
                }
                else if(IsRightChild(deletion))
                {
                    deletion.Parent.RightChild = null;
                }
                else
                {
                    deletion.Parent.LeftChild = null;
                }
                return true;
            }

            if(deletion == Root)
            {
                Root = null;
            }
            else if (IsRightChild(deletion))
            {
                //1 child
                if (deletion.RightChild == null && deletion.LeftChild != null)
                {
                    deletion.Parent.RightChild = deletion.LeftChild;
                    deletion.LeftChild.Parent = deletion.Parent;
                    return true;
                }
                else if (deletion.RightChild != null && deletion.LeftChild == null)
                {
                    deletion.Parent.RightChild = deletion.RightChild;
                    deletion.RightChild.Parent = deletion.Parent;
                    return true;
                }
            }
            else if(IsLeftChild(deletion))
            {
                //one child
                if(deletion.RightChild == null && deletion.LeftChild != null)
                {
                    deletion.Parent.LeftChild = deletion.LeftChild;
                    deletion.LeftChild.Parent = deletion.Parent;
                    return true;
                }
                else if(deletion.RightChild != null && deletion.LeftChild == null)
                {
                    deletion.Parent.LeftChild = deletion.RightChild;
                    deletion.RightChild.Parent = deletion.Parent;
                    return true;
                }
            }
            if(deletion.RightChild != null && deletion.LeftChild != null)
            {
                BinaryTreeNode<T> currentNode = deletion.LeftChild;
                while(currentNode.RightChild != null)
                {
                    currentNode = currentNode.RightChild;
                }
                deletion.Value = currentNode.Value;
                if(currentNode.LeftChild != null)
                {
                    currentNode.Parent.RightChild = currentNode.LeftChild;
                    currentNode.LeftChild.Parent = currentNode.Parent;
                    return true;
                }
                else
                {
                    currentNode.Parent.RightChild = null;
                    return true;
                }
            }
            return false;
        }
    }
}
