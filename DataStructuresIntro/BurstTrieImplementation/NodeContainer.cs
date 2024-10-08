using DataStructuresIntro;

namespace DataStructures.BurstTrieImplementation
{
    public class NodeContainer : BurstNode
    {
        public BinarySearchTree<string> binaryTree;
        public NodeContainer(BurstTrie parent) : base(parent)
        {
            binaryTree = new BinarySearchTree<string>();
        }


        public override int Count => binaryTree.Count;

        public override BurstNode Insert(string value, int index)
        {
            binaryTree.Insert(value);
            if(binaryTree.Count == ParentTrie.BucketSize)
            {
                NodeInternal newNode = new NodeInternal(ParentTrie);
                foreach(var val in binaryTree.InOrder())
                {
                    newNode.Insert(val, index);
                }

                return newNode;
            }

            return this;
        }

        public override BurstNode Remove(string value, int index, out bool success)
        {
            if(binaryTree.InOrder().Contains(value))
            {
                binaryTree.Delete(value);
                success = true;
            }
            else
            {
                success = false;
            }

            if (Count == 0) return null;
            else return this;
        }

        public override BurstNode Search(string prefix, int index)
        {
            if(binaryTree.InOrder().Contains(prefix))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        internal override void GetAll(List<string> output)
        {
            foreach(var val in binaryTree.InOrder())
            {
                output.Add(val);
            }
        }
    }
}
