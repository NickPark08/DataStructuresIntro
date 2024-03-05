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
        {
            values = new List<T>();
            values.Add(v1);
            children = new List<BTreeNode<T>>();
        }
    }
}
