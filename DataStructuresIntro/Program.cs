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
        var file = "Turtles, often revered for their ancient lineage and serene demeanor, hold a special place in the natural world. With a history spanning millions of years, these remarkable reptiles have evolved into a diverse array of species, each adapted to its unique habitat. From the massive leatherback turtles navigating vast oceans to the tiny speckled padloper traversing arid landscapes, turtles showcase the marvels of evolutionary adaptation.\r\n\r\nOne of the most fascinating aspects of turtles is their remarkable shell. Serving as both armor and home, the shell is a defining characteristic of these creatures. Composed of bone and keratin, it provides protection against predators while offering a secure retreat during times of danger. This unique feature has contributed to their survival through the ages, enabling them to thrive in a variety of environments.\r\n\r\nTurtles are also known for their longevity, with some species living for several decades or even centuries. This remarkable lifespan is a testament to their resilience and ability to withstand the challenges of their ecosystems. However, their slow reproductive rate and vulnerability to human activities, such as habitat destruction and poaching, pose significant threats to their survival.\r\n\r\nDespite these challenges, turtles continue to captivate the hearts and minds of people around the world. From their graceful movements in water to their determined trekking on land, they inspire awe and admiration in those fortunate enough to encounter them. Conservation efforts aimed at protecting their habitats and reducing human impacts are crucial for ensuring that these majestic creatures continue to grace our planet for generations to come.\r\n\r\nIn addition to their ecological importance, turtles also hold cultural significance in many societies. Revered as symbols of wisdom, longevity, and perseverance, they feature prominently in myths, folklore, and spiritual beliefs across diverse cultures. Their presence in art, literature, and traditions serves as a reminder of our interconnectedness with the natural world and the need to safeguard its treasures.\r\n\r\nIn conclusion, turtles are extraordinary creatures that embody the wonders of evolution and the resilience of life. Their iconic shells, longevity, and cultural significance make them a source of fascination and admiration for people worldwide. By recognizing the importance of preserving their habitats and respecting their existence, we can ensure that turtles continue to enrich our planet with their presence for countless years to come.";
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