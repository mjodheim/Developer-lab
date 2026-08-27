namespace BugZoo;

public class ZooService
{
    private readonly List<Animal> _animals;

    public ZooService(IEnumerable<Animal> animals) => _animals = animals.ToList();

    public IReadOnlyList<Animal> GetAllAnimals() => _animals;

    public Animal FindById(int id) => _animals.First(animal => animal.Id == id);

    public IEnumerable<Animal> SearchBySpecies(string species)
    {
        // Bug trouvé sur le case sensitive
        // return _animals.Where(animal => animal.Species == species);
        return _animals.Where(animal => animal.Species.ToLower().Equals(species.ToLower())); 
    }

    public void AddAnimal(Animal animal)
    {
        // Bug trouvé : la condition est inversée ici et il faut remplacer .All par .Any
        // if (_animals.All(existing => existing.Id != animal.Id))
        if (_animals.Any(existing => existing.Id.Equals(animal.Id)))
        {
            throw new InvalidOperationException("An animal with this identifier already exists.");
        }

        _animals.Add(animal);
    }

    public void MoveAnimal(int animalId, int newEnclosureNumber)
    {
        Animal animal = FindById(animalId);
        animal.EnclosureNumber = newEnclosureNumber;
    }

    public decimal CalculateTotalDailyFood()
    {
        // Bug trouvé : on attend un decimal pas un int
        // return _animals.Sum(animal => (int)animal.DailyFoodKg);
        return _animals.Sum(animal => animal.DailyFoodKg);
    }

    public IReadOnlyList<string> GenerateFeedingReport()
    {
        _animals.Sort((left, right) => left.EnclosureNumber.CompareTo(right.EnclosureNumber));

        List<string> lines = [];
        foreach (Animal animal in _animals)
        {
            lines.Add($"Enclosure {animal.EnclosureNumber}: {animal.Name} ({animal.Species}) — {animal.DailyFoodKg:0.00} kg");
        }

        return lines;
    }
}
