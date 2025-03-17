using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    // Custom event arguments class
    public class CustomEventArgs : EventArgs
    {
        public int Parameter1 { get; }
        public string Parameter2 { get; }

        public CustomEventArgs(int param1 , string param2)
        {
            Parameter1 = param1;
            Parameter2 = param2;
        }
    }


    internal class Program
    {
        #region 
        //  Task Class Example 2
        static async Task DownloadAndPrintAsync(string url)
        {

            string content;

            // Using statement ensures that the WebClient is disposed of properly
            using ( WebClient client = new WebClient() )
            {
                // Simulate some work by adding a delay
                await Task.Delay(100);

                // Download the content of the web page asynchronously
                content = await client.DownloadStringTaskAsync(url);
            }

            // Print the URL and the length of the downloaded content
            Console.WriteLine($"{url}: {content.Length} characters downloaded");
        }
        #endregion

        // Define a delegate for the callback
        public delegate void CallbackEventHandler(object sender , CustomEventArgs e);

        // Define an event based on the delegate
        public static event CallbackEventHandler CallbackEvent;

        static async Task Main()
        {
            // Create and run an asynchronous task
            Task<int> resultTask = PerformAsyncOperation();

            // Do some other work while waiting for the task to complete
            Console.WriteLine("Doing some other work...");


            // Wait for the task to complete and retrieve the result
            int result = await resultTask;


            // Process the result
            Console.WriteLine($"Result: {result}");

            //2

            Console.WriteLine("Starting tasks...");

            // Start the first task to download and print content length from CNN
            Task task1 = DownloadAndPrintAsync("https://www.cnn.com");
            Console.WriteLine("Task 1 started...");

            // Start the second task to download and print content length from Amazon
            Task task2 = DownloadAndPrintAsync("https://www.amazon.com");
            Console.WriteLine("Task 2 started...");

            // Start the third task to download and print content length from ProgrammingAdvices
            Task task3 = DownloadAndPrintAsync("https://www.ProgrammingAdvices.com");
            Console.WriteLine("Task 3 started...\n");

            // Wait for all tasks to complete
            await Task.WhenAll(task1 , task2 , task3);

            // Print a message indicating that all tasks have finished execution
            Console.WriteLine("\nDone, all tasks finished execution.");
            Console.ReadKey();


            // With call back  // Subscribe to the event
            CallbackEvent += OnCallbackReceived;

            // Create and run a Task for the asynchronous operation, passing CallbackEvent as a parameter
            Task performTask = PerformAsyncOperation(CallbackEvent);

            // Do some other work while waiting for the task to complete
            Console.WriteLine("Doing some other work...");

            // Wait for the task to complete
            await performTask;

            Console.WriteLine("Done!");
            Console.ReadKey();

            // Define long-running tasks
            Task task4 = Task.Run(() => DownloadFile("Download File 1"));

            Task task5 = Task.Run(() => DownloadFile("Dowload File 2"));

            // Wait for both tasks to finish
            await Task.WhenAll(task4 , task5);

            // Display execution time for each task
            Console.WriteLine($"Task 1 and 2 completed");
            Console.ReadKey();

        }

        static async Task PerformAsyncOperation(CallbackEventHandler callback)
        {
            // Simulate an asynchronous operation
            await Task.Delay(2000);

            // Create event arguments with two parameters
            CustomEventArgs eventArgs = new CustomEventArgs(42 , "Hello from event");

            // Check if the callback event is not null before invoking
            callback?.Invoke(null , eventArgs);
        }

        // Event handler for the CallbackEvent
        static void OnCallbackReceived(object sender , CustomEventArgs e)
        {
            Console.WriteLine($"Event received: Parameter 1 - {e.Parameter1}, Parameter 2 - {e.Parameter2}");
        }


        static async Task<int> PerformAsyncOperation()
        {
            // Simulate an asynchronous operation
            await Task.Delay(2000);

            // Return a result
            return 42;
        }


        //Task.Run Example 

        static void DownloadFile(string TaskName)
        {
            Console.WriteLine($"{TaskName}: Started!");
            Thread.Sleep(5000); // Simulate long-running operation
            Console.WriteLine($"{TaskName}: Completed!");
        }
    }
}
