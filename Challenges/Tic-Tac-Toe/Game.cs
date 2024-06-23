public class Game
{
	private char[,] _board;
	public Player?[] players { get; set; } = { null, null };

	public Game()
	{
		_board = new char[3, 3];
		InitializeBoard();
	}

	public void ShowDescription()
	{
		Console.WriteLine("Welcome to Tic-Tac-Toe!");
		Console.WriteLine("Each player will take turns selecting a square and placing their token");
		Console.WriteLine("Get three of your token in a row, column, or diagonal to win!");
		Console.WriteLine();

		Console.WriteLine("Player 1 will be: 'X'");
		Console.WriteLine("Player 2 will be: 'O'");
	}
	public void InitializeBoard()
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				_board[i, j] = ' ';
			}
		}
	}
	public char[,] GetBoard()
	{
		return _board;
	}
	public void DrawBoard()
	{
		Console.WriteLine("----+---+----");
		Console.WriteLine($"| {_board[0, 0]} | {_board[0, 1]} | {_board[0, 2]} |");
        Console.WriteLine("----+---+----");
        Console.WriteLine($"| {_board[1, 0]} | {_board[1, 1]} | {_board[1, 2]} |");
        Console.WriteLine("----+---+----");
        Console.WriteLine($"| {_board[2, 0]} | {_board[2, 1]} | {_board[2, 2]} |");
        Console.WriteLine("----+---+----");
    }
	public bool UpdateBoard(int[] tile, char value)
	{
		int i = tile[0];
		int j = tile[1];

		char[] accepted = { 'X', 'O', ' ' };
		if (!accepted.Contains(value))
		{
			return false;
		}

		if (_board[i, j] != ' ')
		{
			Error("You cannot choose an already filled tile.");
			WaitForEnter();
			return false;
		}

		_board[i, j] = value;
		DrawBoard();
		return true;
	}
	public void WaitForEnter()
	{
		while (true)
		{
            Console.WriteLine("Press ENTER to continue...");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter) { break; }
        }
	}
	public int GetPlayerInput(string text)
	{
		while (true)
		{
            Console.Write(text);

            int input = int.Parse(Console.ReadLine());
            input--;

            int[] accepted = { 0, 1, 2 };
            if (!accepted.Contains(input))
			{
				Error("You have selected an invalid input. Try again.");
				continue;
			}

			return input;
        }
	}
	public bool CheckIfDraw()
	{
        int countEmpty = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board[i, j] == ' ') { countEmpty++; }
            }
        }

		if (countEmpty == 0) { return true; }
		return false;
    }
	public Player? CheckIfVictory(Player p1, Player p2)
	{
		int countX, countO;

		// check rows
		for (int i = 0; i < 3; i++)
		{
			countX = 0;
			countO = 0;

			for (int j = 0; j < 3; j++)
			{
				if (_board[i, j] == 'X') { countX++; };
				if (_board[i, j] == 'O') { countO++; };
			}

			if (countX == 3) { return p1; };
			if (countO == 3) { return p2; };
		}

		// check columns
		for (int j = 0; j < 3; j++)
		{
			countX = 0;
			countO = 0;

            for (int i = 0; i < 3; i++)
            {
                if (_board[i, j] == 'X') { countX++; };
                if (_board[i, j] == 'O') { countO++; };
            }

            if (countX == 3) { return p1; };
            if (countO == 3) { return p2; };
        }

		// check diagonals
		if (CheckDiagonal(p1)) { return p1; }
        if (CheckDiagonal(p2)) { return p2; }

		// no winner
		return null;
    }
	public bool CheckDiagonal(Player player)
	{
		int countX, countO;

        // check forward diag
        countX = 0;
        countO = 0;
        for (int i = 0; i < 3; i++)
		{
			int row = i;
			int column = i;

			if (_board[row, column] == 'X') { countX++; }
			if (_board[row, column] == 'O') { countO++; }
		}
		if (countX == 3 || countO == 3) { return true; }

		// check backward diag
		countX = 0;
		countO = 0;
        for (int i = 0; i < 3; i++)
        {
            int row = i;
            int column = 2 - i;

            if (_board[row, column] == 'X') { countX++; }
            if (_board[row, column] == 'O') { countO++; }
        }
        if (countX == 3 || countO == 3) { return true; }

        return false;
	}
	public void EndGame(Player? winner)
	{
		Console.Clear();
		this.DrawBoard();
		Console.WriteLine();

		if (winner == null)
		{
			Console.WriteLine("Its a draw!");
			return;
		}

		Console.WriteLine($"{winner.GetName()} is victorious!");
	}
	public void Error(string text)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(text);
		Console.ForegroundColor = ConsoleColor.White;
	}

}
