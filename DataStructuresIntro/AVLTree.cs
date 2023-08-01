using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class AVLTreeNode<T> where T : IComparable<T>
    {
        public T Value;
        public AVLTreeNode<T> LeftChild;
        public AVLTreeNode<T> RightChild;
        public int Height;
        public AVLTreeNode(T value, AVLTreeNode<T> leftChild, AVLTreeNode<T> rightChild, int height) 
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            Height = height;
        }

        public AVLTreeNode(T value)
            : this(value, null, null, 1) { }

        public int GetChildCount()
        {
            int count = 0;
            if (LeftChild != null)
            {
                count++;
            }
            if (RightChild != null)
            {
                count++;
            }
            return count;
        }
        public int GetBalance()
        {
            if (RightChild == null && LeftChild == null) return 0;

            else if(LeftChild == null) return RightChild.Height - 0;

            else if(RightChild == null)return 0 - LeftChild.Height;

            else return RightChild.Height - LeftChild.Height;

        }
        public int GetHeight()
        {
            if (LeftChild == null || (RightChild != null && LeftChild.Height < RightChild.Height))
            {
                Height = RightChild.Height + 1;
            }
            else
            {
                Height = LeftChild.Height + 1;
            }
            return Height;
        }
    }
    class AVLTree<T> where T : IComparable<T>
    {
        public AVLTreeNode<T> Root;

        public void Insert(T value)
        {
            Root = Insert(value, Root);
        }
        private AVLTreeNode<T> Insert(T value, AVLTreeNode<T> currentNode)
        {
            if (currentNode == null) return new(value);

            if(value.CompareTo(currentNode.Value) < 0)
            {
                currentNode.LeftChild = Insert(value, currentNode.LeftChild);
            }
            else
            {        
                currentNode.RightChild = Insert(value, currentNode.RightChild);
            }

            if (currentNode.GetBalance() > 1)
            {
                //currentNode = currentNode.LeftChild;
                return currentNode.RightChild;
            }
            else if (currentNode.GetBalance() < -1)
            {
                //currentNode = currentNode.RightChild;
                return currentNode.LeftChild;
            }

            currentNode.GetHeight();
            return currentNode;
        }

        //insertion reference

        //public void BSTInsert(T value)
        //{
        //    Root = BSTInsert(value, Root);
        //}
        //private AVLTreeNode<T> BSTInsert(T value, AVLTreeNode<T> current)
        //{
        //    if (current == null) return new(value);

        //    if (value.CompareTo(current.Value) < 0)
        //    {
        //        current.LeftChild = BSTInsert(value, current.LeftChild);
        //    }
        //    else
        //    {
        //        current.RightChild = BSTInsert(value, current.RightChild);
        //    }
        //    //if rotating, just return, the new subtree head
        //    return current;
        //}

    }
}
