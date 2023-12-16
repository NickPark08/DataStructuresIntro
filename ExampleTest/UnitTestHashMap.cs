using DataStructures;

using Microsoft.VisualBasic;

using System.IO.MemoryMappedFiles;
using System.Net.Http.Headers;
using System.Windows.Markup;

namespace HashMap
{
    [TestClass]
    public class HashMapTest
    {
        HashMap<int, string> map = new HashMap<int, string>();
        Random randy = new Random();

        [TestMethod]
        public void IndexingTest()
        {
            string[] vals = RandomizedStrings(111, 10);
            for (int i = 0; i < vals.Length; i++)
            {
                map.Add(i, vals[i]);
            }
            for (int i = 0; i < vals.Length; i++)
            {
                Assert.AreEqual(vals[i], map[i]);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            string[] vals = RandomizedStrings(111, 10);
            for (int i = 0; i < vals.Length; i++)
            {
                map.Add(i, vals[i]);
            }
            int randIndex = randy.Next(0, vals.Length);
            int randIndex2 = randy.Next(0, vals.Length - 1);
            KeyValuePair<int, string> trueTestPair = new KeyValuePair<int, string>(randIndex, vals[randIndex]);
            KeyValuePair<int, string> falseTestPair = new KeyValuePair<int, string>(randIndex2, vals[randIndex2]);
            map.Remove(trueTestPair.Key);
            Assert.IsFalse(map.Contains(trueTestPair));
            Assert.IsTrue(map.Contains(falseTestPair));
        }

        [TestMethod]
        public void AddTest()
        {
            string[] vals = RandomizedStrings(111, 10);
            int ranKey = randy.Next(0, vals.Length);
            string ranValue = vals[randy.Next(0, vals.Length)];
            KeyValuePair<int, string> ranPair = new KeyValuePair<int, string>(ranKey, ranValue);
            map.Add(ranPair.Key, ranPair.Value);
            Assert.IsTrue(map.Contains(ranPair));
            Assert.IsTrue(map.ContainsKey(ranKey));
        }

        [TestMethod]
        public void ContainsTest()
        {
            string[] vals = RandomizedStrings(111, 10);
            for (int i = 0; i < vals.Length; i++)
            {
                map.Add(i, vals[i]);
            }
            int randIndex = randy.Next(0, vals.Length);
            int randIndex2 = randy.Next(0, vals.Length - 1);
            KeyValuePair<int, string> trueTestPair = new KeyValuePair<int, string>(randIndex, vals[randIndex]);
            KeyValuePair<int, string> falseTestPair = new KeyValuePair<int, string>(randIndex2, vals[randIndex2 + 1]);

            Assert.IsTrue(map.Contains(trueTestPair));
            Assert.IsFalse(map.Contains(falseTestPair));
        }

        public string[] RandomizedStrings(int seed, int itemAmount)
        {
            Random randy = new Random(seed);
            string[] strings = new string[itemAmount];

            for (int i = 0; i < strings.Length; i++)
            {
                char[] ranString = new char[randy.Next(1, 20)];
                for (int j = 0; j < ranString.Length; j++)
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
