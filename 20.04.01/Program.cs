using System;

public class StringProcessor
{
   
    public delegate int StringOperation(string str);

   
    public static int CountVowels(string str)
    {
        int count = 0;
        foreach (char c in str)
        {
            if ("aeiouAEIOU".Contains(c))
            {
                count++;
            }
        }
        return count;
    }

   
    public static int CountConsonants(string str)
    {
        int count = 0;
        foreach (char c in str)
        {
            if (Char.IsLetter(c) && !"aeiouAEIOU".Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    
    public static int CountLength(string str)
    {
        return str.Length;
    }
}

class Program
{
    static void Main()
    {
        string inputString = "Hello World!";

       
        StringProcessor.StringOperation vowelsDelegate = new StringProcessor.StringOperation(StringProcessor.CountVowels);
        StringProcessor.StringOperation consonantsDelegate = new StringProcessor.StringOperation(StringProcessor.CountConsonants);
        StringProcessor.StringOperation lengthDelegate = new StringProcessor.StringOperation(StringProcessor.CountLength);

       
        int vowelsCount = vowelsDelegate(inputString);
        int consonantsCount = consonantsDelegate(inputString);
        int length = lengthDelegate(inputString);

        Console.WriteLine($"Input string: {inputString}");
        Console.WriteLine($"Number of vowels: {vowelsCount}");
        Console.WriteLine($"Number of consonants: {consonantsCount}");
        Console.WriteLine($"Length of string: {length}");
    }
}
