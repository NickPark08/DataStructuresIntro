using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public RBNode<T> root;
        public void Insert(T val)
        {
            if (root == null)
            {
                root = new RBNode<T>(val, true);
                return;
            }

            Insert(val, root);
        }
        private void Insert(T val, RBNode<T> currentNode)
        {
            if (currentNode.Left != null && val.CompareTo(currentNode.Value) < 0)
            {
                Insert(val, currentNode.Left);
            }
            else if (currentNode.Right != null)
            {
                Insert(val, currentNode.Right);
            }

            else
            {
                if (val.CompareTo(currentNode.Value) <= 0)
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

            if (currentNode.Right != null && !currentNode.Right.isBlack)
            {
                RotateLeft(currentNode);
            }

            if (currentNode.Left != null && currentNode.Left.Left != null && !currentNode.Left.isBlack && !currentNode.Left.Left.isBlack)
            {
                RotateRight(currentNode);
            }
        }
        private void FlipColor(RBNode<T> currentNode)
        {
            currentNode.isBlack = false;
            currentNode.Right.isBlack = true;
            currentNode.Left.isBlack = true;

            if (currentNode == root)
            {
                root.isBlack = true;
            }
        }
        private void RotateLeft(RBNode<T> currentNode)
        {
            var right = currentNode.Right;
            if (right.Left != null)
            {
                currentNode.Right = right.Left;
                right.Left = currentNode;
            }

            right.isBlack = true;
            currentNode.isBlack = false;
        }
        private void RotateRight(RBNode<T> currentNode)
        {
            var left = currentNode.Left;
            currentNode.Left = left.Right;
            left.Right = currentNode;

            left.isBlack = true;
            currentNode.isBlack = false;
        }

    }
}
