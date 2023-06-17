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

        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
    class BinarySearchTree<T> where T : IComparable<T>
    {
        BinaryTreeNode<T> Root;
        public int Count { get; private set; }

        //search function: key = value

        public T Minimum()
        {
            BinaryTreeNode<T> currentNode = Root;
            while(currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }
            return currentNode.Value;
        }
        public T Maximum()
        {
            BinaryTreeNode<T> currentNode = Root;
            while(currentNode.RightChild != null)
            {
                currentNode = currentNode.RightChild;
            }
            return currentNode.Value;
        }
        //public bool IsLeftChild(BinaryTreeNode<T> child)
        //{

        //}

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(value, null, null);
                Count++;
                return;
            }
            BinaryTreeNode<T> currentNode = Root;
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value, null, null);
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
                        Count++;
                        break;
                    }
                }
                else
                {
                    while(currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                    }    
                    currentNode.RightChild = newNode;
                    Count++;
                }
            }
        }

    }
}
