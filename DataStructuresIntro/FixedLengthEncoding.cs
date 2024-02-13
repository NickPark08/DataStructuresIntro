using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                int index = (int) letter;
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
            do
            {
                HuffmanNode left = Queue.Dequeue();
                HuffmanNode right = Queue.Dequeue();
                HuffmanNode parent = new (default, left, right, left.Frequency + right.Frequency);

                Queue.Enqueue(parent, parent.Frequency);
            } while (Queue.Count > 1);

            MapChars();

        }
        private void MapChars()
        {
            Stack<HuffmanNode> traversal = new Stack<HuffmanNode>();
            Stack<char> stack = new Stack<char>();
            var root = Queue.Peek();
            string binary = "";

            traversal.Push(root);
            while (traversal.Count > 0)
            {
                var currentNode = traversal.Pop();
                stack.Push(currentNode.Value);

                if (currentNode.LeftChild != null)
                {
                    traversal.Push(currentNode.LeftChild);
                }
                if (currentNode.RightChild != null)
                {
                    traversal.Push(currentNode.RightChild);
                }

                if(currentNode.LeftChild != null && currentNode.RightChild != null)
                {
                    binary += "0";
                }
                else if (currentNode.RightChild == null)
                {
                    binary += "1";
                }
                else
                {
                    binary = binary.Substring(0, binary.Length - 2);
                }

                if (currentNode.LeftChild == null && currentNode.RightChild == null)
                {
                    map.Add(binary, currentNode.Value);
                }
            }

        }
    }
}
