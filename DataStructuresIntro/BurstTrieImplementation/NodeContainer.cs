using DataStructuresIntro;

namespace DataStructures.BurstTrieImplementation
{
    public class NodeContainer : BurstNode
    {
        BinarySearchTree<string> binaryTree;
        public NodeContainer(BurstTrie parent) : base(parent)
        {
            binaryTree = new BinarySearchTree<string>();
        }


        public override int Count => binaryTree.Count;

        public override BurstNode Insert(string value, int index)
        {
            if(binaryTree.Count == ParentTrie.BucketSize)
            {
                NodeInternal newNode = new NodeInternal(ParentTrie);
                foreach(var val in binaryTree.InOrder())
                {
                    newNode.Insert(val, index);
                }

                return newNode;
            }

            binaryTree.Insert(value);
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
