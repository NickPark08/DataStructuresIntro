using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class TrieNode
    {
        public char Letter { get; private set; }
        public Dictionary<char, TrieNode> Children { get; private set; }
        public bool IsWord { get; set; }

        public TrieNode(char c)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = c;
            IsWord = false;
        }
    }

    class Trie
    {
        public TrieNode Root = new TrieNode('$');
        public void Insert(string word)
        {
            TrieNode Pointer = Root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!Pointer.Children.ContainsKey(word[i]))
                {
                    Pointer.Children.Add(word[i], new TrieNode(word[i]));
                }
                Pointer = Pointer.Children[word[i]];
            }
            Pointer.IsWord = true;
        }
        public bool Remove(string word)
        {
            TrieNode Pointer = Root;

            if (!Pointer.Children.ContainsKey(word[0]))
            {
                return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (Pointer.Children.ContainsKey(word[i]))
                {
                    Pointer = Pointer.Children[word[i]];
                }
            }
            if ()
            return true;
        }
    }
}
