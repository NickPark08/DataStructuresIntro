using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        //    return (RightChild == null ? 0 : RightChild.Height) - (LeftChild == null ? 0 : LeftChild.Height); 

            if (RightChild == null && LeftChild == null) return 0;

            else if (LeftChild == null) return RightChild.Height - 0;

            else if (RightChild == null) return 0 - LeftChild.Height;

            else return RightChild.Height - LeftChild.Height;

        }
        public int GetHeight()
        {
            if (LeftChild == null && RightChild == null) Height = 1;

            else if (LeftChild == null || (RightChild != null && LeftChild.Height < RightChild.Height))
            {
                Height = RightChild.Height + 1;
            }
            else
            {
                Height = LeftChild.Height + 1;
            }
            return Height;
        }
        public bool HasLeftChild()
        {
            if (LeftChild == null) return false;

            else return true;
        }
    }
    class AVLTree<T> where T : IComparable<T>
    {
        public AVLTreeNode<T> Root;

        public AVLTreeNode<T> RotateLeft(AVLTreeNode<T> node)
        {
            var temp = node.RightChild;
            node.RightChild = node.RightChild.LeftChild;
            temp.LeftChild = node;
            node.GetHeight();
            temp.GetHeight();
            return temp;
        }
        public AVLTreeNode<T> RotateRight(AVLTreeNode<T> node)
        {
            var temp = node.LeftChild;
            node.RightChild = temp.RightChild;
            node.LeftChild = node.LeftChild.RightChild;
            temp.RightChild = node;
            node.GetHeight();
            temp.GetHeight();
            return temp;
        }

        public Queue<T> PreOrder()
        {
            Stack<AVLTreeNode<T>> stack = new Stack<AVLTreeNode<T>>();
            Queue<T> queue = new Queue<T>();

            stack.Push(Root);
            while (stack.Count > 0)
            {
                AVLTreeNode<T> currentNode;
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
            Stack<AVLTreeNode<T>> stack = new Stack<AVLTreeNode<T>>();
            Queue<T> queue = new Queue<T>();

            AVLTreeNode<T> currentNode = Root;

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

        private AVLTreeNode<T> ReBalance(AVLTreeNode<T> currentNode)
        {
            if (currentNode.GetBalance() > 1)
            {
                if (currentNode.RightChild.GetBalance() <= -1)
                {
                    currentNode.RightChild = RotateRight(currentNode.RightChild);
                }
                return RotateLeft(currentNode);
            }
            else if (currentNode.GetBalance() < -1)
            {
                if (currentNode.LeftChild.GetBalance() >= 1)
                {
                    currentNode.LeftChild = RotateLeft(currentNode.LeftChild);
                }
                return RotateRight(currentNode);
            }

            currentNode.GetHeight();
            return currentNode;
        }

        public void Insert(T value)
        {
            Root = Insert(value, Root);
        }
        private AVLTreeNode<T> Insert(T value, AVLTreeNode<T> currentNode)
        {
            if (currentNode == null) return new(value);

            if (value.CompareTo(currentNode.Value) < 0)
            {
                currentNode.LeftChild = Insert(value, currentNode.LeftChild);
            }
            else
            {
                currentNode.RightChild = Insert(value, currentNode.RightChild);
            }

            return ReBalance(currentNode);
        }

        public void Delete(T value)
        {
            Root = Delete(value, Root);
        }
        private AVLTreeNode<T> Delete(T value, AVLTreeNode<T> currentNode)
        {
            if (value.CompareTo(currentNode.Value) < 0)
            {
                currentNode.LeftChild = Delete(value, currentNode.LeftChild);
            }
            else if (value.CompareTo(currentNode.Value) > 0)
            {
                currentNode.RightChild = Delete(value, currentNode.RightChild);
            }

            else
            {
                if (currentNode.GetChildCount() == 0)
                {
                    return null;
                }
                else if (currentNode.GetChildCount() == 1)
                {
                    if (currentNode.HasLeftChild())
                    {
                        currentNode.LeftChild.GetHeight();
                        return currentNode.LeftChild;
                    }
                    else
                    {
                        currentNode.RightChild.GetHeight();
                        return currentNode.RightChild;
                    }
                }
                else if (currentNode.GetChildCount() == 2)
                {
                    AVLTreeNode<T> temp = currentNode.LeftChild;
                    if (temp.RightChild != null)
                    {
                        temp.RightChild = ChildRecursion(temp.RightChild);
                    }

                    //get to very right child by recursion, then recurse back up to rebalance that nodes' parent (not currentNode.Left)


                    currentNode.Value = temp.Value;
                    currentNode.LeftChild.RightChild = temp.LeftChild;

                    currentNode.GetHeight();
                    ReBalance(currentNode.LeftChild);
                    return currentNode;
                }

            }
            currentNode.GetBalance();
            return ReBalance(currentNode);
        }

        public AVLTreeNode<T> ChildRecursion(AVLTreeNode<T> currentNode)
        {
            return currentNode.RightChild;
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
