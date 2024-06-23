// Reference page 191

Point point_1 = new Point(2, 3);
Point point_2 = new Point(-4, 0);

Console.WriteLine($"point_1 coordinates: [{point_1.X}, {point_1.Y}]");
Console.WriteLine($"point_2 coordinates: [{point_2.X}, {point_2.Y}]");
Console.WriteLine();

Color ColorRed = Color.ColorRed();
Color ColorGreen = Color.ColorGreen();
Color ColorBlue = Color.ColorBlue();

Console.WriteLine($"RGB Channels for ColorRed: [{ColorRed.R},{ColorRed.G},{ColorRed.B}]");
Console.WriteLine($"RGB Channels for ColorGreen: [{ColorGreen.R},{ColorGreen.G},{ColorGreen.B}]");
Console.WriteLine($"RGB Channels for ColorBlue: [{ColorBlue.R},{ColorBlue.G},{ColorBlue.B}]");
Console.WriteLine();

for (int r = 0; r < Enum.GetValues(typeof(CardRank)).Length; r++)
{
    for (int c = 0; c < Enum.GetValues(typeof(CardColors)).Length; c++)
    {
        Card card = new Card(r, c);
        string colorText = card.GetColorText();
        string rankText = card.GetRankText();

        Console.WriteLine();
        Console.WriteLine($"The {colorText} {rankText}");
    }
}
Console.WriteLine();

Door door = new Door(12345);

Console.WriteLine($"Door Locked: {door.IsLocked()}");
Console.WriteLine($"Door Closed: {door.IsClosed()}");

door.ChangePass(12345, 123);

door.UnlockDoor(123);
door.OpenDoor();

Console.WriteLine($"Door Locked: {door.IsLocked()}");
Console.WriteLine($"Door Closed: {door.IsClosed()}");

// Classes
class Point
{
    public int X {  get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Point()
    {
        X = 0;
        Y = 0;
    }
}
class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color ColorWhite()
    {
        return new Color(255, 255, 255);
    }
    public static Color ColorBlack()
    {
        return new Color(0, 0, 0);
    }
    public static Color ColorRed()
    {
        return new Color(255, 0, 0);
    }
    public static Color ColorOrange()
    {
        return new Color(255, 165, 0);
    }
    public static Color ColorYellow()
    {
        return new Color(255, 255, 0);
    }
    public static Color ColorGreen()
    {
        return new Color(0, 128, 0);
    }
    public static Color ColorBlue()
    {
        return new Color(0, 0, 255);
    }
    public static Color ColorPurple()
    {
        return new Color(125, 0, 128);
    }
}
class Card
{
    public int Rank { get; }
    public int Color { get; }

    public Card(int rank, int color)
    {
        Rank = rank;
        Color = color;
    }

    public bool IsSymbolCard()
    {
        CardRank[] ranks = { CardRank.Dollar, CardRank.Percent, CardRank.Caret, CardRank.Ampersand };

        return ranks.Contains((CardRank)Rank);
    }
    public bool IsNumberCard()
    {
        CardRank[] ranks = { CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten };

        return ranks.Contains((CardRank)Rank);
    }
    public string GetColorText()
    {
        return ((CardColors)Color).ToString();
    }
    public string GetRankText()
    {
        return ((CardRank)Rank).ToString();
    }
}
class Door
{
    private bool _closed = true;
    private bool _locked = true;
    private int _passcode;

    public Door(int? pass)
    {
        if (pass != null)
        {
            _passcode = pass.Value;
        }
    }
    public bool IsLocked()
    {
        return _locked;
    }
    public bool IsClosed()
    {
        return _closed;
    }
    public bool UnlockDoor(int pass)
    {
        if (!_locked) { return false; }
        if (pass != _passcode) { return false; }

        // unlock door
        _locked = false;

        return true;
    }
    public bool LockDoor(int pass)
    {
        if (_locked) { return false; }
        if (!_closed) { return false; }

        // lock door
        _locked = true;
        _passcode = pass;

        return true;
    }
    public bool OpenDoor()
    {
        if (_locked) { return false; }
        if (!_closed) { return false; }

        // open door
        _closed = false;

        return true;
    }
    public bool CloseDoor()
    {
        if (_locked) { return false; }
        if (_closed) { return false; }

        // close door
        _closed = true;

        return true;
    }
    public bool ChangePass(int pass, int newpass)
    {
        if (pass != _passcode) { return false; }

        // change passcode
        _passcode = newpass;

        return true;
    }
}

// Enums
enum CardColors
{
    Red,
    Green,
    Blue,
    Yellow,
}
enum CardRank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Caret,
    Ampersand
}