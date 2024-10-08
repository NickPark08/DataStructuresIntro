namespace DataStructures.BurstTrieImplementation
{
    public class NodeInternal : BurstNode
    {
        public BurstNode[] children;
        public NodeInternal(BurstTrie parent) : base(parent)
        {
            children = new BurstNode[parent.End - parent.Start + 2];
        }

        public override int Count => children.Length;

        public override BurstNode Insert(string value, int index)
        {
            int bucketIndex;
            if (index >= value.Length)
            {
                bucketIndex = 0;
            }
            else
            {
                bucketIndex = value[index] - ParentTrie.Start + 1;
            }

            if (children[bucketIndex] == null)
            {
                children[bucketIndex] = new NodeContainer(ParentTrie);
            }

            children[bucketIndex] = children[bucketIndex].Insert(value, index + 1);

            return this;
        }

        public override BurstNode Remove(string value, int index, out bool success)
        {
            int bucketIndex;
            if(index >= value.Length)
            {
                bucketIndex = 0;
            }
            else
            {
                bucketIndex = value[index] - ParentTrie.Start + 1;
            }
            success = true;

            children[bucketIndex] = children[bucketIndex].Remove(value, index + 1, out success);

            return this;
        }

        public override BurstNode Search(string prefix, int index)
        {
            int bucketIndex;
            if (index >= prefix.Length)
            {
                bucketIndex = 0;
            }
            else
            {
                bucketIndex = prefix[index] - ParentTrie.Start + 1;
            }
            return children[bucketIndex].Search(prefix, index + 1);
        }

        internal override void GetAll(List<string> output)
        {
            for(int i = 0; i < children.Length; i++)
            {
                if (children[i] != null)
                {
                    children[i].GetAll(output);
                }
            }
        }
    }
}
