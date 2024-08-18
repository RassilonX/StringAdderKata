// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using StringCalculatorLibrary;
using StringCalculatorLibrary.Interfaces;


// Service Setup
var services = new ServiceCollection();
services.AddSingleton<IStringCalculator, StringCalculator>();

var serviceProvider = services.BuildServiceProvider();


// Program implementation

var stringCalc = serviceProvider.GetService<IStringCalculator>();

bool calculatingStrings = true;

while (calculatingStrings)
{
    string stringToCalculate = Console.ReadLine();

    if (string.IsNullOrEmpty(stringToCalculate))
    {
        break;
    }

    try
    {
        Console.WriteLine($"Calculating string: {stringToCalculate}");
        var calculatedResult = stringCalc.Calculate(stringToCalculate);
        Console.WriteLine($"String total: {calculatedResult}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

Console.WriteLine("Press any key to close...");
Console.ReadKey(true);
