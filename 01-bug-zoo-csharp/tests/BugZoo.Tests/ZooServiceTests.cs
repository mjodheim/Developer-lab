namespace BugZoo.Tests;

public class ZooServiceTests
{
    [Fact]
    public void GetAllAnimals_WithTwoAnimals_ReturnsTwoAnimals()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        IReadOnlyList<ZooService.AnimalSnapshot> animals = zoo.GetAllAnimals();
        Assert.Equal(2, animals.Count);
    }

    [Fact]
    public void Constructor_WithDuplicateIds_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new ZooService([
                new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
                new Animal(1, "Kito", "Giraffe", 5, 12.75m, 1)
            ]));
    }

    [Fact]
    public void FindById_WithTwoAnimals_ReturnsCorrectAnimal()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        ZooService.AnimalSnapshot animal = zoo.FindById(2);
        Assert.Equal(2, animal.Id);
        Assert.Equal("Kito", animal.Name);
    }
    
    [Fact]
    public void FindById_WithIncorrectId_ThrowsKeyNotFoundException()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        Assert.Throws<KeyNotFoundException>(() => zoo.FindById(99));
    }

    [Fact]
    public void SearchBySpecies_WithDifferentCase_ReturnsMatchingAnimal()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        IEnumerable<ZooService.AnimalSnapshot> animals = zoo.SearchBySpecies("lion");
        ZooService.AnimalSnapshot animal = Assert.Single(animals);
        Assert.Equal("Nala", animal.Name);
    }
    
    [Fact]
    public void SearchBySpecies_WithUnknownSpecies_ReturnsEmptyCollection()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        
        IEnumerable<ZooService.AnimalSnapshot> animals = zoo.SearchBySpecies("Tiger");
        Assert.Empty(animals);
    }

    [Fact]
    public void AddAnimal_WithDuplicateId_ThrowsInvalidOperationException()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3)
        ]);
        Assert.Throws<InvalidOperationException>(() =>
            zoo.AddAnimal(new Animal(1, "Kito", "Giraffe", 5, 12.75m, 1)));

        IReadOnlyList<ZooService.AnimalSnapshot> animals = zoo.GetAllAnimals();

        Assert.Single(animals);
        Assert.Equal("Nala", animals[0].Name);
    }
    
    [Fact]
    public void AddAnimal_WithUniqueId_AddsAnimal()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3)
        ]);
        zoo.AddAnimal(new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1));
        
        IReadOnlyList<ZooService.AnimalSnapshot> animals = zoo.GetAllAnimals();
        Assert.Equal(2, animals.Count);
        
        ZooService.AnimalSnapshot addedAnimal = zoo.FindById(2);
        Assert.Equal("Kito", addedAnimal.Name);
    }
    
    [Fact]
    public void MoveAnimal_WithValidEnclosureNumber_UpdatesAnimalEnclosure()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3)
        ]);
        
        zoo.MoveAnimal(1, 7);
        
        ZooService.AnimalSnapshot animal = zoo.FindById(1);
        Assert.Equal(7, animal.EnclosureNumber);
    }

    [Fact]
    public void MoveAnimal_WithUnknownId_ThrowsKeyNotFoundException()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3)
        ]);
        
        Assert.Throws<KeyNotFoundException>(() => 
            zoo.MoveAnimal(99, 7));
        
        ZooService.AnimalSnapshot animal = zoo.FindById(1);
        Assert.Equal(3, animal.EnclosureNumber);
    }
    
    [Fact]
    public void CalculateTotalDailyFood_WithTwoAnimals_ReturnsSumOfDailyFood()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        
        decimal totalDailyFood = zoo.CalculateTotalDailyFood();
        Assert.Equal(19.25m, totalDailyFood);
    }

    [Fact]
    public void GenerateFeedingReport_WithTwoAnimals_GeneratesFeedingReport()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        
        IReadOnlyList<string> report = zoo.GenerateFeedingReport();
        
        Assert.Equal(2, report.Count);
        Assert.StartsWith("Enclosure 1:", report[0]);
        Assert.StartsWith("Enclosure 3:", report[1]);
    }

    [Fact]
    public void GenerateFeedingReport_DoesNotChangeAnimalOrder()
    {
        ZooService zoo = new([
            new Animal(1, "Nala", "Lion", 8, 6.5m, 3),
            new Animal(2, "Kito", "Giraffe", 5, 12.75m, 1)
        ]);
        
        zoo.GenerateFeedingReport();
        IReadOnlyList<ZooService.AnimalSnapshot> animals = zoo.GetAllAnimals();
        Assert.Equal(1,animals[0].Id);
        Assert.Equal(2,animals[1].Id);
    }
}
