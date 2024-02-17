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

        public string DecompressFile(string file)
        {
            string binary = "";
            foreach(byte b in newFile)
            {
                string temp = Convert.ToString(b, 2);
                while(temp.Length != 8)
                {
                    temp = "0" + temp;
                }

                binary += temp;
            }

            //use tree to decompress file
            //once working, use heap to put tree at start of file

            return binary;

        }

        public void CompressFile(string file)
        {
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
                HuffmanNode parent = new HuffmanNode(default, left, right, left.Frequency + right.Frequency);
                Queue.Enqueue(parent, parent.Frequency);
            }

            MapChars();
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
            newFile.Add(Convert.ToByte(binary.Length % 8));
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
