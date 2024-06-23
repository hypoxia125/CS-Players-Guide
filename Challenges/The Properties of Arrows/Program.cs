// Reference page 168

Console.WriteLine("What kind of arrowheads would you like?");
Console.WriteLine("1. Steel - 10g");
Console.WriteLine("2. Wood - 3g");
Console.WriteLine("3. Obsidian - 5g");

int arrowheadInput = int.Parse(Console.ReadLine());
Arrow.Arrowheads arrowhead = arrowheadInput switch
{
    1 => Arrow.Arrowheads.Steel,
    2 => Arrow.Arrowheads.Wood,
    3 => Arrow.Arrowheads.Obsidian,

    _ => Arrow.Arrowheads.Wood
};

Console.WriteLine();

Console.WriteLine("What kind of fletching would you like?");
Console.WriteLine("1. Plastic - 10g");
Console.WriteLine("2. Turkey Feathers - 5g");
Console.WriteLine("3. Goose Feathers - 3g");

int fletchingInput = int.Parse(Console.ReadLine());
Arrow.Fletchings fletching = fletchingInput switch
{
    1 => Arrow.Fletchings.Plastic,
    2 => Arrow.Fletchings.TurkeyFeathers,
    3 => Arrow.Fletchings.GooseFeathers,

    _ => Arrow.Fletchings.TurkeyFeathers
};

Console.WriteLine();

Console.WriteLine("What kind of shaft length do you want?");
Console.WriteLine($"1. 60cm Shaft - {0.05f * 60}g");
Console.WriteLine($"2. 70cm Shaft - {0.05f * 70}g");
Console.WriteLine($"3. 80cm Shaft - {0.05f * 80}g");
Console.WriteLine($"4. 90cm Shaft - {0.05f * 90}g");
Console.WriteLine($"5. 100cm Shaft - {0.05f * 160}g");

int shaftlengthInput = int.Parse(Console.ReadLine());
Arrow.ShaftLengths shaftlength = shaftlengthInput switch
{
    1 => Arrow.ShaftLengths.length60,
    2 => Arrow.ShaftLengths.length70,
    3 => Arrow.ShaftLengths.length80,
    4 => Arrow.ShaftLengths.length90,
    5 => Arrow.ShaftLengths.length100,

    _ => Arrow.ShaftLengths.length60
};

Console.WriteLine();

Arrow arrow = new Arrow(arrowhead, fletching, shaftlength);
Console.WriteLine($"The total cost will be: {arrow.GetCost()}");

// Classes
class Arrow
{
    public Arrowheads Arrowhead { get; }
    public Fletchings Fletching { get; }
    public ShaftLengths ShaftLength { get; }

    public Arrow(Arrowheads arrowhead, Fletchings fletching, ShaftLengths shaftlength)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        ShaftLength = shaftlength;
    }

    public float GetCost()
    {
        float cost = 0.0f;

        switch (Arrowhead)
        {
            case Arrowheads.Steel:
                cost += 10;
                break;
            case Arrowheads.Wood:
                cost += 3;
                break;
            case Arrowheads.Obsidian:
                cost += 5;
                break;
        }

        switch (Fletching)
        {
            case Fletchings.Plastic:
                cost += 10;
                break;
            case Fletchings.TurkeyFeathers:
                cost += 5;
                break;
            case Fletchings.GooseFeathers:
                cost += 3;
                break;
        }

        float lengthcost = 0.05f * (float)ShaftLength;
        cost += lengthcost;

        return cost;
    }

    public enum Arrowheads
    {
        Steel,
        Wood,
        Obsidian
    }
    public enum Fletchings
    {
        Plastic,
        TurkeyFeathers,
        GooseFeathers
    }
    public enum ShaftLengths
    {
        length60 = 60,
        length70 = 70,
        length80 = 80,
        length90 = 90,
        length100 = 100
    }
}