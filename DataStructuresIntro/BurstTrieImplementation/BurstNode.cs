namespace DataStructures.BurstTrieImplementation
{
    // Polymorphic base for the two types of nodes in the Trie
    public abstract class BurstNode
    {
        internal BurstTrie ParentTrie;
        public abstract int Count { get; }
        protected BurstNode(BurstTrie parent) => ParentTrie = parent;

        public abstract BurstNode Insert(string value, int index);
        public abstract BurstNode Remove(string value, int index, out bool success);
        public abstract BurstNode Search(string prefix, int index);
        internal abstract void GetAll(List<string> output);
    }
}
