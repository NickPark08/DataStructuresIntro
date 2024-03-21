using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTestRedBlackTree
    {

        RedBlackTree<int> tree = new RedBlackTree<int>();
        [TestMethod]
        [DataRow(2, "L", new int[] { 17, 3, 20, 1 })]
        [DataRow(12, "LR", new int[] { 17, 3, 20, 1, 2 })]
        [DataRow(18, "RL", new int[] { 17, 3, 20, 1, 2, 12 })]
        [DataRow(19, "R", new int[] { 17, 3, 20, 1, 2, 12, 18 })]
        [DataRow(47, "RR", new int[] { 17, 3, 20, 1, 2, 12, 18, 19 })]
        [DataRow(49, "RRR", new int[] { 17, 3, 20, 1, 2, 12, 18, 19, 47 })]
        [DataRow(50, "RRR", new int[] { 17, 3, 20, 1, 2, 12, 18, 19, 47, 49 })]


        public void InsertTest(int value, string position, int[] values)
        {
            foreach (var item in values)
            {
                tree.Insert(item);
            }
            tree.Insert(value);

            RBNode<int> currentNode = tree.root;
            for (int i = 0; i < position.Length; i++)
            {
                currentNode = position[i] == 'L' ? currentNode.Left : currentNode.Right;
            }
            Assert.AreEqual(currentNode.Value, value);

            ValidateTree();
        }
        //write dfs, which returns me a list of nodes, preorder, inorder, and postorder
        //i want a public func and priv one (helper)
        //priv one should max 4 lines not including curly braces

        public void ValidateTree()
        {
            Stack<RBNode<int>> stack = new Stack<RBNode<int>>();
            //Queue<int> queue = new Queue<int>();
            Assert.IsTrue(tree.root.isBlack);

            stack.Push(tree.root);
            while (stack.Count > 0)
            {
                List<int> counts = new List<int>();
                RBNode<int> currentNode;
                currentNode = stack.Pop();

                if(currentNode.Right != null && currentNode.Left != null) Assert.IsTrue(!currentNode.isBlack && currentNode.Left.isBlack && currentNode.Right.isBlack);

                Stack<RBNode<int>> nullStack = new Stack<RBNode<int>>();
                RBNode<int> node = currentNode;
                nullStack.Push(currentNode);
                int count = 0;
                while(nullStack.Count > 0)
                {
                    node = nullStack.Pop();
                    if (currentNode.Right != null)
                    {
                        nullStack.Push(node.Right);
                    }
                    if (currentNode.Left != null)
                    {
                        nullStack.Push(node.Left);
                    }
                    count++;
                }
                counts.Add(count);
                foreach(int val in counts)
                {
                    if (val != counts[0]) Assert.Fail();
                }

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }
        }
    }
}
