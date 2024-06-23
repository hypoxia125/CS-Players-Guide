// Reference page 162

Console.WriteLine("What kind of arrowheads would you like?");
Console.WriteLine("1. Steel - 10g");
Console.WriteLine("2. Wood - 3g");
Console.WriteLine("3. Obsidian - 5g");

int arrowheadInput = int.Parse(Console.ReadLine());
Arrow.Arrowheads arrowheads = arrowheadInput switch
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
Arrow.Fletching fletching = fletchingInput switch
{
    1 => Arrow.Fletching.Plastic,
    2 => Arrow.Fletching.TurkeyFeathers,
    3 => Arrow.Fletching.GooseFeathers,

    _ => Arrow.Fletching.TurkeyFeathers
};

Console.WriteLine();

Console.WriteLine("What kind of shaft length do you want?");
Console.WriteLine($"1. 60cm Shaft - {0.05f * 60}g");
Console.WriteLine($"2. 70cm Shaft - {0.05f * 70}g");
Console.WriteLine($"3. 80cm Shaft - {0.05f * 80}g");
Console.WriteLine($"4. 90cm Shaft - {0.05f * 90}g");
Console.WriteLine($"5. 100cm Shaft - {0.05f * 160}g");

int shaftlengthInput = int.Parse(Console.ReadLine());
Arrow.ShaftLength shaftlength = shaftlengthInput switch
{
    1 => Arrow.ShaftLength.length60,
    2 => Arrow.ShaftLength.length70,
    3 => Arrow.ShaftLength.length80,
    4 => Arrow.ShaftLength.length90,
    5 => Arrow.ShaftLength.length100,

    _ => Arrow.ShaftLength.length60
};

Console.WriteLine();

Arrow arrow = new Arrow(arrowheads, fletching, shaftlength);
Console.WriteLine($"The total cost will be: {arrow.GetCost()}");

// Classes
class Arrow
{
    private Arrowheads _arrowhead;
    private Fletching _fletching;
    private ShaftLength _shaftlength;

    public Arrow(Arrowheads arrowhead, Fletching fletching, ShaftLength shaftLength)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _shaftlength = shaftLength;
    }
    public Arrowheads GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public ShaftLength GetShaftLength() => _shaftlength;
    public float GetCost()
    {
        float cost = 0.0f;

        switch (_arrowhead)
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

        switch (_fletching)
        {
            case Fletching.Plastic:
                cost += 10;
                break;
            case Fletching.TurkeyFeathers:
                cost += 5;
                break;
            case Fletching.GooseFeathers:
                cost += 3;
                break;
        }

        float lengthcost = 0.05f * (int)_shaftlength;
        cost += lengthcost;

        return cost;
    }

    public enum Arrowheads
    {
        Steel,
        Wood,
        Obsidian
    }
    public enum Fletching
    {
        Plastic,
        TurkeyFeathers,
        GooseFeathers
    }
    public enum ShaftLength
    {
        length60 = 60,
        length70 = 70,
        length80 = 80,
        length90 = 90,
        length100 = 100
    }
}