using DataStructures;
using Newtonsoft.Json.Linq;

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
        [TestMethod]
        public void DeleteTest()
        {

        }



        [TestMethod]
        [DataRow(18213, 009121)]
        public void RandomiedInsertTest(int size, int seed, int max = 100)
        {
            int[] data = new int[size];
            Random rand = new(seed);
            for (int i = 0; i < size; i++)
            {
                data[i] = rand.Next(max);
            }
            foreach (var item in data)
            {
                tree.Insert(item);
                ValidateTree();
            }
        }
        RedBlackTree<int> tree = new RedBlackTree<int>();
        [TestMethod]
        [DataRow(2, "L", new int[] { 17, 3, 20, 1 })]
        [DataRow(12, "LR", new int[] { 17, 3, 20, 1, 2 })]
        [DataRow(18, "RL", new int[] { 17, 3, 20, 1, 2, 12 })]
        [DataRow(19, "R", new int[] { 17, 3, 20, 1, 2, 12, 18 })]
        [DataRow(47, "RR", new int[] { 17, 3, 20, 1, 2, 12, 18, 19 })]
        [DataRow(49, "RRR", new int[] { 17, 3, 20, 1, 2, 12, 18, 19, 47 })]
        [DataRow(50, "RR", new int[] { 17, 3, 20, 1, 2, 12, 18, 19, 47, 49 })]


        public void InsertTest(int value, string position, int[] values)
        {
            foreach (var item in values)
            {
                tree.Insert(item);
                ValidateTree();
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


        public Queue<RBNode<int>> PreOrder(RBNode<int> node)
        {
            Queue<RBNode<int>> queue = new Queue<RBNode<int>>();
            return PreOrder(node, queue);
        }
        private Queue<RBNode<int>> PreOrder(RBNode<int> node, Queue<RBNode<int>> queue)
        {
            queue.Enqueue(node);

            if (node.Left != null) PreOrder(node.Left, queue);

            if (node.Right != null) PreOrder(node.Right, queue);

            return queue;
        }

        public Queue<int> InOrder(RBNode<int> node)
        {
            Queue<int> queue = new Queue<int>();
            InOrder(node, queue);
            return queue;
        }
        private void InOrder(RBNode<int> node, Queue<int> queue)
        {
            if (node != null)
            {
                InOrder(node.Left, queue);
                queue.Enqueue(node.Value);
                InOrder(node.Right, queue);
            }
        }
        public Queue<int> PostOrder(RBNode<int> node)
        {
            Queue<int> queue = new Queue<int>();
            PostOrder(node, queue);
            return queue;
        }
        private void PostOrder(RBNode<int> node, Queue<int> queue)
        {
            if (node != null)
            {
                PostOrder(node.Left, queue);
                PostOrder(node.Right, queue);
                queue.Enqueue(node.Value);
            }
        }

        public void ValidateTree()
        {
            Assert.IsTrue(tree.root.isBlack);

            Queue<RBNode<int>> traverse = PreOrder(tree.root);

            foreach(var node in traverse)
            {
                CountBlackNodes(node);
            }
        }
        private int CountBlackNodes(RBNode<int> node)
        {
            if (node == null)
            {
                return 1;
            }

            int leftCount = CountBlackNodes(node.Left);
            int rightCount = CountBlackNodes(node.Right);
            if (node.Right != null)
            {
                if (!node.isBlack && !node.Right.isBlack)
                {
                    Assert.Fail("Red-red violation detected.");
                }
            }
            if (node.Left != null)
            {
                if (!node.isBlack && !node.Left.isBlack)
                {
                    Assert.Fail("Red-red violation detected.");
                }
            }

            if (leftCount != rightCount)
            {
                Assert.Fail("Black node count mismatch detected.");
            }

            return node.isBlack ? leftCount + 1 : leftCount;
        }

    }
}
