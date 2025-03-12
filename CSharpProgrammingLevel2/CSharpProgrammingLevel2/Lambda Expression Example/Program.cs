using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expression_Example
{

    class Program
    {

        //Example 1
        // Define a Func delegate for squaring a number using a lambda expression
        static Func<int , int> square = x => x * x;


        //Example 2 with out Lambda Expression
       
        // A delegate that represents an operation
        delegate int Operation(int x , int y);

        // A function that takes a delegate with parameters and invokes it
        static void ExecuteOperation(int x , int y , Operation operation)
        {
            int result = operation(x , y); // Invoke the provided delegate
            Console.WriteLine("Result: " + result);
        }

        // A method that performs addition
        static int Add(int x , int y)
        {
            return x + y;
        }

        // A method that performs subtraction
        static int Sub(int x , int y)
        {
            return x - y;
        }



       


        static void Main()
        {
            // Use the square Func to square the number 5
            int result = square(5);

            // Print the result
            Console.WriteLine("The square of 5 is: " + result);
            Console.ReadKey();


            // Use the Add method with the delegate
            Operation AddOp = Add;
            Operation SubOp = Sub;

            ExecuteOperation(10 , 20 , AddOp); // Pass the delegate as an argument
            ExecuteOperation(10 , 20 , SubOp); // Pass the delegate as an argument


            //Action Delegate With Lambda Expression
            Action parameterlessAction = () =>
            {
                Console.WriteLine("This is a parameterless action.");
            };

            Action<int> actionWithIntParameter = (x) =>
            {
                Console.WriteLine($"Action with int parameter: {x}");
            };

            Action<string , int> actionWithMultipleParameters = (str , num) =>
            {
                Console.WriteLine($"Action with string and int parameters: {str}, {num}");
            };
            parameterlessAction();
            actionWithIntParameter(42);
            actionWithMultipleParameters("Hello, World!" , 100);

            Func<int , int , int> add = (x , y) => x + y;

            Console.WriteLine( $" Result From Func is  {add(10 , 5)}");
        }
    }

}

