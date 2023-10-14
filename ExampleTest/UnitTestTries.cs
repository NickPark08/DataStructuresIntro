using DataStructuresIntro;

using System.Net.Http.Headers;

namespace Tries
{

    [TestClass]
    public class TrieTest
    {
        Trie trie = new Trie();

        [TestMethod]
        [DataRow()]
        public void AddTest(string input)
        {
            trie.Insert(input);


        }

        [TestMethod]
        [DataRow("a", "b")]
        public void ContainsTest(string tester, params string[] inputs)
        {
            foreach (string str in inputs)
            {
                trie.Insert(str);
            }
            TrieNode test = trie.Contains(tester);
            TrieNode Pointer = trie.Root;
            for(int i = 0; i < inputs.Length; i++)
            {
                Pointer = Pointer.Children[tester[i]];
            }
            Assert.AreEqual(test, Pointer);
        }

        [TestMethod]
        public void RandomizedContains(int seed, int itemAmount)
        {
            Random randy = new Random(seed);
            string[] strings = new string[itemAmount];

            //TODO: fill array


            ContainsTest(strings[randy.Next()],strings);
        }

    }
}

//namespace Math.Dividing
//{
//    [TestClass]
//    public class DivideTest
//    {
//        [TestMethod]
//        [DataRow(5, 2, 0)]
//        [DataRow(10, 2, 5)]
//        public void DivisionTest(int num1, int num2, int expected)
//        {
//            int num = num1 / num2;
//            Assert.IsTrue(num == expected);
//        }
//    }
//}