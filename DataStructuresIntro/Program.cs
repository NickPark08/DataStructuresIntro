using DataStructuresIntro;

using System.Data;
using System.Reflection;

class Program
{
    public static void Main()
    {
        List<string> strings= new List<string>();

        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Insert("heyo");
        trie.Insert("jazz");
        trie.Insert("heaven");
        trie.Insert("hi");
        trie.Insert("hj");
        trie.Insert("ho");
        trie.Insert("hp");

        strings = trie.MatchingPrefix("h");

        for(int i = 0; i < strings.Count; i++)
        {
            Console.WriteLine(strings[i]);
        }
        ;
    }
}