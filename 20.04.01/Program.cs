using System;

class Program
{
    static void Main()
    {
        
        Action showTime = () => Console.WriteLine("Current Time: " + DateTime.Now.ToString("HH:mm:ss"));
        Action showDate = () => Console.WriteLine("Current Date: " + DateTime.Now.ToString("yyyy-MM-dd"));
        Action showDayOfWeek = () => Console.WriteLine("Today is: " + DateTime.Now.DayOfWeek);

      
        Func<double, double, double> triangleArea = (baseLength, height) => 0.5 * baseLength * height;
        Func<double, double, double> rectangleArea = (width, height) => width * height;

       
        showTime();
        showDate();
        showDayOfWeek();

        double baseLength = 5.0;
        double height = 10.0;
        double triangleAreaResult = triangleArea(baseLength, height);
        Console.WriteLine($"Area of Triangle: {triangleAreaResult}");

        double rectangleWidth = 4.0;
        double rectangleHeight = 6.0;
        double rectangleAreaResult = rectangleArea(rectangleWidth, rectangleHeight);
        Console.WriteLine($"Area of Rectangle: {rectangleAreaResult}");
    }
}
