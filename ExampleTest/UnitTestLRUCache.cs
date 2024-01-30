using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class LRUCacheTest : ICache<int, string>
    {
        public LinkedList<int> list { get; set; }
        public Dictionary<int, string> map { get; set; }

        [TestMethod]
        public void TryGetValueTest()
        {
            
        }

        [TestMethod]
        public void PutTest()
        {

        }
    }
}
