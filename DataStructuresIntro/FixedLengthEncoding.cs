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
            Stack<HuffmanNode> stack = new Stack<HuffmanNode>();
            string binary = "";
            //int nodesLength = newFile[0];
            for (int i = 1; i < newFile.Count; i++)
            {
                string temp = Convert.ToString(newFile[i], 2);
                while (temp.Length != 8)
                {
                    temp = '0' + temp;
                }

                binary += temp;
            }

            HuffmanNode previousNode;

            // root
            if (binary[0] == '1')
            {
                previousNode = new HuffmanNode('$', null, null, 0);
                stack.Push(previousNode);
            }
            else
            {
                string temp = "";
                for (int i = 1; i < 9; i++)
                {
                    temp += binary[i];
                }
                var c = Convert.ToChar(Convert.ToByte(temp, 2));
                previousNode = new HuffmanNode(c, null, null, 0);
            }

            // rest

            int index = 1;
            int indexByte = 0;
            while (stack.Count > 0)
            {
                HuffmanNode newNode;
                if (binary[index] == '1')
                {
                    newNode = new HuffmanNode('$', null, null, 0);
                    if (stack.Peek().LeftChild == null)
                    {
                        stack.Peek().LeftChild = newNode;
                    }
                    else
                    {
                        stack.Peek().RightChild = newNode;
                        stack.Pop();
                    }
                    stack.Push(newNode);
                    index++;
                }
                else
                {
                    string temp = "";

                    for (int j = index; j < index + 8; j++)
                    {
                        temp += binary[j];
                        //                                    "01100101"
                        //"10111010010111001110110101010010000001100101"
                        //"101110100101110011101101010100100000011000000110011111001110000100011010"
                        //"101110100101110011101101010100100000011001010000"
                    }
                    var c = Convert.ToChar(Convert.ToByte(temp, 2));
                    newNode = new HuffmanNode(c, null, null, 0);
                    if(stack.Peek().LeftChild == null)
                    {
                        stack.Peek().LeftChild = newNode;
                    }
                    else
                    {
                        stack.Peek().RightChild = newNode;
                        stack.Pop();
                    }
                    index += 8;
                    indexByte++;
                }
            }
            index += index % 8;
            int finalLength = newFile[0];

            string temp1 = binary.Substring(index, binary.Length - index - 8);
            binary = temp1 + binary.Substring(binary.Length - finalLength) + '0';

            var currentNode = previousNode;
            string decompressed = "";

            for (int i = 0; i < binary.Length; i++)
            {
                if (currentNode.LeftChild == null && currentNode.RightChild == null)
                {
                    decompressed += currentNode.Value;
                    currentNode = previousNode;
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

            //while(nodes.Length % 8 != 0)
            //{
            //    nodes += '0';
            //}
            //for (int i = 0; i < nodes.Length - 8; i += 8)
            //{
            //    string temp = nodes.Substring(i, 8);
            //    newFile.Add(Convert.ToByte(temp, 2));
            //}

            LettersToBytes(file, nodes);
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

        private void LettersToBytes(string file, string nodeBinary)
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

            binary = nodeBinary + binary;

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
