using DataStructuresIntro;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataStructures
{
    public class BTreeNode<T>
    {
        public List<T> values;
        public List<BTreeNode<T>> children;

        public BTreeNode(T value)
        {
            values = new List<T> { value };
            children = new List<BTreeNode<T>>();
        }

        public BTreeNode(T value, List<BTreeNode<T>> children)
        {
            values = new List<T> { value };
            this.children = children;
        }
    }
}
