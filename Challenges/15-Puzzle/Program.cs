// Reference page 194

// Classes
class Game
{

    // Methods
    public static void CheckForWin() { }
    public void CreateGameBoard() { }
    public void UpdateGameBoard() { }
    public void SwapTilePostitions() { }
}

class Tile
{
    private int[] _position = { 0, 0 };
    private int _value = 0;

    public Tile(int value, int[] position)
    {
        _value = value;
        _position = position;
    }

    // Methods
    public string GetDisplayName() { }
    public void ChangeTilePosition() { }
}