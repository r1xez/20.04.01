using System;
using System.IO;

class Program
{
   
    public delegate void MessageDelegate(string message);

   
    public static void PrintMessage(string message)
    {
        Console.WriteLine($"Console Output: {message}");
    }

   
    public static void WriteMessageToFile(string message)
    {
        string filePath = "output.txt";
        File.AppendAllText(filePath, message + Environment.NewLine);
        Console.WriteLine($"Message written to file: {filePath}");
    }

    static void Main()
    {
        MessageDelegate messageDelegate = PrintMessage;
        messageDelegate += WriteMessageToFile;           

       
        string message = "Hello, this is a test message!";
        messageDelegate(message);

       
        string fileContent = File.ReadAllText("output.txt");
        Console.WriteLine("File content:\n" + fileContent);
    }
}
