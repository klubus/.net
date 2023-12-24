Random r = new Random();
int userRandom;
int aiRandom;
int userScore = 0;
int aiScore = 0;

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Press any key to roll the dice.");
    Console.ReadKey(true);

    userRandom = r.Next(1, 7);
    aiRandom = r.Next(1, 7);
    Console.WriteLine("You rolled a: " + userRandom);
    Console.WriteLine("...");
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("Enemy AI rolled a: " + aiRandom);

    if (userRandom > aiRandom)
    {
        Console.WriteLine("Player wins this round");
        userScore++;
    }
    else if (aiRandom > userRandom)
    {
        Console.WriteLine("Enemy wins this round");
        aiScore++;
    }
    else
    {
        Console.WriteLine("Draw!");
        userScore++;
        aiScore++;
    }
    Console.WriteLine($"The score is now - Player: {userScore}. Enemy: {aiScore}");
    Console.WriteLine("");
    Console.WriteLine("");
}

if (userScore > aiScore)
{
    Console.WriteLine("You WIN!");
}
else if (aiScore > userScore)
{
    Console.WriteLine("Enemy WIN");
}
else
{
    Console.WriteLine("DRAW");
}