int result;
int firstNumber;
int secondNumber;

Console.WriteLine("Hello, welcome to the calculator program!");

Console.WriteLine("Please enter your first number");
firstNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Please enter your second number");
secondNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("What type of operation would you like to do?");
Console.WriteLine("Please enter a for addition, s for subtraction, m for multiplication or any other key for division");
var operationType = Console.ReadLine();


if (operationType == "a")
{
    result = firstNumber + secondNumber;
}
else if (operationType == "s")
{
    result = firstNumber - secondNumber;
}
else if (operationType == "m")
{
    result = firstNumber * secondNumber;
}
else
{
    result = firstNumber / secondNumber;
}

Console.WriteLine("The result is: " + result);
Console.WriteLine("Thank you dor using calculator program!");
