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
}