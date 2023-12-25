Random r = new Random();
int random = r.Next(1, 11);
string typedNumber;
bool isGuessConvertableToInt;
int guess;
bool winner = false;

Console.WriteLine("Welcome to the number guessing game!");
Console.WriteLine("A number between 1 and 10 will be generated.");
Console.WriteLine("If you guess the correct number, you win!");

while (!winner)
{
    Console.WriteLine("Please enter your guess");
    typedNumber = Console.ReadLine();

    isGuessConvertableToInt = int.TryParse(typedNumber, out guess);

    if (!isGuessConvertableToInt)
    {
        Console.WriteLine("Unappropriate value");
    }

    if (guess < random && isGuessConvertableToInt)
    {
        Console.WriteLine("Your guess is to low!");
    }

    if (guess > random)
    {
        Console.WriteLine("Your guess is to high!");
    }

    Console.WriteLine("");

    if (guess == random)
    {
        Console.WriteLine("Correct");
        Console.WriteLine("Congratulations, you have won the game!");
        winner = true;
        Console.ReadKey();
    }

}