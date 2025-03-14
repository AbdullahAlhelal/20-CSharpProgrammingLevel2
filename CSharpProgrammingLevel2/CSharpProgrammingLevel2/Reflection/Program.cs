using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Reflection
{
    public class MyClass
    {
        public int Property1 { get; set; }

        public void Method1()
        {
            Console.WriteLine("\tMethod1 is Executed");
        }

        public void Method2(int value1 , string value2)
        {
            Console.WriteLine($"\tMethod2 is Executed with parameters: {value1}, {value2}");
        }
    }

    internal class Program
    {
        public static void StringInfo()
        {


            // Get the assembly containing the System.String type
            Assembly mscorlib = typeof(string).Assembly;


            // Get the System.String type
            Type stringType = mscorlib.GetType("System.String");


            if ( stringType != null )
            {
                Console.WriteLine($"Methods of the System.String class:\n");


                // Get all public methods of the System.String class
                var stringMethods = stringType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .OrderBy(method => method.Name);


                foreach ( var method in stringMethods )
                {
                    Console.WriteLine($"\t{method.ReturnType} {method.Name}({GetParameterList(method.GetParameters())})");
                }
            }
            else
            {
                Console.WriteLine("System.String type not found.");
            }


            Console.ReadKey();


        }



        static string GetParameterList(ParameterInfo[] parameters)
        {
            return string.Join(", " , parameters.Select(parameter => $"{parameter.ParameterType} {parameter.Name}"));
        }

        static void DynamicallyCreateObjectsandInvoke()
        {
            // Get the type information for MyClass
            Type myClassType = typeof(MyClass);

            // Get and display information about the type
            Console.WriteLine($"Type Name: {myClassType.Name}");
            Console.WriteLine($"Full Name: {myClassType.FullName}");

            // Get the properties of MyClass
            Console.WriteLine("\nProperties:");
            foreach ( var property in myClassType.GetProperties() )
            {
                Console.WriteLine($"Property Name: {property.Name}, Type: {property.PropertyType}");
            }

            // Get the methods of MyClass
            Console.WriteLine("\nMethods:\n");
            foreach ( var method in myClassType.GetMethods() )
            {
                Console.WriteLine($"\t{method.ReturnType} {method.Name}({GetParameterList(method.GetParameters())})");
            }


            // Create an instance of MyClass
            object myClassInstance = Activator.CreateInstance(myClassType);


            // Set the value of Property1 using reflection
            myClassType.GetProperty("Property1").SetValue(myClassInstance , 42);
            Console.WriteLine("\nSet Property1 to 42 using reflection:");


            // Get the value of Property1 using reflection
            Console.WriteLine("\nGetting Property1 is value using reflection:");
            int Property1Value = (int) myClassType.GetProperty("Property1").GetValue(myClassInstance);
            Console.WriteLine($"\tProperty1 Value: {Property1Value}");


            //now how to execute methods using reflection:
            Console.WriteLine("\nExecuting Methods using reflection:\n");

            // Invoke the Method1 using reflection
            myClassType.GetMethod("Method1").Invoke(myClassInstance , null);

            // Invoke Method2 with parameters using reflection
            object[] parameters = { 100 , "Mohammed Abu-Hadhoud" };
            myClassType.GetMethod("Method2").Invoke(myClassInstance , parameters);

        }

        static void Main(string[] args)
        {
            DynamicallyCreateObjectsandInvoke();
        }
    }
}

