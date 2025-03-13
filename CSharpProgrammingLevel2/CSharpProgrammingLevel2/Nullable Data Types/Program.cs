using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable_Data_Types
{
    internal class Program
    {
        #region Example2

        static void Procedure1(string Name , Nullable<int> Age)
        {

            Console.WriteLine("\nName is :" + Name);

            if ( Age.HasValue )
            {
                Console.WriteLine("Age is :" + Age.ToString());
            }
            else
            {
                Console.WriteLine("Age is Null");
            }


        }

        static void Procedure2(string Name , int? Age)
        {

            Console.WriteLine("\nName is :" + Name);

            if ( Age.HasValue )
            {
                Console.WriteLine("Age is :" + Age.ToString());
            }
            else
            {
                Console.WriteLine("Age is Null");
            }


        }

        #endregion

        static void Main(string[] args)
        {

            // Declare a nullable int using Nullable<T>
            Nullable<int> nullableInt1 = null;


            // Shorthand notation using int?
            int? nullableInt2 = null;


            // Check if the nullable ints have values
            if ( nullableInt1.HasValue )
            {
                Console.WriteLine("nullableInt1 has a value: " + nullableInt1.Value);
            }
            else
            {
                Console.WriteLine("nullableInt1 is null.");
            }


            if ( nullableInt2.HasValue )
            {
                Console.WriteLine("nullableInt2 has a value: " + nullableInt2.Value);
            }
            else
            {
                Console.WriteLine("nullableInt2 is null.");
            }


            // Using the null-coalescing operator
            int result = nullableInt2 ?? 0;
            Console.WriteLine("Using null-coalescing operator: " + result);


            // Using the null-conditional operator
            string stringValue = nullableInt2?.ToString();
            Console.WriteLine("String representation: " + (stringValue ?? "null"));



            Procedure1("Mohammed Abu-Hadhoud" , null);
            Procedure1("Ali Ahmed" , 35);


            Procedure2("Mohammed Abu-Hadhoud" , null);
            Procedure2("Ali Ahmed" , 35);


            Console.ReadKey();
        }
    }
}
