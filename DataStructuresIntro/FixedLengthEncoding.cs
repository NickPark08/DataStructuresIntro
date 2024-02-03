using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{


    public class FixedLengthEncoding
    {
        string File;
        PriorityQueue<HuffmanNode, int> Queue;
        public FixedLengthEncoding(string file)
        {
            File = file;
            Queue = new PriorityQueue<HuffmanNode, int>();
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
            HuffmanNode left = Queue.Dequeue();
            HuffmanNode right = Queue.Dequeue();

            HuffmanNode parent = new HuffmanNode(default, left, right, left.Frequency + right.Frequency);
        }
    }
}
