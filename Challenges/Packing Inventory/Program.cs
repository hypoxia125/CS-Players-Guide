// Reference page 205

using System.Buffers;

Pack backpack = new Pack(5, 10, 100);

while (true)
{
    Console.WriteLine("Add an item to the backpack");
    Console.WriteLine("1. Arrow");
    Console.WriteLine("2. Bow");
    Console.WriteLine("3. Food");
    Console.WriteLine("4. Rope");
    Console.WriteLine("5. Sword");
    Console.WriteLine("6. Water");
    int input = GetUserInput();
    if (input == -1) { continue; }

    bool valid = false;
    string itemname = "";
    switch (input)
    {
        case 1:
            Arrow arrow = new Arrow();
            itemname = "Arrow";
            valid = backpack.AddInventoryItem(arrow);
            break;
        case 2:
            Bow bow = new Bow();
            itemname = "Bow";
            valid = backpack.AddInventoryItem(bow);
            break;
        case 3:
            Food food = new Food();
            itemname = "Food";
            valid = backpack.AddInventoryItem(food);
            break;
        case 4:
            Rope rope = new Rope();
            itemname = "Rope";
            valid = backpack.AddInventoryItem(rope);
            break;
        case 5:
            Sword sword = new Sword();
            itemname = "Sword";
            valid = backpack.AddInventoryItem(sword);
            break;
        case 6:
            Water water = new Water();
            itemname = "Water";
            valid = backpack.AddInventoryItem(water);
            break;
    }

    if (valid)
    {
        Console.WriteLine($"Successfully added: {itemname} to the pack.");
        Console.WriteLine($"There are {backpack.TotalItems} in your pack.");
        Console.WriteLine($"You have [{backpack.MassMax - backpack.InventoryMass} mass and {backpack.VolumeMax - backpack.InventoryVolume} volume] left in your pack.");
    }
    else
    {
        Console.Write($"Unable to add: {itemname} to the pack.");
    }
}

// Methods
int GetUserInput()
{
    while (true)
    {
        Console.Write("Please enter a valid integer for your selection: ");
        string? userInput = Console.ReadLine();
        if (userInput == null) { return -1; }

        if (int.TryParse(userInput, out int result))
        {
            return result;
        }

        return -1;
    }
}
