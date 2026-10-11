using System;

// EXCEEDING REQUIREMENTS:
// Added an extra activity. The activity is a Gratitude activity. This also takes from the Activity class. 

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            switch (Console.ReadLine())
            {
                case "1": new BreathingActivity().Run(); break;
                case "2": new ReflectionActivity().Run(); break;
                case "3": new ListingActivity().Run(); break;
                case "4": new GratitudeActivity().Run(); break;
                case "5": running = false; break;
            }
        }
    }
}