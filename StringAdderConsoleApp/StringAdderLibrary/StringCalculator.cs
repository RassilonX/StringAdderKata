using StringCalculatorLibrary.Interfaces;
using System.Text.RegularExpressions;

namespace StringCalculatorLibrary;

public class StringCalculator : IStringCalculator
{
    public int Calculate(string stringToCalculate)
    {
        if (string.IsNullOrEmpty(stringToCalculate)) 
            return 0;

        string[] numbers = Regex.Split(stringToCalculate, @"[^\d-]+");

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

        // Check for negative numbers
        List<int> negativeNumbers = result.FindAll(i => i < 0);
        if (negativeNumbers.Count > 0)
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }

        return result.Sum();
    }
}
