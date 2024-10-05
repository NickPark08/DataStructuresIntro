namespace DataStructures.BurstTrieImplementation
{
    public class NodeInternal : BurstNode
    {
        BurstNode[] children;
        public NodeInternal(BurstTrie parent) : base(parent)
        {
            children = new BurstNode[parent.End - parent.Start];
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
                bucketIndex = value[index] - ParentTrie.Start;
            }

            if (children[bucketIndex] == null)
            {
                children[bucketIndex] = new NodeContainer(ParentTrie);
            }

            children[bucketIndex].Insert(value, index + 1);

            return this;
        }

        public override BurstNode Remove(string value, int index, out bool success)
        {
            throw new NotImplementedException();
        }

        public override BurstNode Search(string prefix, int index)
        {
            throw new NotImplementedException();
        }

        internal override void GetAll(List<string> output)
        {
            throw new NotImplementedException();
        }
    }
}
