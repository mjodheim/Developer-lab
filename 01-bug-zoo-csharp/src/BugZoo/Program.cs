using System.Globalization;
using BugZoo;

ZooService zoo = new(
[
    new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
    new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1),
    new Animal(3, "Momo", "Red panda", 4, 1.25m, 7),
    new Animal(4, "Ada", "Elephant", 19, 48.5m, 2)
]);

bool isRunning = true;
while (isRunning)
{
    PrintMenu();
    Console.Write("Choice: ");
    string? choice = Console.ReadLine();
    Console.WriteLine();

    try
    {
        switch (choice)
        {
            case "1": ListAnimals(zoo); break;
            case "2": FindAnimal(zoo); break;
            case "3": SearchBySpecies(zoo); break;
            case "4": AddAnimal(zoo); break;
            case "5": MoveAnimal(zoo); break;
            case "6": Console.WriteLine($"Total daily food: {zoo.CalculateTotalDailyFood():0.00} kg"); break;
            case "7":
                foreach (string line in zoo.GenerateFeedingReport()) Console.WriteLine(line);
                break;
            case "0": isRunning = false; break;
            default: Console.WriteLine("Unknown choice."); break;
        }
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Operation failed: {exception.Message}");
    }

    Console.WriteLine();
}

static void PrintMenu()
{
    Console.WriteLine("=== BUG ZOO ===");
    Console.WriteLine("1. List animals");
    Console.WriteLine("2. Find an animal by identifier");
    Console.WriteLine("3. Search by species");
    Console.WriteLine("4. Add an animal");
    Console.WriteLine("5. Move an animal");
    Console.WriteLine("6. Calculate total daily food");
    Console.WriteLine("7. Generate feeding report");
    Console.WriteLine("0. Exit");
}

static void ListAnimals(ZooService zoo)
{
    IReadOnlyList<Animal> animals = zoo.GetAllAnimals();
    // Attendu 4 animaux, affiché 3 → l'erreur vient de "index < animals.Count -1"
    // for (int index = 0; index < animals.Count - 1; index++) PrintAnimal(animals[index]);
    for (int index = 0; index < animals.Count; index++) PrintAnimal(animals[index]);
}

static void FindAnimal(ZooService zoo)
{
    Console.Write("Identifier: ");
    int id = int.Parse(Console.ReadLine()!);
    PrintAnimal(zoo.FindById(id));
}

static void SearchBySpecies(ZooService zoo)
{
    Console.Write("Species: ");
    string species = Console.ReadLine()!;
    foreach (Animal animal in zoo.SearchBySpecies(species)) PrintAnimal(animal);
}

static void AddAnimal(ZooService zoo)
{
    Console.Write("Identifier: ");
    int id = int.Parse(Console.ReadLine()!);
    Console.Write("Name: ");
    string name = Console.ReadLine()!;
    Console.Write("Species: ");
    string species = Console.ReadLine()!;
    Console.Write("Age: ");
    int age = int.Parse(Console.ReadLine()!);
    Console.Write("Daily food in kg: ");
    decimal dailyFood = decimal.Parse(Console.ReadLine()!, CultureInfo.CurrentCulture);
    Console.Write("Enclosure number: ");
    int enclosure = int.Parse(Console.ReadLine()!);

    zoo.AddAnimal(new Animal(id, name, species, age, dailyFood, enclosure));
    Console.WriteLine("Animal added.");
}

static void MoveAnimal(ZooService zoo)
{
    Console.Write("Animal identifier: ");
    int id = int.Parse(Console.ReadLine()!);
    Console.Write("New enclosure number: ");
    int enclosure = int.Parse(Console.ReadLine()!);
    zoo.MoveAnimal(id, enclosure);
    Console.WriteLine("Animal moved.");
}

static void PrintAnimal(Animal animal)
{
    Console.WriteLine($"#{animal.Id} — {animal.Name}, {animal.Species}, age {animal.Age}, {animal.DailyFoodKg:0.00} kg/day, enclosure {animal.EnclosureNumber}");
}
