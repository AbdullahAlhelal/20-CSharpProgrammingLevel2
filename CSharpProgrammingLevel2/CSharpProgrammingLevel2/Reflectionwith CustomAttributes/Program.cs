using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflectionwith_CustomAttributes
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }


        public MyCustomAttribute(string description)
        {
            Description = description;
        }
    }

    [MyCustom("This is a class attribute")]
    class MyClass
    {
        [MyCustom("This is a method attribute")]
        public void MyMethod()
        {
            // Method implementation
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            // Get the type of MyClass
            Type type = typeof(MyClass);

            // Get class-level attributes
            object[] classAttributes = type.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach (MyCustomAttribute attribute in classAttributes)
            {
                Console.WriteLine($"Class Attribute: {attribute.Description}");
            }


            // Get method-level attributes
            MethodInfo methodInfo = type.GetMethod("MyMethod");
            object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach (MyCustomAttribute attribute in methodAttributes)
            {
                Console.WriteLine($"Method Attribute: {attribute.Description}");
            }


            clsPerson clsPerson = new clsPerson();

            clsPerson.Name = "ahmad";
            clsPerson.Age = 15;

            ValidatePerson(clsPerson);
        }

        static bool ValidatePerson(clsPerson person)
        {
            Type type = typeof(clsPerson);

            foreach (var property in type.GetProperties())
            {
                // Check for RangeAttribute on properties
                if (Attribute.IsDefined(property, typeof(RangeAttribute)))
                {
                    var rangeAttribute = (RangeAttribute)Attribute.GetCustomAttribute(property, typeof(RangeAttribute));
                    int value = (int)property.GetValue(person);

                    // Perform validation
                    if (value < rangeAttribute.Min || value > rangeAttribute.Max)
                    {
                        Console.WriteLine($"Validation {property.GetValue(person)} failed for property '{property.Name}': {rangeAttribute.ErrorMessage}");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
