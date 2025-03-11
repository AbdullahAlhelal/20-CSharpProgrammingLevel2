using System;

class Program1
{
    // Define a delegate type for squaring a number
    delegate int SquareDelegate(int x);


    // Define a method that squares a number
    static int SquareMethod(int x)
    {
        return x * x;
    }

    static void Main1()
    {
        // Create an instance of the SquareDelegate and associate it with the SquareMethod
        SquareDelegate square = new SquareDelegate(SquareMethod);

        // Use the square delegate to square the number 5
        int result = square(5);

        // Print the result
        Console.WriteLine("The square of 5 is: " + result);
        Console.ReadKey();

    }
}
