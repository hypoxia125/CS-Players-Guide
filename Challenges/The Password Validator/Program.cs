// Reference page 192

while (true)
{
    Console.Write("Please set a password: ");
    string? pass = Console.ReadLine();

    bool valid = PasswordValidator.IsValidPassword(pass);
    
    if (valid)
    {
        Console.WriteLine("Password saved.");
        break;
    }

    Console.WriteLine();
}
// Classes
class PasswordValidator
{
    public static bool IsValidPassword(string? pass)
    {
        if (pass == null) {  return false; }

        int countUpper = 0;
        int countLower = 0;
        int countNum = 0;
        int countInvalid = 0;
        foreach (char c in pass)
        {
            if (char.IsDigit(c)) { countNum++; }
            if (char.IsUpper(c)) { countUpper++; }
            if (char.IsLower(c)) { countLower++; }
            if (c == 'T' || c == '&') { countInvalid++; }
        }

        Console.WriteLine();
        if (pass.Length < 6 || pass.Length > 13)
        {
            Console.WriteLine();
            Console.WriteLine("Password needs to be between 6 and 13 characters long.");
        }
        if (countUpper == 0)
        {
            Console.WriteLine("Password needs at least 1 uppercase letter.");
        }

        if (countLower == 0)
        {
            Console.WriteLine("Password needs at least 1 lowercase letter.");
        }

        if (countNum == 0)
        {
            Console.WriteLine("Password needs at least 1 number.");
        }

        if (countInvalid > 0)
        {
            Console.WriteLine("Password cannot contain a T or a &");
        }

        if (pass.Length < 6 || pass.Length > 13 || countUpper == 0 || countLower == 0 || countNum == 0 || countInvalid > 0) { return false; }

        return true;
    }
}