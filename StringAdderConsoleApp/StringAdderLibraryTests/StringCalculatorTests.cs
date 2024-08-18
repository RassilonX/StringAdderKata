namespace StringCalculatorLibraryTests;

public class StringCalculatorTests
{
    public static IEnumerable<object[]> StringCalculatorConditions =>
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
    [MemberData(nameof(StringCalculatorConditions))]
    public void Calculate_PositiveIntegersReturnsCorrectTotal(string stringToCalculate, int result)
    {

    }

    [Fact]
    public void Calculate_NegativeNumbersThrowsException()
    {

    }
}