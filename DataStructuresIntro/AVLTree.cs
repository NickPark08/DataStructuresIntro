using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class AVLTreeNode<T> where T : IComparable<T>
    {
        T Value;
        AVLTreeNode<T> LeftChild;
        AVLTreeNode<T> RightChild;
        int Height;
        public AVLTreeNode(T value, AVLTreeNode<T> leftChild, AVLTreeNode<T> rightChild, int height) 
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            Height = height;
        }    
        public int GetCount()
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
            return RightChild.Height - LeftChild.Height;
        }
    }
    class AVLTree<T> where T : IComparable<T>
    {
        AVLTreeNode<T> Root;

        public void Insert(T value)
        {

        }
    }
}
