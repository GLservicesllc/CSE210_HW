using System;
//This is the program for the assignment, but also includes a prompt for the user to 
//rate their day. The program also only has the user rate their day once per entry.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!!!!");

        while (choice!= "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do today? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string today = DateTime.Now.ToShortDateString();
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write(">");
                string response = Console.ReadLine();
                string rating = journal.GetRatingForDate(today); // Get the rating for today, if it exists
                if (rating == "") // if statement to check if the user has already rated today
                {
                    Console.Write("What would you rate today on a scale of (1-10): ");
                    rating = Console.ReadLine();
                }

                Entry entry = new Entry();
                entry._date = today;
                entry._promptText = prompt;
                entry._entryText = response;
                entry._rating = rating; // Added a rating for user to reflect on their day

                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
        }
    }
}