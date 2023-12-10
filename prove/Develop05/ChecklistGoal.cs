using System;

[Serializable]
class ChecklistGoal : Goal
{
    private int _incrementalPoints;
    private int _totalRequired;
    private int _bonusPoints;
    private int _currentProgress;

    public ChecklistGoal(string name, string description, int totalRequired, int incrementalPoints, int bonusPoints) : base(name, description)
    {
        _totalRequired = totalRequired;
        _incrementalPoints = incrementalPoints;
        _bonusPoints = bonusPoints;
        _currentProgress = 0;
    }

    public void RecordProgress()
    {
        _currentProgress++;

        if (_currentProgress >= _totalRequired && !Completed)
        {
            Completed = true;
            DisplayCongratulatoryMessage();
        }
    }

    private void DisplayCongratulatoryMessage()
    {
        Console.WriteLine($"Congratulations! Goal '{Name}' completed!");
        Console.WriteLine($"You earned {_incrementalPoints + _bonusPoints} points, including a bonus of {_bonusPoints} points!");
    }

    public override int GetPoints()
    {
        if (Completed)
        {
            return _incrementalPoints + _bonusPoints;
        }

        return _incrementalPoints;
    }


    public string GetProgress()
    {
        return $"Currently completed {_currentProgress}/{_totalRequired}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{_totalRequired},{_incrementalPoints},{_bonusPoints},{_currentProgress}";
    }

    public override Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(',');

        if (parts.Length == 7 && parts[0] == "ChecklistGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int totalRequired = int.Parse(parts[3]);
            int incrementalPoints = int.Parse(parts[4]);
            int bonusPoints = int.Parse(parts[5]);
            int currentProgress = int.Parse(parts[6]);

            var goal = new ChecklistGoal(name, description, totalRequired, incrementalPoints, bonusPoints);
            goal._currentProgress = currentProgress;
            return goal;
        }

        throw new ArgumentException("Invalid goal string format for ChecklistGoal");
    }
}
