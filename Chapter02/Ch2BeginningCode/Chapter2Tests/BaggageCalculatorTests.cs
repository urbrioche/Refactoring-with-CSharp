namespace Packt.CloudySkiesAir.Chapter2.Tests;

public class BaggageCalculatorTests
{
    [Fact]
    public void PriceWithNoBagsIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 0;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Assert
        Assert.Equal(0, actualPrice);
    }

    [Fact]
    public void PriceWithTwoPassengersAndThreeCheckedIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 3, 1);

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Assert
        Assert.Equal(190M, actualPrice);
    }

    [Fact]
    public void PriceWithCarryOnBagIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Assert
        Assert.Equal(30M, actualPrice);
    }

    [Fact]
    public void PriceWithTwoCheckedIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Assert
        Assert.Equal(120M, actualPrice);
    }

    [Fact]
    public void HolidayPriceIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 12, 19);

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Assert
        Assert.Equal(209M, actualPrice);
    }
}