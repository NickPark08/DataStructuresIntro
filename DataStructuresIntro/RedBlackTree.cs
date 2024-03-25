﻿using DataStructuresIntro;
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
            //fix this function, losing conections to 12 and 3
            
            if (currentNode.Right == null) return;

            if (currentNode.Right.Right != null && !currentNode.Right.Right.isBlack || !currentNode.Right.Left.isBlack) return;

            FlipColor(currentNode);

            if(!currentNode.Left.Left.isBlack)
            {
                RotateRight(ref currentNode);
                FlipColor(currentNode);
            }
        }

        private void MoveRedLeft(RBNode<T> currentNode)
        {
            if (currentNode.Left == null) return;

            if (currentNode.Left.Left?.isBlack == false|| currentNode.Left.Right?.isBlack == false) return;

            FlipColor(currentNode);

            if (currentNode.Right.Left?.isBlack == false)
            {
                RotateRight(ref currentNode.Right);
                RotateLeft(ref currentNode);
                FlipColor(currentNode);
            }
        }

        public void Remove(T val)
        {
            if (root == null) return;

            root = Remove(val, root);
        }

        private RBNode<T> Remove(T val, RBNode<T> currentNode)
        {
            if (currentNode.Left != null && val.CompareTo(currentNode.Value) < 0)
            {
                if(currentNode.Left.isBlack && currentNode.Left.Left.isBlack)
                {
                    MoveRedLeft(currentNode.Left);
                }

                currentNode.Left = Remove(val, currentNode.Left);
            }
            else
            {
                if(!currentNode.Left.isBlack)
                {
                    RotateLeft(ref currentNode.Left);
                }

                if (currentNode.Value.Equals(val) && currentNode.Left == null && currentNode.Right == null)
                {
                    return null;
                }
                else 
                {
                    if (currentNode.Left == null || currentNode.Left.isBlack)
                    {
                        MoveRedRight(currentNode);
                        currentNode.Right = Remove(val, currentNode.Right);
                    }
                    else
                    {
                        RBNode<T> minValue = currentNode.Right;
                        while(minValue.Left != null)
                        {
                            minValue = minValue.Left;
                        }

                        currentNode.Value = minValue.Value;
                        minValue.Value = val;

                        Remove(val);
                    }
                }

            }
            Fixup(currentNode);

            return currentNode;
        }

        public void Fixup(RBNode<T> currentNode)
        {
            if (!isBlack(currentNode.Right)) RotateLeft(ref currentNode);

            if (!isBlack(currentNode.Left) && !isBlack(currentNode.Left.Left))
            {
                RotateRight(ref currentNode);
            }

            if (!isBlack(currentNode.Right) && !isBlack(currentNode.Left)) FlipColor(currentNode);

            if(!isBlack(currentNode.Right))
            {
                RotateLeft(ref currentNode);
            }
            if (currentNode.Left != null && !isBlack(currentNode.Left.Right))
            {
                RotateLeft(ref currentNode.Left);
                if (currentNode.Left.Left != null && currentNode.Left.Left.Left != null && !currentNode.Left.Left
                    .isBlack && !currentNode.Left.Left.Left.isBlack)
                {
                    RotateRight(ref currentNode.Left);
                }
            }
        }

        private bool isBlack(RBNode<T> currentNode)
        {
            if (currentNode == null || currentNode.isBlack) return true;

            return false;
        }
    }
}
