// Reference page 195

/*
    [X] Two human players
    [X] Players designate what square they want to play in
    [X] Prevent players from choosing occupied squares - tell player if they attempt
    [X] Detect when game ends (win or draw)
    [X] Game over, display outcome
    [X] State of board must be displayed after every play
*/
/*
    Board Visualization

    ----+---+----
    | - | - | - |
    ----+---+----
    | - | - | - |
    ----+---+----
    | - | - | - |
    ----+---+----
*/

Console.Title = "Tic-Tac-Toe";

Game game = new Game();

Player player1 = new Player('X');
player1.SetName("Player 1");
game.players[0] = player1;

Player player2 = new Player('O');
player2.SetName("Player 2");
game.players[1] = player2;

game.ShowDescription();
Console.WriteLine();
game.WaitForEnter();

while (true)
{
    int x, y;
    Player? winner;
    bool draw;

    while (true)
    {
        Console.Clear();
        game.DrawBoard();
        Console.WriteLine();

        Console.WriteLine("Player 1 - Take your turn.");
        x = game.GetPlayerInput("Select a row (1, 2, 3): ");
        y = game.GetPlayerInput("Select a column (1, 2, 3): ");

        if (game.UpdateBoard(new int[] { x, y }, player1.GetToken())) { break; }
    }

    draw = game.CheckIfDraw();
    if (draw)
    {
        game.EndGame(null);
        break;
    }
    winner = game.CheckIfVictory(player1, player2);
    if (winner != null)
    {
        game.EndGame(winner);
        break;
    }

    while (true)
    {
        Console.Clear();
        game.DrawBoard();
        Console.WriteLine();

        Console.WriteLine("Player 2 - Take your turn.");
        x = game.GetPlayerInput("Select a row (1, 2, 3): ");
        y = game.GetPlayerInput("Select a column (1, 2, 3): ");

        if (game.UpdateBoard(new int[] { x, y }, player2.GetToken())) { break; }
    }

    draw = game.CheckIfDraw();
    if (draw)
    {
        game.EndGame(null);
        break;
    }
    winner = game.CheckIfVictory(player1, player2);
    if (winner != null)
    {
        game.EndGame(winner);
        break;
    }
}
