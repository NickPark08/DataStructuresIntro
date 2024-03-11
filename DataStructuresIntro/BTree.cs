using DataStructures;

using System;
using System.Collections.Generic;

public class BTree<T> where T : IComparable<T>
{
    public BTreeNode<T> root;

    public void Insert(T value)
    {
        if (root == null)
        {
            root = new BTreeNode<T>(value);
            return;
        }

        if (root.values.Count == 3)
        {
            var newNode = new BTreeNode<T>(root.values[1]);
            newNode.children.Add(new BTreeNode<T>(root.values[0]));
            newNode.children.Add(new BTreeNode<T>(root.values[2]));

            if (root.children.Count >= 2)
            {
                newNode.children[0].children.AddRange(root.children[0].children.GetRange(0, 2));
                newNode.children[0].children.AddRange(root.children[1].children.GetRange(0, 2));
            }

            //if (root.children.Count >= 4)
            //{
            //    newNode.children[1].children.AddRange(root.children[2].children.GetRange(0, 2));
            //    newNode.children[1].children.AddRange(root.children[3].children.GetRange(0, 2));
            //}

            root = newNode;
        }
        Insert(root, value);
    }

    private void Insert(BTreeNode<T> node, T value)
    {
        if (node.children.Count == 0)
        {
            AddValue(value, node);
        }
        else
        {
            int index = 0;
            while (index < node.values.Count && value.CompareTo(node.values[index]) > 0)
            {
                index++;
            }
            if(index >= node.children.Count)
            {
                index = node.children.Count - 1;
            }
            if (node.children[index].values.Count == 3)
            {
                var child = node.children[index];
                var newNode = new BTreeNode<T>(child.values[1]);
                newNode.children.Add(new BTreeNode<T>(child.values[0]));
                newNode.children.Add(new BTreeNode<T>(child.values[2]));

                if (child.children.Count >= 2)
                {
                    newNode.children[0].children.AddRange(child.children[0].children.GetRange(0, 2));
                    newNode.children[0].children.AddRange(child.children[1].children.GetRange(0, 2));
                }

                if (child.children.Count == 4)
                {
                    newNode.children[1].children.AddRange(child.children[2].children.GetRange(0, 2));
                    newNode.children[1].children.AddRange(child.children[3].children.GetRange(0, 2));
                }

                node.children.RemoveAt(index);
                node.values.Insert(index, child.values[1]);
                node.children.Insert(index, newNode);
            }
            Insert(node.children[index], value);

        }
    }

    private void AddValue(T value, BTreeNode<T> node)
    {
        int index = 0;
        while (index < node.values.Count && value.CompareTo(node.values[index]) >= 0)
        {
            index++;
        }
        node.values.Insert(index, value);
    }

}

