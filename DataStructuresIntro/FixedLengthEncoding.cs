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
                frequencies[letter]++;
            }

            for (int i = 0; i < frequencies.Length; i++)
            {
                HuffmanNode node = new HuffmanNode((char)(i), default, default, frequencies[i]);
                Queue.Enqueue(node, node.Frequency);

            }
            do
            {
                HuffmanNode left = Queue.Dequeue();
                HuffmanNode right = Queue.Dequeue();
                HuffmanNode parent = new (default, left, right, left.Frequency + right.Frequency);

                Queue.Enqueue(parent, parent.Frequency);
            } while (Queue.Count > 1);


        }
        private void MapChars()
        {
            Stack<HuffmanNode> stack = new Stack<HuffmanNode>();
            Queue<char> queue = new Queue<char>();
            var root = Queue.Peek();
            string binary = "";

            stack.Push(root);
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                queue.Enqueue(currentNode.Value);

                if (currentNode.RightChild != null)
                {
                    stack.Push(currentNode.RightChild);
                    binary += "1";
                }
                if (currentNode.LeftChild != null)
                {
                    stack.Push(currentNode.LeftChild);
                    binary += "0";
                }
                if(currentNode.LeftChild == null && currentNode.RightChild == null)
                {
                    map.Add(binary, currentNode.Value);
                    binary = "";
                }
            }
        }
    }
}
