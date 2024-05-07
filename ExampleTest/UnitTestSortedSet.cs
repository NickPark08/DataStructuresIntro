using DataStructures;
using DataStructuresIntro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTestSortedSet
    {
        [TestMethod]
        [DataRow(new int[] { 3, 4, 5 })]
        public void IntersectionTest(int[] intersectVals)
        {
            var tree1 = new RedBlackTree<int>(null);
            var tree2 = new RedBlackTree<int>(null);

            int[] temp1 = new int[] { 1, 2, 3, 4, 5 };
            int[] temp2 = new int[]       { 3, 4, 5, 6, 7, 8 };
            foreach (var val in temp1) tree1.Add(val);
            foreach (var val in temp2) tree2.Add(val);

            var union = tree1.Intersect(tree2);
            int index = 0;
            foreach (var val in union)
            {
                Assert.AreEqual(intersectVals[index], val);
                index++;
            }
        }


        [TestMethod]
        [DataRow(new int[] { 1, 2, 6, 7, 8 })]
        public void UnionTest(int[] unionVals)
        {
            var tree1 = new RedBlackTree<int>(null);
            var tree2 = new RedBlackTree<int>(null);

            int[] temp1 = new int[] { 1, 2, 3, 4, 5 };
            int[] temp2 = new int[]       { 3, 4, 5, 6, 7, 8 };
            foreach(var val in temp1) tree1.Add(val);
            foreach (var val in temp2) tree2.Add(val);

            var union = tree1.Union(tree2);
            int index = 0;
            foreach(var val in union)
            {
                Assert.AreEqual(unionVals[index], val);
                index++;
            }
        }

        [TestMethod]
        [DataRow(7, 10)]
        [DataRow(21, 25)]
        [DataRow(33, 35)]
        [DataRow(10, 10)]
        public void CeilingTest(int realVal, int ceiling)
        {
            var tree = new RedBlackTree<int>(null);
            int[] data = new int[] { 5, 10, 15, 20, 25, 30, 35, 40};
            foreach(var val in data)
            {
                tree.Add(val);
            }
            Assert.AreEqual(tree.Ceiling(realVal), ceiling);
        }
        [TestMethod]
        [DataRow(7, 5)]
        [DataRow(21, 20)]
        [DataRow(34, 30)]
        [DataRow(10, 10)]
        public void FloorTest(int realVal, int floor) 
        {
            var tree = new RedBlackTree<int>(null);
            int[] data = new int[] { 5, 10, 15, 20, 25, 30, 35, 40 };
            foreach (var val in data)
            {
                tree.Add(val);
            }
            Assert.AreEqual(tree.Floor(realVal), floor);
        }

        [TestMethod]
        [DataRow(1826, 12321)]
        public void MaxTest(int size, int seed, int max = 100)
        {
            var tree = new RedBlackTree<int>(null);
            int[] data = new int[size];
            Random rand = new(seed);
            for (int i = 0; i < size; i++)
            {
                data[i] = rand.Next(max);
            }
            foreach (var item in data)
            {
                tree.Insert(item);
            }

            var node = tree.root;
            while(node.Right != null)
            {
                node = node.Right;
            }
            Assert.AreEqual(node.Value, tree.Max());
        }

        [TestMethod]
        [DataRow(1232, 888)]
        public void MinTest(int size, int seed, int max = 100)
        {
            var tree = new RedBlackTree<int>(null);
            int[] data = new int[size];
            Random rand = new(seed);
            for (int i = 0; i < size; i++)
            {
                data[i] = rand.Next(max);
            }
            foreach (var item in data)
            {
                tree.Insert(item);
            }

            var node = tree.root;
            while (node.Left != null)
            {
                node = node.Left;
            }
            Assert.AreEqual(node.Value, tree.Min());
        }
    }
}
