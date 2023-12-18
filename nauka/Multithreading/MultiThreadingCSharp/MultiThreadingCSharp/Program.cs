using System.Diagnostics;

namespace MultiThreadingInCSharp
{

    class Program
    {
        public static int Sum = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Main method execution started");

            Stopwatch _watch = Stopwatch.StartNew();
            Thread t1 = new Thread(Addition);
            Thread t2 = new Thread(Addition);
            Thread t3 = new Thread(Addition);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Total sum is: " + Sum);
            _watch.Stop();
            Console.WriteLine("Total tick time is: " + _watch.ElapsedTicks);

            Console.ReadLine();
        }

        public static object _lock = new object();

        public static void Addition()
        {
            for (int i = 1; i < 50000; i++)
            {
                //Sum++;
                //Interlocked.Increment(ref Sum);
                //lock (_lock)
                //{
                //    Sum++;
                //}
                bool lockTaken = false;
                Monitor.Enter(_lock, ref lockTaken);
                try
                {
                    Sum++;
                }
                finally
                {
                    if (lockTaken)
                        Monitor.Exit(_lock);
                }
            }
        }
    }

}
