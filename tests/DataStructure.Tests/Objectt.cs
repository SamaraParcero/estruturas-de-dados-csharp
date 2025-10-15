namespace DataStructure.Tests;

public class Objectt : IComparable<Objectt>
{

    public string Name { get; set; } = default!;

    public Objectt(string name)
    {
        Name = name;
    }
    
    public int CompareTo(Objectt? objectt)
    {
        if (objectt == null) return 1;


        return Name.CompareTo(objectt.Name);
    }


}