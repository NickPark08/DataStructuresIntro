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
        var file = "The Allied invasion of Normandy in June 1944 was the culmination of decades of global political conflict, stemming from unresolved tensions following World War I. Nationalism played a significant role, fueling the rise of fascist states like Italy, Spain, and Germany. Germany's recovery from World War I was hindered by the Treaty of Versailles, stoking nationalist resentment among the German people. Economic struggles in the 1920s and the Great Depression of the 1930s facilitated the rise of National Socialism under Adolf Hitler, who capitalized on nationalist sentiment by blaming Germany's woes on external forces.\r\n\r\nThe effects of nationalism in the mid-twentieth century were devastating, resulting in immense loss of life and the transformation of warfare with frightening new weapons. The outbreak of World War II led to the remapping of political borders and ushered in the Cold War era, characterized by global tensions and the threat of nuclear destruction.\r\n\r\nPrior to World War II, militaristic nationalism drove European nations into a transoceanic imperial competition for colonial possessions. This imperialist nationalism, coupled with unresolved tensions, erupted into the catastrophic conflict of World War I. The war shattered European ideals, monarchies, and empires, giving rise to new powers like the Soviet Union and the United States.\r\n\r\nEconomic instability in the aftermath of World War I paved the way for World War II, where Western capitalist democracies allied with Asian communist regimes to combat Eurasian fascist regimes. The devastation of World War II underscored the failures of the old order, leading to vast destruction, genocide, and the emergence of new global powers.\r\n\r\nIn summary, the Allied invasion of Normandy was a pivotal moment in a complex historical narrative shaped by decades of nationalist fervor, unresolved conflicts, and the transformation of global power dynamics.";
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