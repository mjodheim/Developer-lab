namespace BugZoo;

public class ZooService
{
    private readonly List<Animal> _animals;

    public ZooService(IEnumerable<Animal> animals) => _animals = animals.ToList();
    
    public sealed record AnimalSnapshot(
        int Id,
        string Name,
        string Species,
        int Age,
        decimal DailyFoodKg,
        int EnclosureNumber);
    
    public IReadOnlyList<AnimalSnapshot> GetAllAnimals() => _animals
        .Select(animal => new AnimalSnapshot(
            animal.Id,
            animal.Name,
            animal.Species,
            animal.Age,
            animal.DailyFoodKg,
            animal.EnclosureNumber))
        .ToList()
        .AsReadOnly();
    
    public AnimalSnapshot FindById(int animalId)
    {
        Animal animal = FindEntityById(animalId);

        return new AnimalSnapshot(
            animal.Id,
            animal.Name,
            animal.Species,
            animal.Age,
            animal.DailyFoodKg,
            animal.EnclosureNumber);
    }
    private Animal FindEntityById(int animalId)
    {
        return _animals.FirstOrDefault(animal => animal.Id == animalId)
               ?? throw new KeyNotFoundException(
                   $"No animal found with id {animalId}.");
    }

    public IEnumerable<AnimalSnapshot> SearchBySpecies(string species)
    {
        return GetAllAnimals().Where(animal => string.Equals(animal.Species, species, StringComparison.OrdinalIgnoreCase)); 
    }

    public void AddAnimal(Animal animal)
    {
        if (_animals.Any(existing => existing.Id.Equals(animal.Id)))
        {
            throw new InvalidOperationException("An animal with this identifier already exists.");
        }

        _animals.Add(animal);
    }

    
    public void MoveAnimal(int animalId, int newEnclosureNumber)
    {
        Animal animal = FindEntityById(animalId);
        animal.MoveToEnclosure(newEnclosureNumber);
    }

    public decimal CalculateTotalDailyFood()
    {
        return _animals.Sum(animal => animal.DailyFoodKg);
    }

    public IReadOnlyList<string> GenerateFeedingReport()
    {
        IEnumerable<Animal> animalsByEnclosure = _animals.OrderBy(animal => animal.EnclosureNumber);
        
        List<string> lines = [];
        foreach (Animal animal in animalsByEnclosure)
        {
            lines.Add($"Enclosure {animal.EnclosureNumber}: {animal.Name} ({animal.Species}) — " +
                      $"{animal.DailyFoodKg:0.00} kg");
        }

        return lines;
    }
}
