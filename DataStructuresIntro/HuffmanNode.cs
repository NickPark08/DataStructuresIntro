using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HuffmanNode
    {
        public char Value { get; set; }
        public HuffmanNode LeftChild { get; set; }
        public HuffmanNode RightChild { get; set; }
        public int Frequency { get; set; }
        public string Binary { get; set; }

        public HuffmanNode(char value, HuffmanNode leftChild, HuffmanNode rightChild, int frequency)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            Frequency = frequency;
            Binary = "";
        }
    }

}
