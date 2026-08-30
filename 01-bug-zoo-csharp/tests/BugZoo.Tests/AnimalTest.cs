namespace BugZoo.Tests;

public class AnimalTests
{
    [Fact]
    public void Constructor_WithNegativeAge_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        int invalidAge = -1;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Animal(1, "Nala", "Lion", invalidAge, 6.5m, 3));
    }

    [Fact]
    public void Constructor_WithZeroEnclosureNumber_ThrowsArgumentOutOfRangeException()
    {
        int invalidEnclosureNumber = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Animal(1, "Nala", "Lion", 3, 3.5m, invalidEnclosureNumber));
    }

    [Fact]
    public void Constructor_WithValidAge_SetsAge()
    {
        int age = 8;
        Animal animal = new Animal(1, "Nala", "Lion", age, 6.5m, 3);
        Assert.Equal(age, animal.Age);
    }

    [Fact]
    public void MoveToEnclosure_WithValidEnclosureNumber_UpdatesEnclosureNumber()
    {
        Animal animal = new Animal(1, "Nala", "Lion", 3, 3.5m, 3);
        animal.MoveToEnclosure(7);
        Assert.Equal(7, animal.EnclosureNumber);
    }

    [Fact]
    public void MoveToEnclosure_WithInvalidEnclosureNumber_ThrowsAndKeepsCurrentEnclosure()
    {
        Animal animal = new Animal(1, "Nala", "Lion", 3, 3.5m, 3);
        int  invalidEnclosureNumber = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            animal.MoveToEnclosure(invalidEnclosureNumber));
        Assert.Equal(3, animal.EnclosureNumber);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Constructor_WithInvalidDailyFoodKg_ThrowsArgumentOutOfRangeException(decimal invalidDailyFoodKg)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Animal(1, "Nala", "Lion", 3, invalidDailyFoodKg, 3));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Constructor_WithInvalidId_ThrowsArgumentOutOfRangeException(int invalidId)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Animal(invalidId, "Nala", "Lion", 3, 6.5m, 3));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidName_ThrowsArgumentException(string invalidName)
    {
        Assert.Throws<ArgumentException>(() =>
            new Animal(1, invalidName, "Lion", 3, 6.5m, 3));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithInvalidSpecies_ThrowsArgumentException(string invalidSpecies)
    {
        Assert.Throws<ArgumentException>(() =>
            new Animal(1, "Nala", invalidSpecies, 3, 6.5m, 3));
    }
}