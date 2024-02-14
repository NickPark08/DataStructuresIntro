using System;
using System.Collections.Generic;
using DataStructuresIntro;

namespace DataStructures
{
    public class FixedLengthEncoding
    {
        string File;
        PriorityQueue<HuffmanNode, int> Queue;
        Dictionary<string, char> map;

        public FixedLengthEncoding(string file)
        {
            File = file;
            Queue = new PriorityQueue<HuffmanNode, int>();
            map = new Dictionary<string, char>();
        }

        public void FillTree()
        {
            int[] frequencies = new int[127];
            foreach (char letter in File)
            {
                int index = (int)letter;
                frequencies[index]++;
            }

            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] != 0)
                {
                    HuffmanNode node = new HuffmanNode((char)(i), default, default, frequencies[i]);
                    Queue.Enqueue(node, node.Frequency);
                }
            }

            while (Queue.Count > 1)
            {
                HuffmanNode left = Queue.Dequeue();
                HuffmanNode right = Queue.Dequeue();
                HuffmanNode parent = new HuffmanNode(default, left, right, left.Frequency + right.Frequency);
                Queue.Enqueue(parent, parent.Frequency);
            }

            MapChars();
        }

        private void MapChars()
        {
            Stack<HuffmanNode> traversal = new Stack<HuffmanNode>();
            var root = Queue.Peek();

            traversal.Push(root);
            while (traversal.Count > 0)
            {
                var currentNode = traversal.Pop();

                if (currentNode.LeftChild != null)
                {
                    currentNode.LeftChild.Binary = currentNode.Binary + "0";
                    traversal.Push(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    currentNode.RightChild.Binary = currentNode.Binary + "1";
                    traversal.Push(currentNode.RightChild);
                }

                if (currentNode.LeftChild == null && currentNode.RightChild == null)
                {
                    map.Add(currentNode.Binary, currentNode.Value);
                }
            }
        }

    }
}
