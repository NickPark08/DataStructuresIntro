using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BurstTrieImplementation
{
    public class BurstTrie
    {
        BurstNode root;
        internal int BucketSize;
        internal char Start;
        internal char End;

        public BurstTrie(int bucketSize, char start, char end)
        {
            BucketSize = bucketSize;
            Start = start;
            End = end;
            root = new NodeContainer(this);
        }

        public void Insert(string value)
        {
            foreach (var c in value)
            {
                if (c < Start || c > End) throw new Exception("string contains characters not in range");
            }

            root = root.Insert(value, 0);
        }

        public bool Remove(string value)
        {
            root = root.Remove(value, 0, out bool temp);
            return temp;
        }

        public BurstNode Search(string value)
        {
            return root.Search(value, 0);
        }

        public List<string> GetAll()
        {
            List<string> list = new List<string>();

            root.GetAll(list);

            return list;
        }
    }
}
