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
        [DataRow("z")]
        [DataRow("a")]
        public void MatchingPrefixTest(string prefix)
        {
            Trie trie1 = new Trie();
            trie1.Insert("aa");
            trie1.Insert("aab");
            trie1.Insert("aabc");
            trie1.Insert("aabcd");
            trie1.Insert("zb");
            trie1.Insert("zloes");
            trie1.Insert("zleienesns");

            List<string> expected = new List<string>();
            expected.Add("aabcd");
            expected.Add("aabc");
            expected.Add("aab");
            expected.Add("aa");

            List<string> matched = new List<string>();
            matched = trie1.MatchingPrefix(prefix);

            for (int i = 0; i < matched.Count; i++)
            {
                if (matched[i] == expected[i])
                {
                    Assert.AreEqual(expected[i], matched[i]);
                }
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            Random randy = new Random();
            string[] strings = RandomizedStrings(17332, 13);
            string ranString = strings[randy.Next(0, strings.Length)];
            foreach (string str in strings)
            {
                trie.Insert(str);
            }
            trie.Remove(ranString);
            Assert.IsFalse(trie.ContainsWord(ranString));
        }

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
                char[] ranString = new char[randy.Next(1, 20)];
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