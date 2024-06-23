// Reference page 173

Console.WriteLine("What kind of arrow do you want to create?");
Console.WriteLine("1. Beginner Arrow");
Console.WriteLine("2. Marksman Arrow");
Console.WriteLine("3. Elite Arrow");
Console.WriteLine("4. Custom Arrow");
int input = int.Parse(Console.ReadLine());

Arrow arrow;
switch (input)
{
    case 1:
        arrow = Arrow.CreateBeginnerArrow();
        break;
    case 2:
        arrow = Arrow.CreateMarksmanArrow();
        break;
    case 3:
        arrow = Arrow.CreateEliteArrow();
        break;
    case 4:
        arrow = CreateCustomArrow();
        break;
    default:
        arrow = CreateCustomArrow();
        break;
}

float cost = arrow.GetCost();
Console.WriteLine($"The cost of the arrow will be {cost} gold.");

// Methods
Arrow CreateCustomArrow()
{
    Arrow.Arrowheads arrowhead;
    Arrow.Fletchings fletching;
    int shaftlength;

    while (true)
    {
        Console.WriteLine();

        Console.WriteLine("What kind of fletching would you like?");
        Console.WriteLine("1. Plastic - 10g");
        Console.WriteLine("2. Turkey Feathers - 5g");
        Console.WriteLine("3. Goose Feathers - 3g");

        int arrowheadInput = int.Parse(Console.ReadLine());
        switch (arrowheadInput)
        {
            case 1:
                arrowhead = Arrow.Arrowheads.Steel;
                break;
            case 2:
                arrowhead = Arrow.Arrowheads.Wood;
                break;
            case 3:
                arrowhead = Arrow.Arrowheads.Obsidian;
                break;
            default:
                continue;
        }
        break;
    }

    while (true)
    {
        Console.WriteLine();

        Console.WriteLine("What kind of fletching would you like?");
        Console.WriteLine("1. Plastic - 10g");
        Console.WriteLine("2. Turkey Feathers - 5g");
        Console.WriteLine("3. Goose Feathers - 3g");

        int fletchingInput = int.Parse(Console.ReadLine());
        switch (fletchingInput)
        {
            case 1:
                fletching = Arrow.Fletchings.Plastic;
                break;
            case 2:
                fletching = Arrow.Fletchings.TurkeyFeathers;
                break;
            case 3:
                fletching = Arrow.Fletchings.GooseFeathers;
                break;
            default:
                continue;
        }
        break;
    }

    while (true)
    {
        Console.WriteLine();

        Console.WriteLine("What kind of shaft length do you want?");
        Console.Write("Shaft length in cm: ");

        shaftlength = int.Parse(Console.ReadLine());
        if (shaftlength < 1 || shaftlength > 100) { continue; } else { break; }
    }

    Console.WriteLine();

    Arrow arrow = new Arrow(arrowhead, fletching, shaftlength);
    return arrow;
}

// Classes
class Arrow
{
    public Arrowheads Arrowhead { get; }
    public Fletchings Fletching { get; }
    public int ShaftLength { get; }

    public Arrow(Arrowheads arrowhead, Fletchings fletching, int shaftlength)
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

        float lengthcost = 0.05f * ShaftLength;
        cost += lengthcost;

        return cost;
    }
    public static Arrow CreateEliteArrow()
    {
        Arrow arrow = new Arrow(Arrowheads.Steel, Fletchings.Plastic, 95);
        return arrow;
    }
    public static Arrow CreateBeginnerArrow()
    {
        Arrow arrow = new Arrow(Arrowheads.Wood, Fletchings.GooseFeathers, 75);
        return arrow;
    }
    public static Arrow CreateMarksmanArrow()
    {
        Arrow arrow = new Arrow(Arrowheads.Steel, Fletchings.GooseFeathers, 65);
        return arrow;
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
}