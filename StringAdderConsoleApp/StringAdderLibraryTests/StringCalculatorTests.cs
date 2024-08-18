using StringCalculatorLibrary;

namespace StringCalculatorLibraryTests;

public class StringCalculatorTests
{
    public static IEnumerable<object[]> StringCalculatorPositiveCases =>
    new[]
    {
        new object[] { "", 0 },
        new object[] { "1", 1 },
        new object[] { "1,2", 3 },
        new object[] { "1,1,2,3,5", 12 },
        new object[] { "1\n2,3", 6 },
        new object[] { "//;\n1;2", 3 },
        new object[] { "1001, 2", 2 },
        new object[] { "//[|||]\n1|||2|||3", 6 },
        new object[] { "//[|][%]\n1|2%3", 6 },
        new object[] { "//[|||][%%]\n1|||2%%3", 6 },
        // Add more test data here as appropriate
    };

    [Theory]
    [MemberData(nameof(StringCalculatorPositiveCases))]
    public void Calculate_PositiveIntegersReturnsCorrectTotal(string stringToCalculate, int expectedResult)
    {
        // Arrange
        var stringCalculator = new StringCalculator();

        // Act
        var result = stringCalculator.Calculate(stringToCalculate);

        // Assert
        Assert.Equal(expectedResult, result);
        Assert.IsType<int>(result);
    }

    [Fact]
    public void DebugTest()
    {
        // Arrange
        var stringCalculator = new StringCalculator();

        // Act
        var result = stringCalculator.Calculate("1,1,2,3,5");

        // Assert
        Assert.Equal(12, result);
        Assert.IsType<int>(result);
    }

    public static IEnumerable<object[]> StringCalculatorNegativeCases =>
    new[]
    {
        new object[] { "-1,2", "Negatives not allowed: -1" },
        new object[] { "2,-4,3,-5", "Negatives not allowed: -4,-5" },
        // Add more test data here as appropriate
    };

    [Theory]
    [MemberData(nameof(StringCalculatorNegativeCases))]
    public void Calculate_NegativeNumbersThrowsException(string stringToCalculate, string exceptionMessage)
    {
        // Arrange
        var stringCalculator = new StringCalculator();

        // Act - Assert
        var ex = Assert.Throws<Exception>(() => stringCalculator.Calculate(stringToCalculate));
        Assert.Equal(exceptionMessage, ex.Message);
    }
}