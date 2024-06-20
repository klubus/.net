using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Configuration.GetInstance();
            var b = Configuration.GetInstance();

            if (ReferenceEquals(a,b))
            {
                Console.WriteLine("Configuration is singleton.");
            }

        }
    }
}