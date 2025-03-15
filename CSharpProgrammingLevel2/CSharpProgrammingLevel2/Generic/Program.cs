using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class GenericBox<T>
    {
        private T content;


        public GenericBox(T value)
        {
            content = value;
        }


        public T GetContent()
        {
            return content;
        }
    }



    internal class Program
    {

        public class Utility
        {
            public static T Swap<T>(ref T first , ref T second)
            {
                T temp = first;
                first = second;
                second = temp;
                return temp;
            }
        }

        static void Main(string[] args)
        {

            // Usage with integers
            int a = 5, b = 10;
            Console.WriteLine($"Before swap: a = {a}, b = {b}");
            Utility.Swap(ref a , ref b);
            Console.WriteLine($"After swap: a = {a}, b = {b}");
            Console.WriteLine();


            // Usage with strings
            string x = "Hello", y = "World";
            Console.WriteLine($"Before swap: x = {x}, y = {y}");
            Utility.Swap(ref x , ref y);
            Console.WriteLine($"After swap: x = {x}, y = {y}");


            // class 

            // Usage:
            GenericBox<int> intBox = new GenericBox<int>(42);
            Console.WriteLine("Content of intBox: " + intBox.GetContent()); // Outputs: 42


            GenericBox<string> stringBox = new GenericBox<string>("Hello, World!");
            Console.WriteLine("Content of stringBox: " + stringBox.GetContent()); // Outputs: Hello, World!
        }
    }
}
