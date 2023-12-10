using System;

[Serializable]
abstract class Goal
{
    public string Name { get; }
    public string Description { get; }
    public bool Completed { get; protected set; }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
        Completed = false;
    }

    public abstract int GetPoints();
    public abstract string GetStringRepresentation();
    public abstract Goal CreateGoalFromString(string goalString);
}
