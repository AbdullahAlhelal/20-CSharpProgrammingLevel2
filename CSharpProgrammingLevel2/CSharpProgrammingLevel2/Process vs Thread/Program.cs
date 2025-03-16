using System;
using System.Linq;
using System.Threading;

namespace Process_vs_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new thread and start it
            Thread t = new Thread(ThreadMethod1);
            t.Start();


            // Main thread continues its execution
            for ( int i = 1 ; i <= 10 ; i++ )
            {
                Console.WriteLine("Main Thread: " + i);
                Thread.Sleep(1000); // Sleep for 1 second
            }
            Console.ReadKey();
        }


        static void ThreadMethod1()
        {
            for ( int i = 1 ; i <= 5 ; i++ )
            {
                Console.WriteLine("Thread Method1: " + i);
                Thread.Sleep(1000);
            }
        }
    }
}
