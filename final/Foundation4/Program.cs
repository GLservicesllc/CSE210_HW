using System;
using System.Collections.Generic;

public class Exercise
{
    private DateTime _date;
    private int _minutes;

    public Exercise(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} Exercise";
    }
}

public class Running : Exercise
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / GetMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance;
    }

    public override string GetSummary()
    {
        return $"{GetDate():dd MMM yyyy} Running " +
               $"({GetMinutes()} min) - " +
               $"Distance: {GetDistance():0.00} km, " +
               $"Speed: {GetSpeed():0.00} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }
}

public class Cycling : Exercise
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * GetMinutes() / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetSummary()
    {
        return $"{GetDate():dd MMM yyyy} Cycling " +
               $"({GetMinutes()} min) - " +
               $"Distance: {GetDistance():0.00} km, " +
               $"Speed: {GetSpeed():0.00} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }
}

public class Swimming : Exercise
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000;
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{GetDate():dd MMM yyyy} Swimming " +
               $"({GetMinutes()} min) - " +
               $"Distance: {GetDistance():0.00} km, " +
               $"Speed: {GetSpeed():0.00} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }
}

public class Program
{
    public static void Main()
    {
        List<Exercise> exercises = new List<Exercise>();

        exercises.Add(new Running(
            new DateTime(2026, 10, 1),
            30,
            5.0));

        exercises.Add(new Cycling(
            new DateTime(2026, 10, 2),
            45,
            20.0));

        exercises.Add(new Swimming(
            new DateTime(2026, 10, 3),
            40,
            30));

        foreach (Exercise exercise in exercises)
        {
            Console.WriteLine(exercise.GetSummary());
        }
    }
}