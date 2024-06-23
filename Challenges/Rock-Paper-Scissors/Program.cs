// Reference page 193-194

// Program
Player player1 = new Player("Player1");
Player player2 = new Player("Player2");

while (true)
{
    Console.WriteLine("Rock, Paper, Scissors");
    Console.WriteLine();

    Console.Write("Player 1: ");
    string? input = Console.ReadLine();
    if (input == null) { continue; };
    bool successful = Game.HandlePlayerInput(player1, input);
    if (!successful) { continue; };

    Console.Write("Player 2: ");
    input = Console.ReadLine();
    if (input == null) { continue; };
    successful = Game.HandlePlayerInput(player2, input);
    if (!successful) { continue; };

    Player winner = Game.GetWinner(player1, player2);
    Console.WriteLine($"{winner.GetPlayerName()} is the winner!");
    winner.AddVictory();

    Console.WriteLine();
    Console.WriteLine("The score is as follows:");
    Console.WriteLine($"{player1.GetPlayerName()} has {player1.GetVictories()} victories!");
    Console.WriteLine($"{player2.GetPlayerName()} has {player2.GetVictories()} victories!");
    Console.WriteLine();
}
// Classes
class Game
{
    public static Player GetWinner(Player player1, Player player2)
    {
        Selections p1 = player1.GetPlayerSelection();
        Selections p2 = player2.GetPlayerSelection();

        Player winner = player1;

        switch (p1)
        {
            case Selections.Rock:
                if (p2 == Selections.Paper) winner = player2;
                break;
            case Selections.Scissors:
                if (p2 == Selections.Rock) winner = player2;
                break;
            case Selections.Paper:
                if (p2 == Selections.Scissors) winner = player2;
                break;
        }

        return winner;
    }
    public static Selections? GetSelectionFromString(string input)
    {
        if (Enum.TryParse(input, true, out Selections selection))
        {
            return selection;
        }
        return null;
    }
    public static bool HandlePlayerInput(Player player, string? input)
    {
        Selections? selection = GetSelectionFromString(input);

        if (selection.HasValue)
        {
            player.SetPlayerSelection(selection.Value);
            return true;
        }
        return false;
    }
}
class Player
{
    private readonly string _name;
    private int _victories;
    private int _losses;

    private Selections _roundSelection;

    public Player(string name)
    {
        _name = name;
        _victories = 0;
        _losses = 0;
    }

    public void AddVictory()
    {
        _victories++;
    }
    public int GetVictories()
    {
        return _victories;
    }
    public void AddLoss()
    {
        _losses++;
    }
    public void SetPlayerSelection(Selections selection)
    {
        _roundSelection = selection;
    }
    public Selections GetPlayerSelection()
    {
        return _roundSelection;
    }
    public string GetPlayerName()
    {
        return _name;
    }
}

enum Selections
{
    Rock,
    Paper,
    Scissors
}