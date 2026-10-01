using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        f1.SetTop(6);
        f1.SetBottom(7);
        Console.WriteLine($"Top: {f1.GetTop()}, Bottom: {f1.GetBottom()}");
        Console.WriteLine(f1.GetFractionString());
        

        Fraction fraction = new Fraction();
        Random random = new Random();

        for (int i = 1; i <= 20; i++)
        {
            int top = random.Next(1, 11);
            int bottom = random.Next(1, 11);

            fraction.SetTop(top);
            fraction.SetBottom(bottom);

            Console.WriteLine($"Fraction {i}: string: {fraction.GetFractionString()} Number: {fraction.GetDecimalValue()}");
        }
    }
}