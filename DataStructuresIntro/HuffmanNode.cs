using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HuffmanNode
    {
        public int Frequency;
        public HuffmanNode LeftChild;
        public HuffmanNode RightChild;
        public char Value;

        public HuffmanNode(char value, HuffmanNode left, HuffmanNode right, int frequency) 
        {
            Frequency = frequency;
            LeftChild = left;
            RightChild = right;
            Value = value;
        }
    }
}
