using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BurstTrieImplementation
{
    public class BurstSort
    {
        public void Sort(string[] array)
        {
            char max = array.Max(x => x.Max());
            char min = array.Min(x => x.Min());
            BurstTrie trie = new BurstTrie(5, min, max);
            foreach(var item in array)
            {
                
            }
        }
    }
}
