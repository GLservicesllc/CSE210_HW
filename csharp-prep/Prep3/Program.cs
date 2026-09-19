using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        
        do
        {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
        int guessCount = 0;

        Console.Write("What do you think the magic number is? Make a guess. ");
        string valueFromUser = Console.ReadLine();
        int guess = int.Parse(valueFromUser);
        guessCount++;
            while (guess != number)
            {
                if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }

                Console.Write("Guess again: ");
                valueFromUser = Console.ReadLine();
                guess = int.Parse(valueFromUser);
                guessCount++;
            }
            Console.WriteLine($"Thats the Number! You guessed it in {guessCount} guesses!");
            Console.WriteLine("Do you want to play again? (Yes/No) ");
            playAgain = Console.ReadLine();
        } while (playAgain == "Yes");

        Console.WriteLine("Thanks for playing!" );
    }
}