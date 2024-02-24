using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

using DataStructuresIntro;

namespace DataStructures
{
    public class FixedLengthEncoding
    {
        string OriginalFile;
        PriorityQueue<HuffmanNode, int> Queue;
        Dictionary<char, string> map;
        List<byte> newFile = new List<byte>();

        HuffmanNode root;

        public FixedLengthEncoding(string file)
        {
            OriginalFile = file;
            Queue = new PriorityQueue<HuffmanNode, int>();
            map = new Dictionary<char, string>();
        }

        public string DecompressFile()
        {
            string binary = "";
            int finalLength = newFile[0];
            for (int i = 1; i < newFile.Count; i++)
            {
                string temp = Convert.ToString(newFile[i], 2);
                while (temp.Length != 8)
                {
                    temp = '0' + temp;
                }

                binary += temp;
            }

            HuffmanNode tempRoot;

            if (binary[0] == '1')
            {
                tempRoot = new HuffmanNode('$', null, null, 0);
            }
            else
            {

            }

            for(int i = 0; i < binary.Length; i++)
            {
                HuffmanNode newNode;
                if (binary[i] == '1')
                {
                    newNode = new HuffmanNode('$', null, null, 0);
                }
                else
                {

                }
            }
            string temp1 = binary.Substring(0, binary.Length - 8);
            binary = temp1 + binary.Substring(binary.Length - finalLength) + '0';
            //once working, put tree at start of file


            var currentNode = root;
            string decompressed = "";

            for (int i = 0; i < binary.Length; i++)
            {
                if (currentNode.LeftChild == null && currentNode.RightChild == null)
                {
                    decompressed += currentNode.Value;
                    currentNode = root;
                }

                if (binary[i] == '0')
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }

            return decompressed;

        }

        public void CompressFile(string file)
        {
            var tree = PreOrder();
            string nodes = "";
            foreach (var node in tree)
            {
                if (node.LeftChild != null && node.RightChild != null)
                {
                    nodes += '1';
                }
                else
                {
                    string temp = Convert.ToString(node.Value, 2);
                    while (temp.Length != 7)
                    {
                        temp = "0" + temp;
                    }
                    nodes += "0" + temp;
                }
            }
            //for (int i = 0; i < nodes.Length - 8; i += 8)
            //{
            //    string temp = nodes.Substring(i, 8);
            //    //newFile.Add(Convert.ToByte(temp, 2));
            //}

            LettersToBytes(file);
            File.WriteAllBytes("output.txt", newFile.ToArray());
        }

        public void FillTree()
        {
            int[] frequencies = new int[127];
            foreach (char letter in OriginalFile)
            {
                int index = (int)letter;
                frequencies[index]++;
            }

            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] != 0)
                {
                    var node = new HuffmanNode((char)(i), default, default, frequencies[i]);
                    Queue.Enqueue(node, node.Frequency);
                }
            }

            while (Queue.Count > 1)
            {
                HuffmanNode left = Queue.Dequeue();
                HuffmanNode right = Queue.Dequeue();
                HuffmanNode parent = new HuffmanNode('$', left, right, left.Frequency + right.Frequency);
                Queue.Enqueue(parent, parent.Frequency);
            }

            MapChars();
        }

        private Queue<HuffmanNode> PreOrder()
        {
            Stack<HuffmanNode> stack = new Stack<HuffmanNode>();
            Queue<HuffmanNode> queue = new Queue<HuffmanNode>();

            stack.Push(root);
            while (stack.Count > 0)
            {
                HuffmanNode currentNode;
                currentNode = stack.Pop();

                queue.Enqueue(currentNode);

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

        private void LettersToBytes(string file)
        {
            string binary = "";

            for (int i = 0; i < file.Length; i++)
            {
                if (map.ContainsKey(file[i]))
                {
                    binary += map[file[i]];
                }
            }
            // add tree before adding count and rest of file
            newFile.Add(Convert.ToByte(binary.Length % 8));

            for (int i = 0; i < binary.Length - 8; i += 8)
            {
                string temp = binary.Substring(i, 8);
                newFile.Add(Convert.ToByte(temp, 2));
            }
            if (binary.Length % 8 != 0)
            {
                string last = binary.Substring(binary.Length - binary.Length % 8);
                newFile.Add(Convert.ToByte(last, 2));
            }
        }

        private void MapChars()
        {
            Stack<HuffmanNode> traversal = new Stack<HuffmanNode>();
            root = Queue.Peek();

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
                    map.Add(currentNode.Value, currentNode.Binary);
                }
            }
        }

    }
}
