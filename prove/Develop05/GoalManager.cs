using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private readonly string[] _titles =
    {
        "Humble Beginner", "Faithful Apprentice", "Diligent Disciple",
        "Valiant Warrior", "Ninja Unicorn", "Eternal Champion"
    };

    private int GetLevel() => Math.Max(0, _score) / 1000 + 1;

    private string GetTitle()
        => _titles[Math.Min(GetLevel() - 1, _titles.Length - 1)];

    public void Start()
    {
        string choice = "";
        while (choice != "7")
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Show Score");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": DisplayPlayerInfo(); break;
                case "7": Console.WriteLine("May you keep questing!"); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points. Level {GetLevel()}: {GetTitle()}");
        int next = GetLevel() * 1000 - Math.Max(0, _score);
        Console.WriteLine($"{next} points until the next level.");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    private string Clean(string text) => text.Replace("|", "/");

    private int AskInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
            Console.Write("Please enter a whole number: ");
        return value;
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3" && type != "4")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Clean(Console.ReadLine());
        Console.Write("What is a short description of it? ");
        string desc = Clean(Console.ReadLine());
        int points = AskInt(type == "4"
            ? "How many points should this habit cost? "
            : "What is the amount of points associated with this goal? ");

        switch (type)
        {
            case "1": _goals.Add(new SimpleGoal(name, desc, points)); break;
            case "2": _goals.Add(new EternalGoal(name, desc, points)); break;
            case "3":
                int target = AskInt("How many times does this goal need to be accomplished? ");
                int bonus = AskInt("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4": _goals.Add(new NegativeGoal(name, desc, points)); break;
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first.");
            return;
        }
        ListGoals();
        int index = AskInt("Which goal did you accomplish? ") - 1;
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int levelBefore = GetLevel();
        int earned = _goals[index].RecordEvent();
        _score += earned;

        if (earned >= 0)
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
        else
            Console.WriteLine($"Ouch. You lost {-earned} points.");

        if (GetLevel() > levelBefore)
            Console.WriteLine($"*** LEVEL UP! You are now Level {GetLevel()}: {GetTitle()} ***");
        else if (GetLevel() < levelBefore)
            Console.WriteLine("You dropped a level. Keep going, you can win it back!");
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
                writer.WriteLine(g.GetStringRepresentation());
        }
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split('|');
            switch (p[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(p[1], p[2], int.Parse(p[3]),
                        int.Parse(p[5]), int.Parse(p[4]), int.Parse(p[6])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(p[1], p[2], int.Parse(p[3])));
                    break;
            }
        }
        Console.WriteLine("Goals loaded.");
    }
}