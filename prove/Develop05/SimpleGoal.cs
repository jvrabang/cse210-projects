[Serializable]
class SimpleGoal : Goal
{
    private int _points;

    public SimpleGoal(string name, string description, int points) : base(name, description)
    {
        _points = points;
    }

    public override int GetPoints()
    {
        Completed = true;
        return _points;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{_points},{Completed}";
    }

    public override Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(',');

        if (parts[0] == "SimpleGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool completed = bool.Parse(parts[4]);

            var goal = new SimpleGoal(name, description, points);
            goal.Completed = completed;
            return goal;
        }

        throw new ArgumentException("Invalid goal string format for SimpleGoal");
    }
}
