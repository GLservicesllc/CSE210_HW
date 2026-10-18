public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, penalty) { }

    public override int RecordEvent() => -Points;

    public override bool IsComplete() => false;

    public override string GetDetailsString()
        => $"[!] {Name} ({Description}) -- Costs {Points} points";

    public override string GetStringRepresentation()
        => $"NegativeGoal|{Name}|{Description}|{Points}";
}