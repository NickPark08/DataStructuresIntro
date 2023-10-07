using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresIntro
{
    class TrieNode
    {
        public char Letter { get; private set; }
        public Dictionary<char, TrieNode> Children { get; private set; }
        public TrieNode Parent;
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
            word = word.ToLower();
            for (int i = 0; i < word.Length; i++)
            {
                if (!Pointer.Children.ContainsKey(word[i]))
                {
                    Pointer.Children.Add(word[i], new TrieNode(word[i]));
                    Pointer.Children[word[i]].Parent = Pointer;
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
            TrieNode FirstLetter = Root;

            for (int i = 0; i < word.Length; i++)
            {
                if (Pointer.Children.ContainsKey(word[i]))
                {
                    if (Pointer.IsWord)
                    {
                        FirstLetter = Pointer;
                    }
                    else if (Pointer.Children.Count > 1)
                    {
                        FirstLetter = Pointer;
                    }

                    Pointer = Pointer.Children[word[i]];
                }
            }
            if (Pointer.IsWord)
            {
                Pointer.IsWord = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (FirstLetter.Children.ContainsKey(word[i]))
                    {
                        FirstLetter.Children.Remove(word[i]);
                        return true;
                    }
                }
            }

            return false;
        }

        public TrieNode Search(string prefix)
        {
            TrieNode Pointer = Root;

            if (!Pointer.Children.ContainsKey(prefix[0])) throw new ArgumentException("String not found in Trie");

            for (int i = 0; i < prefix.Length; i++)
            {
                if (Pointer.Children.ContainsKey(prefix[i]))
                {
                    Pointer = Pointer.Children[prefix[i]];
                }
            }
            return Pointer;
        }

        public List<string> MatchingPrefix(string prefix)
        {
            TrieNode Pointer = Root;
            List<string> matched = new List<string>();
            string word = "";
            if (!Pointer.Children.ContainsKey(prefix[0])) throw new ArgumentException("Prefix not found in Trie");

            for (int i = 0; i < prefix.Length; i++)
            {
                if (Pointer.Children.ContainsKey(prefix[i]))
                {
                    Pointer = Pointer.Children[prefix[i]];
                    word += prefix[i];
                }
                if (Pointer.IsWord)
                {
                    matched.Add(word);
                }
            }
            string pre = word;
            char finalLetter = 'a';
            while (Pointer != Root)
            {
                for (char letter = finalLetter; letter <= 'z'; letter++)
                {
                    if (Pointer.Children.ContainsKey(letter))
                    {
                        Pointer = Pointer.Children[letter];
                        word += letter;
                        if (Pointer.IsWord)
                        {
                            matched.Add(word);
                        }
                        if (Pointer.Parent.Children.Count > 1)
                        {
                            finalLetter = letter;
                        }
                        letter = 'a';
                    }
                }
                while(Pointer.Children.Count < 1)
                {
                    Pointer = Pointer.Parent;
                }
                word = pre;
            }



            return matched;
        }
    }
}
