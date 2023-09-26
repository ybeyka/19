using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть перше велике число:");
        string input1 = Console.ReadLine();
        LargeNumber num1 = new LargeNumber(input1);

        Console.WriteLine("Введiть друге велике число:");
        string input2 = Console.ReadLine();
        LargeNumber num2 = new LargeNumber(input2);

        Console.WriteLine("Виберiть операцiю (+, -, *):");
        string operation = Console.ReadLine().ToLower();

        LargeNumber result;
        switch (operation)
        {
            case "+":
                result = LargeNumber.Add(num1, num2);
                Console.WriteLine($"Результат: {num1} + {num2} = {result}");
                break;
            case "-":
                result = LargeNumber.Subtract(num1, num2);
                Console.WriteLine($"Результат: {num1} - {num2} = {result}");
                break;
            case "*":
                result = num1.Multiply(num2);
                Console.WriteLine($"Результат: {num1} * {num2} = {result}");
                break;
            default:
                Console.WriteLine("Невiдома операцiя");
                break;
        }
    }
}
