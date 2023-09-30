using DataStructuresIntro;

using System.Data;
using System.Reflection;

class Program
{
    public static void Main()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Insert("heyo");
        trie.Insert("jazz");

        TrieNode Pointer = trie.Root;
        ;
    }
}