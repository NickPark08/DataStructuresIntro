using DataStructures;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

public class BTree<T> where T : IComparable<T>
{
    public BTreeNode<T> root;

    public bool Search(T value)
    {
        var currentNode = root;
        while (currentNode.children.Count != 0)
        {
            bool isBiggest = true;
            for(int i = 0; i < currentNode.values.Count; i++)
            {
                if (value.CompareTo(currentNode.values[i]) < 0)
                {
                    currentNode = currentNode.children[i];
                    isBiggest = false;
                }
            }
            if(isBiggest)
            {
                currentNode = currentNode.children[currentNode.children.Count - 1];
            }
            if (currentNode.values.Contains(value)) return true;
        }
        return false;
    }
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

            if (root.children.Count == 4)
            {
                newNode.children[0].children.AddRange(root.children.GetRange(0, 2));
                newNode.children[1].children.AddRange(root.children.GetRange(2, 2));
            }
            else if (root.children.Count >= 2)
            {
                newNode.children[0].children.AddRange(root.children[0].children.GetRange(0, 2));
                newNode.children[0].children.AddRange(root.children[1].children.GetRange(0, 2));
            }

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
            if (index >= node.children.Count)
            {
                index = node.children.Count - 1;
            }
            if (node.children[index].values.Count == 3)
            {
                int moveChild = 0;
                AddValue(node.children[index].values[1], node);
                node.children[index].values.RemoveAt(1);

                while (moveChild < node.values.Count && node.children[index].values[1].CompareTo(node.values[moveChild]) >= 0)
                {
                    moveChild++;
                }
                node.children.Insert(moveChild, new BTreeNode<T>(node.children[index].values[1]));
                node.children[index].values.RemoveAt(1);
            }
            int newIndex = 0;
            while (newIndex < node.values.Count && value.CompareTo(node.values[newIndex]) > 0)
            {
                newIndex++;
            }

            Insert(node.children[newIndex], value);

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

