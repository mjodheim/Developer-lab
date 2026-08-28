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
    public void Constructor_WithNegativeDailyFoodKg_ThrowsArgumentOutOfRangeException()
    {
        decimal invalidDailyFoodKg = -1m;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Animal(1, "Nala", "Lion", 3, invalidDailyFoodKg, 3));
    }

    [Fact]
    public void Constructor_WithZeroEnclosureNumber_ThrowsArgumentOutOfRangeException()
    {
        int invalidEnclosureNumber = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Animal(1, "Nala", "Lion", 3, 3.5m, invalidEnclosureNumber));
    }

    [Fact]
    public void Constructor_WithValid_SetsAge()
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
}