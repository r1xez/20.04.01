using System;

public class NumberProcessor
{
    
    public delegate bool NumberCheckDelegate(int number);

  
    public static bool IsPositive(int number)
    {
        Console.WriteLine($"Checking if {number} is positive.");
        return number > 0;
    }

    
    public static bool IsEven(int number)
    {
        Console.WriteLine($"Checking if {number} is even.");
        return number % 2 == 0;
    }

    
    public static bool IsGreaterThanTen(int number)
    {
        Console.WriteLine($"Checking if {number} is greater than 10.");
        return number > 10;
    }
}

class Program
{
    static void Main()
    {
        
        NumberProcessor.NumberCheckDelegate checkChain = NumberProcessor.IsPositive;
        checkChain += NumberProcessor.IsEven;
        checkChain += NumberProcessor.IsGreaterThanTen;

        
        int number = 12;

      
        bool result = checkChain(number);

       
        if (result)
        {
            Console.WriteLine($"The number {number} passed all checks.");
        }
        else
        {
            Console.WriteLine($"The number {number} failed the checks.");
        }
    }
}
