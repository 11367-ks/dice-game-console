// See https://aka.ms/new-console-template for more information
bool continue_input = false;
do
{
    string? input;
    int points = 0;
    ushort input_conv = 0;
    List<int> rolls = new List<int>();

    while (input_conv < 3 || input_conv > 10)
    {
        Console.WriteLine("Ile kostek chcesz rzucić? (3 - 10)");
        try
        {
            input = Console.ReadLine();
            input_conv = ushort.Parse(input);
        }
        catch
        {
            continue;
        }
    }
    for (int i = 0; i < input_conv; i++)
    {
        rolls.Add(new Random().Next() % 6 + 1);
        Console.WriteLine($"Kostka {i}: {rolls[i]}");
    }
    for (int i = 1; i <= 6; i++)
    {
        int duplicates = rolls.Count(x => x == i);
        if (duplicates > 1)
        {
            points += duplicates * i;
        }
    }
    Console.WriteLine($"Liczba uzyskanych punktów: {points}");
    Console.WriteLine("Jeszcze raz? (t/n)");
    switch (Console.ReadLine())
    {
        case "t":
            continue_input = true;
            break;
        default:
            continue_input = false;
            break;
    }
} while (continue_input);
