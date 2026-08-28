namespace BugZoo;

public class Animal
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Species { get; private set; }
    public int Age { get; private set; }
    public decimal DailyFoodKg { get; private set; }
    public int EnclosureNumber { get; private set; }

    public Animal(int id, string name, string species, int age, decimal dailyFoodKg, int enclosureNumber)
    {
        Id = id > 0 ? id : throw new ArgumentOutOfRangeException(nameof(id));
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException(nameof(name)) : name;
        Species = string.IsNullOrWhiteSpace(species) ? throw new ArgumentException(nameof(species)) : species;
        Age = age >= 0 ? age : throw new ArgumentOutOfRangeException(nameof(age));
        DailyFoodKg = dailyFoodKg > 0 ? dailyFoodKg : throw new ArgumentOutOfRangeException(nameof(dailyFoodKg));
        EnclosureNumber = enclosureNumber > 0 ? enclosureNumber : throw new ArgumentOutOfRangeException(nameof(enclosureNumber));
    }

    public void MoveToEnclosure(int newEnclosureNumber)
    {
        EnclosureNumber = newEnclosureNumber > 0 ? newEnclosureNumber : throw new ArgumentOutOfRangeException(nameof(newEnclosureNumber));
    }
}
