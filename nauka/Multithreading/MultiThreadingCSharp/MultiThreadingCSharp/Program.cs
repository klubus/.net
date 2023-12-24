namespace MultiThreadingInCSharp
{

    class Program
    {
        static object _lock = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Write);
            Thread t2 = new Thread(Read);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.ReadLine();
        }

        public static void Write()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine("Write Thread Working.." + i);
                Console.WriteLine("Write Thread Completed.." + i);
                Monitor.Wait(_lock);
            }
        }

        public static void Read()
        {
            Monitor.Enter(_lock);
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine("Read Thread Working.." + i);
                Console.WriteLine("Read Thread Completed.." + i);
                Monitor.Wait(_lock);
            }
        }

    }

}
