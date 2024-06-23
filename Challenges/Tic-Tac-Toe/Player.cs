public class Player
{
	private char _token;
	private string _name;

	public Player(char token)
	{
		char[] accepted = { 'X', 'O', ' ' };
		if (!accepted.Contains(token))
		{
			throw new ArgumentException($"{token} is not an accepted token. Must be one of: 'X', 'O', ' '");
		}
		_token = token;
	}

	public char GetToken()
	{
		return _token;
	}
	public void SetName(string name)
	{
		_name = name;
	}
	public string GetName()
	{
		return _name;
	}
}
