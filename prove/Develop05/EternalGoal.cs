using System;

[Serializable]
class EternalGoal : Goal
{
    private int _points;

    public EternalGoal(string name, string description, int points) : base(name, description)
    {
        _points = points;
    }

    public override int GetPoints()
    {
        return _points;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name},{Description},{_points},{Completed}";
    }

    public override Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(',');

        if (parts.Length == 4 && parts[0] == "EternalGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool completed = bool.Parse(parts[4]);

            return new EternalGoal(name, description, points) { Completed = completed };
        }

        throw new ArgumentException("Invalid goal string format for EternalGoal");
    }
}
