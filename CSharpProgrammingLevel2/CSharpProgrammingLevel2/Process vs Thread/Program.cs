using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Process_vs_Thread
{
    internal class Program
    {
        static int sharedCounter = 0;
        static object lockObject = new object();
        static void IncrementCounter()
        {
            for (int i = 0; i < 100000; i++)
            {
                // Use lock to synchronize access to the shared counter
                lock (lockObject)
                {
                    sharedCounter++;
                }
            }
        }
        static void SynchronizationExample( ) 
        {
            
            // Create two threads that increment a shared counter
            Thread t1 = new Thread(IncrementCounter);
            Thread t2 = new Thread(IncrementCounter);


            t1.Start();
            t2.Start();


            // Wait for both threads to complete
            t1.Join();
            t2.Join();


            Console.WriteLine("Final Counter Value: " + sharedCounter);
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            //// Create a new thread and start it
            //Thread t = new Thread(()=>ThreadMethod1("Method one"));
            //t.Start();

            //Thread t2 = new Thread(ThreadMethod2);
            //t2.Start();
            //// to Wait  t1 and t2 then run main use join
            //t.Join();
            //t2.Join();


            //// Main thread continues its execution
            //for ( int i = 1 ; i <= 10 ; i++ )
            //{
            //    Console.WriteLine("Main Thread: " + i);
            //    Thread.Sleep(1000); // Sleep for 1 second
            //}
            //Console.ReadKey();
            Example2.Run();
        }


        static void ThreadMethod1(String methodName)
        {
            for ( int i = 1 ; i <= 5 ; i++ )
            {
                Console.WriteLine($"{methodName}: " + i);
                Thread.Sleep(1000);
            }
        } 
        static void ThreadMethod2()
        {
            for ( int i = 1 ; i <= 5 ; i++ )
            {
                Console.WriteLine("Thread Method2: " + i);
                Thread.Sleep(1000);
            }
        }
    }
}
