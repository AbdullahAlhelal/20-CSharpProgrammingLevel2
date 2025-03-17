using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Class
{
    internal class Program
    {

        static List<string> urls = new List<string>
    {
        "https://www.cnn.com",
        "https://www.amazon.com",
        "https://www.programmingadvices.com"
    };

        static void DownloadContent(string url)
        {
            string content;


            using ( WebClient client = new WebClient() )
            {
                // Simulate some work by adding a delay
                Thread.Sleep(100);


                // Download the content of the web page
                content = client.DownloadString(url);
            }


            Console.WriteLine($"{url}: {content.Length} characters downloaded");
        }

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

            //Parallel.ForEach



            // Use Parallel.ForEach to download the web pages concurrently
            Parallel.ForEach(urls , url =>
            {
                DownloadContent(url);

            });


            Console.WriteLine("Done!");
            Console.ReadKey();
        }


    }
}
