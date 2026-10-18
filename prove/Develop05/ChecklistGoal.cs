public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points,
                         int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;
        _amountCompleted++;
        return IsComplete() ? Points + _bonus : Points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
        => $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";

    public override string GetStringRepresentation()
        => $"ChecklistGoal|{Name}|{Description}|{Points}|{_bonus}|{_target}|{_amountCompleted}";
}