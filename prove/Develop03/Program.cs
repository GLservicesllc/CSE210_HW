using System;
// Ways I Exceeded the Requirements:
// I included a feature where you can choose the difficuly level of memorization.
// I also included a feature where it will tell you how many words are hidden as you continue memorizing.
class Program
{
    static void Main(string[] args)
    { // Create a new Scripture object with a reference and text
        var scripture = new Scripture(
            new Reference("2 Nephi", 2, 4, 6),
            "And thou hast beheld in thy youth his glory; wherefore, thou art blessed even as they unto whom he shall minister in the flesh; for the Spirit is the same, yesterday, today, and forever. And the way is prepared from the fall of man, and salvation is free." +
            "And men are instructed sufficiently that they know good from evil. And the law is given unto men. And by the law no flesh is justified; or, by the law men are cut off. Yea, by the temporal law they were cut off; and also, by the spiritual law they perish from that which is good, and become miserable forever." +
            "Wherefore, redemption cometh in and through the Holy Messiah; for he is full of grace and truth.");

        int wordsPerTurn = ChooseDifficultyLevel();

        while (true)
        { // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\nWords hidden: {scripture.GetHiddenCount()}/{scripture.GetTotalCount()}");

            if (scripture.IsCompletelyHidden()) break;

            Console.WriteLine("\nPress enter to continue or type in 'quit' to finish.");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit") break;

            scripture.HideRandomWords(wordsPerTurn);
        }
    }

    static int ChooseDifficultyLevel()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose a difficulty level:");
            Console.WriteLine("1. Easy (Hide 1 word at a time)");
            Console.WriteLine("2. Medium (Hide 3 words at a time)");
            Console.WriteLine("3. Hard (Hide 5 words at a time)");
            Console.Write("\nEnter 1, 2, or 3: ");

            string choice = Console.ReadLine().Trim();

            if (choice == "1") return 1;
            if (choice == "2") return 3;
            if (choice == "3") return 5;
        }
    }
}