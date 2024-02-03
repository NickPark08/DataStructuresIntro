using DataStructures;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class LRUCacheTest
    {

        public LRUCache<int, string> cache = new LRUCache<int, string>();
        Random randy = new Random();

        [TestMethod]
        public void TryGetValueTest()
        {
            string[] strings = RandomizedStrings(111, 15);

            for (int i = 0; i < strings.Length; i++)
            {
                cache.Put(i, strings[i]);
            }

            string val = "";
            int ranIndex = randy.Next(0, strings.Length);
            bool test = cache.TryGetValue(ranIndex, out val);
            Assert.IsTrue(test && val == strings[ranIndex]);

        }

        [TestMethod]
        public void PutTest()
        {
            string[] strings = RandomizedStrings(2723, 15);
            for (int i = 0; i < strings.Length; i++)
            {
                cache.Put(i, strings[i]);
            }

            for (int i = 0; i < cache.map.Count; i++)
            {
                Assert.IsTrue(cache.map.ContainsKey(i) && cache.map[i] == strings[i]);
            }
        }

        public string[] RandomizedStrings(int seed, int itemAmount)
        {
            //Random randy = new Random(seed);
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
