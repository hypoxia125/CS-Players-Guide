// Reference page 135

// Program
ChestState state = ChestState.Locked;

while (true)
{
    Console.WriteLine();

    Console.WriteLine($"The chest state is currently: {state}");
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1. Open");
    Console.WriteLine("2. Close");
    Console.WriteLine("3. Unlock");
    Console.WriteLine("4. Lock");
    int input = int.Parse(Console.ReadLine());
    input--;

    Console.WriteLine($"You have selected the action: {(Actions)input}");

    Actions action = (Actions)input;
    ChangeChestState(action);
}

// Functions
void FailedMsg(string text)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.White;
}
void ChangeChestState(Actions action)
{
    switch (action)
    {
        case Actions.Open:
            if (state == ChestState.Open)
            {
                FailedMsg("Chest is already open.");
            }
            if (state == ChestState.Locked)
            {
                FailedMsg("Unable to open. Chest is locked.");
            }
            if (state == ChestState.Closed)
            {
                state = ChestState.Open;
                break;
            }
            break;

        case Actions.Close:
            if (state == ChestState.Open)
            {
                state = ChestState.Closed;
                break;
            }
            if (state == ChestState.Locked)
            {
                FailedMsg("Chest is already locked therefore, closed");
            }
            if (state == ChestState.Closed)
            {
                FailedMsg("Chest is already closed.");
            }
            break;

        case Actions.Unlock:
            if (state == ChestState.Open)
            {
                FailedMsg("Chest is already open therefore, unlocked");
            }
            if (state == ChestState.Locked)
            {
                state = ChestState.Closed;
                break;
            }
            if (state == ChestState.Closed)
            {
                FailedMsg("Chest is already unlocked.");
            }
            break;

        case Actions.Lock:
            if (state == ChestState.Open)
            {
                FailedMsg("Chest is open. Close the chest first.");
            }
            if (state == ChestState.Locked)
            {
                FailedMsg("Chest is already locked.");
            }
            if (state == ChestState.Closed)
            {
                state = ChestState.Locked;
                break;
            }
            break;
    }
}

// Enums
enum Actions
{
    Open,
    Close,
    Unlock,
    Lock
}
enum ChestState
{
    Open,
    Closed,
    Locked
}