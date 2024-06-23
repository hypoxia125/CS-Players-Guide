// Reference page 143

// Program
Console.WriteLine("Let's make a soup!");
Console.WriteLine();
Console.WriteLine("--- Choose a food type ---");
Console.WriteLine($"1. {(FoodTypes)0}");
Console.WriteLine($"2. {(FoodTypes)1}");
Console.WriteLine($"3. {(FoodTypes)2}");
Console.WriteLine();
Console.Write("Type: ");
int type = int.Parse(Console.ReadLine());

Console.WriteLine();

Console.WriteLine("--- Choose a main ingredient ---");
Console.WriteLine($"1. {(MainIngredients)0}");
Console.WriteLine($"2. {(MainIngredients)1}");
Console.WriteLine($"3. {(MainIngredients)2}");
Console.WriteLine($"4. {(MainIngredients)3}");
Console.WriteLine();
Console.Write("Ingredient: ");
int ingredient = int.Parse(Console.ReadLine());

Console.WriteLine();

Console.WriteLine("--- Choose a seasoning ---");
Console.WriteLine($"1. {(Seasoning)0}");
Console.WriteLine($"2. {(Seasoning)1}");
Console.WriteLine($"3. {(Seasoning)2}");
Console.WriteLine();
Console.Write("Seasoning: ");
int seasoning = int.Parse(Console.ReadLine());

(int, int, int) soup = (type, ingredient, seasoning);

Console.WriteLine();

Console.WriteLine($"{(Seasoning)soup.Item3} {(MainIngredients)soup.Item2} {(FoodTypes)soup.Item1}");

// Enums
enum FoodTypes
{
    soup,
    stew,
    gumbo
}
enum MainIngredients
{
    mushrooms,
    chicken,
    carrots,
    potatoes
}
enum Seasoning
{
    spicy,
    salty,
    sweet
}