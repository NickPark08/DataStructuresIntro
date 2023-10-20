using DataStructuresIntro;

using Microsoft.VisualBasic;

using System.Net.Http.Headers;

namespace Tries
{

    [TestClass]
    public class TrieTest
    {
        Trie trie = new Trie();

        [TestMethod]
        public void AddTest()
        {
            Random randy = new Random();
            string[] strings = RandomizedStrings(17332, 13);
            string ranString = strings[randy.Next(0, strings.Length)];
            trie.Insert(ranString);
            Assert.IsTrue(trie.ContainsWord(ranString));
        }

        [TestMethod]
        public void ContainsTest()
        {
            Random randy = new Random();

            string[] strings = RandomizedStrings(927382, 13);
            string tester = strings[randy.Next(0, strings.Length)];
            tester = tester.ToLower();

            foreach (string str in strings)
            {
                trie.Insert(str);
            }
            TrieNode test = trie.Contains(tester);
            TrieNode Pointer = trie.Root;
            for(int i = 0; i < tester.Length; i++)
            {
                Pointer = Pointer.Children[tester[i]];
            }
            Assert.AreEqual(test, Pointer);
        }

        public string[] RandomizedStrings(int seed, int itemAmount)
        {
            Random randy = new Random(seed);
            string[] strings = new string[itemAmount];

            for(int i = 0; i < strings.Length; i++)
            {
                char[] ranString = new char[randy.Next(0, 20)];
                for(int j = 0; j < ranString.Length; j++)
                {
                    if (randy.Next(0, 2) == 1)
                    {
                        ranString[j] = (char)(randy.Next(97, 123));
                    }
                    else
                    {
                        ranString[j] = (char)(randy.Next(67, 91));
                    }
                }
                strings[i] = new string(ranString);
            }

            return strings;

        }

    }
}