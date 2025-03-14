using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method , AllowMultiple = true)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; }


    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}

namespace example_using_Binary_Serialization
{

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Create an instance of the Person class
            Person person = new Person { Name = "Mohammed Abu-Hadhoud" , Age = 46 };


            // Binary serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using ( FileStream stream = new FileStream("person.bin" , FileMode.Create) )
            {
                formatter.Serialize(stream , person);
            }


            // Deserialize the object back
            using ( FileStream stream = new FileStream("person.bin" , FileMode.Open) )
            {
                Person deserializedPerson = (Person) formatter.Deserialize(stream);
                Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
                Console.ReadKey();
            }
        }
    }
}
