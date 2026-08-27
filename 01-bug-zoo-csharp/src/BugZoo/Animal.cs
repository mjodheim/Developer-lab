namespace BugZoo;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public decimal DailyFoodKg { get; set; }
    public int EnclosureNumber { get; set; }

    public Animal(int id, string name, string species, int age, decimal dailyFoodKg, int enclosureNumber)
    {
        Id = id;
        Name = name;
        Species = species;
        Age = age;
        DailyFoodKg = dailyFoodKg;
        EnclosureNumber = enclosureNumber;
    }
}
