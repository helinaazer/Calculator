using System;

Console.WriteLine("-------Calculator-------");

bool perform = true;

while (perform)
{
    Console.WriteLine("Which operation would you like to perform? (+, -, *, /, sqrt)");
    string operation = Console.ReadLine();
    string op;

    switch (operation)
    {
        case "+":
            op = "add";
            break;
        case "-":
            op = "subtract";
            break;
        case "*":
            op = "multiply";
            break;
        case "/":
            op = "divide";
            break;
        case "sqrt":
            op = "square root";
            break;
        default:
            Console.WriteLine("Invalid operation. Please try again.");
            continue;
    }

    Console.WriteLine($"How many numbers would you like to {op}?");
    if (!double.TryParse(Console.ReadLine(), out double time) || time <= 0)
    {
        Console.WriteLine("Invalid input for the number of values.");
        continue;
    }

    double[] val = new double[(int)time];

    for (int i = 0; i < time; i++)
    {
        Console.WriteLine($"Enter number ({i + 1}):");
        if (!double.TryParse(Console.ReadLine(), out double num))
        {
            Console.WriteLine("Invalid input for number. Please enter a valid numeric value.");
            i--; // Retry input for this number
            continue;
        }
        val[i] = num;
    }

    double result = operation switch
    {
        "+" => val.Sum(),
        "-" => val.Aggregate((a, b) => a - b),
        "*" => val.Aggregate((a, b) => a * b),
        "/" => val.Aggregate((a, b) => a / b),
        "sqrt" => Math.Sqrt(val[0]), // Only the first number for sqrt
        _ => 0,
    };

    Console.WriteLine($"The result of {op} is: {result}");

    Console.WriteLine("Would you like to perform another calculation? (Y/N)");
    string redo = Console.ReadLine()?.ToLower();
    while (redo != "n" && redo != "y")
    {
        Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
        redo = Console.ReadLine()?.ToLower();
    }

    perform = redo == "y";
}

