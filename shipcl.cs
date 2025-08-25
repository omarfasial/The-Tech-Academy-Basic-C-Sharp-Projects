using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Required opening line
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Use invariant culture for parsing; format output as en-US currency
        var us = CultureInfo.GetCultureInfo("en-US");

        // Ask for weight
        Console.WriteLine("Please enter the package weight:");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double w) || w < 0)
        {
            // Input handling not specified by the spec; exit quietly on bad input
            return;
        }

        // Too heavy?
        if (w > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return;
        }

        // Ask for width, height, length — in that order
        Console.WriteLine("Please enter the package width:");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double width) || width < 0)
            return;

        Console.WriteLine("Please enter the package height:");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double height) || height < 0)
            return;

        Console.WriteLine("Please enter the package length:");
        if (!double.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out double length) || length < 0)
            return;

        // Too big?
        if ((width + height + length) > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return;
        }

        // Quote = (h * w * l * weight) / 100
        double quote = (height * width * length * w) / 100.0;

        // Show as US dollar amount with two decimals
        string price = quote.ToString("C2", us);
        Console.WriteLine($"Your estimated total for shipping this package is: {price}");
        Console.WriteLine("Thank you!");
    }
}
