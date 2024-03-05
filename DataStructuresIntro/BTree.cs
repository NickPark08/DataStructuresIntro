using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataStructures
{
    public class BTree<T> where T : IComparable<T>
    {
        BTreeNode<T> root;

        public void Insert(T value)
        {
            if (root == null)
            {
                root = new BTreeNode<T>(value);
                return;
            }
            var currentNode = root;
            BTreeNode<T> previousNode = null;
            bool rootOnly = true;


            if (currentNode.values.Count == 3)
            {
                BTreeNode<T> newNode = new BTreeNode<T>(currentNode.values[1]);
                newNode.children.Add(new BTreeNode<T>(currentNode.values[0]));
                newNode.children.Add(new BTreeNode<T>(currentNode.values[2]));
                if (value.CompareTo(newNode.values[0]) < 0)
                {
                    AddValue(value, newNode.children[0]);
                }
                else
                {
                    AddValue(value, newNode.children[1]);
                }
                root = newNode;

            }



            while (currentNode.children.Count != 0)
            {
                if (currentNode.values.Count == 1)
                {
                    if (value.CompareTo(currentNode.values[0]) < 0)
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.children[0];
                    }
                    else
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.children[1];
                    }
                }
                else if (currentNode.values.Count == 2)
                {
                    if (value.CompareTo(currentNode.values[0]) < 0)
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.children[0];
                    }
                    else if (value.CompareTo(currentNode.values[0]) > 0 && value.CompareTo(currentNode.values[1]) < 0)
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.children[1];
                    }
                    else
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.children[2];
                    }
                }
                else if (currentNode.values.Count == 3)
                {

                }
            }
            if (currentNode.values.Count == 3 && !rootOnly)
            {
                AddValue(currentNode.values[1], previousNode);
                previousNode.children.Add(new BTreeNode<T>(currentNode.values[0]));
                previousNode.children.Add(new BTreeNode<T>(currentNode.values[2]));
                if (value.CompareTo(previousNode.values[0]) < 0)
                {
                    AddValue(value, previousNode.children[0]);
                }
                else
                {
                    AddValue(value, previousNode.children[1]);
                }
            }
            else
            {
                AddValue(value, currentNode);
            }
        }

        private void AddValue(T value, BTreeNode<T> currentNode)
        {
            bool isHighest = true;
            for (int i = 0; i < currentNode.values.Count; i++)
            {
                if (value.CompareTo(currentNode.values[i]) < 0)
                {
                    currentNode.values.Insert(i, value);
                    isHighest = false;
                    break;
                }
            }
            if (isHighest)
            {
                currentNode.values.Add(value);
            }
        }
    }
}
