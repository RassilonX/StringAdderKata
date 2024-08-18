using StringCalculatorLibrary.Interfaces;

namespace StringCalculatorLibrary;

public class StringCalculator : IStringCalculator
{
    public int Calculate(string stringToCalculate)
    {
        if (String.IsNullOrEmpty(stringToCalculate)) 
            return 0;

        return 0;
    }
}
