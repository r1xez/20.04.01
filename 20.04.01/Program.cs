using System;
using System.Collections.Generic;

class ArrayOperations
{
    public delegate bool Filter(int number);

    public static List<int> FilterArray(int[] array, Filter filter)
    {
        List<int> result = new List<int>();
        foreach (var num in array)
        {
            if (filter(num))
            {
                result.Add(num);
            }
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 13, 21, 34, 55, 89, 89, 97 };

        ArrayOperations.Filter evenFilter = num => num % 2 == 0;
        ArrayOperations.Filter oddFilter = num => num % 2 != 0;
        ArrayOperations.Filter primeFilter = num =>
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        };
        ArrayOperations.Filter fibonacciFilter = num =>
        {
            int a = 0, b = 1;
            while (b < num)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return b == num;
        };

        List<int> evenNumbers = ArrayOperations.FilterArray(numbers, evenFilter);
        List<int> oddNumbers = ArrayOperations.FilterArray(numbers, oddFilter);
        List<int> primeNumbers = ArrayOperations.FilterArray(numbers, primeFilter);
        List<int> fibonacciNumbers = ArrayOperations.FilterArray(numbers, fibonacciFilter);

        Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
        Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));
        Console.WriteLine("Prime numbers: " + string.Join(", ", primeNumbers));
        Console.WriteLine("Fibonacci numbers: " + string.Join(", ", fibonacciNumbers));
    }
}
