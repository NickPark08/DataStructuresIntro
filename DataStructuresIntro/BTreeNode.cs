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
        public List<BTreeNode<T>> children;
        public List<T> values;

        public BTreeNode(T v1)
            : this(v1, new List<BTreeNode<T>>()) { }

        public BTreeNode(T value, List<BTreeNode<T>> children)
        {
            values = new List<T>() { value };

            this.children = children ?? throw new ArgumentNullException(nameof(children));
        }
    }
}
