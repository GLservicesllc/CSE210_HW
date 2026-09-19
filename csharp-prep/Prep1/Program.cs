using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string name_first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string name_last = Console.ReadLine();
        
        Console.WriteLine($"Your name is {name_last}, {name_first} {name_last}. ");
    }
}