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
            if(root == null)
            {
                root = new BTreeNode<T>(value);
                return;
            }
            var currentNode = root;
            while(currentNode.children.Count() != 0)
            {
                if (currentNode.values.Count() == 1)
                {
                    if (value.CompareTo(currentNode.values[0]) < 0)
                    {
                        currentNode = currentNode.children[0];
                    }
                    else
                    {
                        currentNode = currentNode.children[1];
                    }
                }
                else if (currentNode.values.Count() == 2)
                {
                    if (value.CompareTo(currentNode.values[0]) < 0)
                    {
                        currentNode = currentNode.children[0];
                    }
                    else if (value.CompareTo(currentNode.values[0]) > 0 && value.CompareTo(currentNode.values[0]) < 0)
                    {
                        currentNode = currentNode.children[1];
                    }
                    else
                    {
                        currentNode = currentNode.children[2];
                    }
                }
                else
                { // finish if statements to traverse tree to add value
                    else if (value.CompareTo(currentNode.values[1]) > 0 && value.CompareTo(currentNode.values[2]) < 0)
                    {
                        currentNode = currentNode.children[2];
                    }
                    else
                    {
                        currentNode = currentNode.children[3];
                    }
                }
            }


        }
    }
}
