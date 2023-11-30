Method1();
Method2();
Method3();
Console.ReadLine();

static void Method1()
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine("Method1 :" + i);
    }
}
static void Method2()
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine("Method2 :" + i);
        if (i == 2)
        {
            Console.WriteLine("Method2 DB operation Started");
            //Sleep for 10 seconds
            Thread.Sleep(10000);
            Console.WriteLine("Method2 DB operation Completed");
        }
    }
}
static void Method3()
{
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine("Method3 :" + i);
    }
}