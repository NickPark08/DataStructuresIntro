using DataStructuresIntro;

using System.Data;

class Program
{
    public static void Idk<T, TObject>(T collection)
        where T : ICollection<TObject>
    {
        TObject newVal = default;

        collection.Add(newVal);
    }

    public static void Main()
    {

        LinkedList<int> ints= new LinkedList<int> { };

        Idk<LinkedList<int>, int>(ints);


    }
}