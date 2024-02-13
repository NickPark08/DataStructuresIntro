using DataStructures;

using DataStructuresIntro;

using System.Data;
using System.Reflection;

using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        string file = "test test hi zombie abcdefghijklmnopqrstuvwxyz a a a a a";
        FixedLengthEncoding encoding = new FixedLengthEncoding(file);

        encoding.FillTree();

        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}