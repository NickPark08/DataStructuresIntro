using DataStructures;

using DataStructuresIntro;

using System.Data;
using System.Reflection;

using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.ComponentModel;
using DataStructures.BurstTrieImplementation;

class Program
{
    public static void Main()
    {
        BurstTrie trie = new BurstTrie(5, 'a', 'z');

        trie.Insert("test");
        trie.Insert("tes");
        trie.Insert("abc");
        trie.Insert("almond");
        trie.Insert("bee");
        trie.Insert("cee");
        trie.Insert("adam");
        trie.Insert("america");
        trie.Insert("awesome");
        trie.Insert("awe");
        trie.Insert("a");
        trie.Insert("zebra");


        var temp = trie.GetAll();

        foreach(var val in temp)
        {
            Console.WriteLine(val);
        }
        ;


        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}