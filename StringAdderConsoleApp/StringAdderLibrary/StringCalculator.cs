using StringCalculatorLibrary.Interfaces;
using System.Text.RegularExpressions;

namespace StringCalculatorLibrary;

public class StringCalculator : IStringCalculator
{
    public int Calculate(string stringToCalculate)
    {
        if (string.IsNullOrEmpty(stringToCalculate)) 
            return 0;

        string[] numbers = Regex.Split(stringToCalculate, @"\D+");

        List<int> result = new List<int>();
        foreach (string number in numbers)
        {
            if (!string.IsNullOrEmpty(number))
            {
                int integer = int.Parse(number);
                if (integer < 1001)
                    result.Add(integer);
            }
        }

        return result.Sum();
    }
}
