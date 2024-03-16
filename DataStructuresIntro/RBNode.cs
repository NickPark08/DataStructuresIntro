using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class RBNode<T>
    {
        public bool isBlack;
        public RBNode<T> Left;
        public RBNode<T> Right;
        public T Value;
        public RBNode(T val, bool black)
        {
            Value = val;
            isBlack = black;
        }
    }
}
