using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Parallel.For

            // Define the number of iterationsy
            int numberOfIterations = 10;


            // Use Parallel.For to execute the loop in parallel
            Parallel.For(0 , numberOfIterations , i =>
            {
                Console.WriteLine($"Executing iteration {i} on thread {Task.CurrentId}");
                // Simulate some work
                Task.Delay(1000).Wait();
            });

        }
    }
}
