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
        //string file = File.ReadAllText("\\\\GMRDC1\\Folder Redirection\\Nicholas.park\\Documents\\Visual Studio 2022\\Projects\\DataStructuresIntro\\DataStructuresIntro\\huffmaninput.txt");
        var file = "test tttsjs";
        FixedLengthEncoding encoding = new FixedLengthEncoding(file);

        encoding.FillTree();
        encoding.CompressFile(file);

        string compressedFile = File.ReadAllText("output.txt");
        Console.WriteLine(encoding.DecompressFile());


        ;
        //string unionFindVertices = File.ReadAllText(@"..\..\..\UnionFindVertices.txt");
        //string unionFindEdges = File.ReadAllText(@"..\..\..\UnionFindEdges.txt");

        //var arr = JsonSerializer.Deserialize<string[]>(unionFindVertices);
        //var arr2 = JsonSerializer.Deserialize<UnionFindEdge[]>(unionFindEdges);

    }
}