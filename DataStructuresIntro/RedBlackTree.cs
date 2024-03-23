using DataStructuresIntro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            Insert(val, ref root);
        }
        private void Insert(T val, ref RBNode<T> currentNode)
        {
            if (currentNode.Left != null && currentNode.Right != null && !currentNode.Left.isBlack && !currentNode.Right.isBlack)
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
            currentNode.isBlack = false;
            currentNode.Right.isBlack = true;
            currentNode.Left.isBlack = true;

            if (currentNode == root)
            {
                root.isBlack = true;
            }
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

        private void MoveRedRight(RBNode<T> currentNode)
        {
            if (currentNode.Right == null) return;


        }

        private void MoveRedLeft()
        {

        }

    }
}
