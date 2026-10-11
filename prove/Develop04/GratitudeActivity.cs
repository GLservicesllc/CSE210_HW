using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who is someone who made your week better, and how?",
        "What is a small thing from today that you're thankful for?",
        "What is a skill or ability you have that you're grateful for?",
        "What is a place that brings you peace, and why are you thankful for it?",
        "Who taught you something important, and what was it?",
        "What is something difficult that ended up helping you grow?"
    };

    private List<string> _responses = new List<string>();
    private Random _random = new Random();

    public GratitudeActivity() : base("Gratitude Activity",
        "This activity will help you notice and appreciate the good in your life. You will be given a few prompts to respond to in writing.")
    { }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Take a moment to think about each prompt, then write your response.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            Console.WriteLine($"> {_prompts[_random.Next(_prompts.Count)]}");
            Console.Write("  ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Here is what you were grateful for:\n");
        foreach (string response in _responses)
        {
            Console.WriteLine($"  - {response}");
        }
        Console.WriteLine();
        DisplayEndingMessage();
    }
}