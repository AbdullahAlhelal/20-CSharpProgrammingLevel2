using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Process_vs_Thread
{
    internal class Program
    {
        static void ParameterizedThread( ) 
        {
        }


        static void Main(string[] args)
        {
            // Create a new thread and start it
            Thread t = new Thread(()=>ThreadMethod1("Method one"));
            t.Start();

            Thread t2 = new Thread(ThreadMethod2);
            t2.Start();
            // to Wait  t1 and t2 then run main use join
            t.Join();
            t2.Join();


            // Main thread continues its execution
            for ( int i = 1 ; i <= 10 ; i++ )
            {
                Console.WriteLine("Main Thread: " + i);
                Thread.Sleep(1000); // Sleep for 1 second
            }
            Console.ReadKey();
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
