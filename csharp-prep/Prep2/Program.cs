using System;

class Program
{
    static void Main(string[] args)
    {
       Console.Write("Enter your Grade Percentage: ");
       string valueFromUser = Console.ReadLine();
       int grade = int.Parse(valueFromUser);
       string letter;
    
       
       if (grade >= 90)
        {
            letter = "A";

            if (grade % 10 >=7)
            {
                letter += "+";
            }

            else if (grade % 10 <= 3)
            {
                letter += "-";
            }
        }
        else if (grade >= 80)
        {
            letter = "B";

            if (grade % 10 >=7)
            {
                letter += "+";
            }

            else if (grade % 10 <= 3)
            {
                letter += "-";
            }
        }
        else if (grade >= 70)
        {
            letter = "C";
             
            if (grade % 10 >=7)
            {
                letter += "+";
            }

            else if (grade % 10 <= 3)
            {
                letter += "-";
            }
        }
        else if (grade >= 60)
        {
            letter = "D";

            if (grade % 10 >=7)
            {
                letter += "+";
            }

            else if (grade % 10 <= 3)
            {
                letter += "-";
            }
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your Grade is a {letter} in the class.");
    }
}