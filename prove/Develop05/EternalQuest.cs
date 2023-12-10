using System;
using System.Collections.Generic;
using System.IO;

class EternalQuest
{
    private List<Goal> _goals;
    private int _totalScore;

    public EternalQuest()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name} ({_goals[i].Description}) {((_goals[i] is ChecklistGoal) ? ((_goals[i] as ChecklistGoal).GetProgress()) : "")}");
        }

        Console.Write("Enter the number of the goal you completed: ");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int selectedGoalNumber) && selectedGoalNumber >= 1 && selectedGoalNumber <= _goals.Count)
        {
            Goal selectedGoal = _goals[selectedGoalNumber - 1];

            if (!selectedGoal.Completed)
            {
                int pointsEarned = selectedGoal.GetPoints();
                _totalScore += pointsEarned;

                if (selectedGoal is ChecklistGoal checklistGoal)
                {
                    checklistGoal.RecordProgress();
                }

                Console.WriteLine($"Event recorded for goal: {selectedGoal.Name}");
                Console.WriteLine($"Points earned: {pointsEarned}");
                Console.WriteLine($"Total points: {_totalScore}\n");
            }
            else
            {
                Console.WriteLine("Selected goal is already completed. Event not recorded.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.\n");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {(_goals[i].Completed ? "[X]" : "[ ]")} {_goals[i].Name} ({_goals[i].Description}) {((_goals[i] is ChecklistGoal) ? ((_goals[i] as ChecklistGoal).GetProgress()) : "")}");
        }

        Console.WriteLine($"Total Score: {_totalScore}\n");
    }

    public void SaveProgress(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"TotalScore:{_totalScore}");

                foreach (Goal goal in _goals)
                {
                    string goalString = goal.GetStringRepresentation();
                    writer.WriteLine(goalString);
                }
            }

            Console.WriteLine($"Progress saved to {fileName}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving progress: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
            }
            Console.WriteLine();
        }
    }

    public void LoadProgress(string fileName)
    {
        try
        {
            List<Goal> loadedGoals = new List<Goal>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string totalScoreLine = reader.ReadLine();
                if (totalScoreLine != null && totalScoreLine.StartsWith("TotalScore:"))
                {
                    _totalScore = int.Parse(totalScoreLine.Substring("TotalScore:".Length));
                }

                while (!reader.EndOfStream)
                {
                    string goalString = reader.ReadLine();
                    string[] parts = goalString.Split(',');

                    if (parts.Length >= 2)
                    {
                        string goalType = parts[0];
                        string goalData = parts[1];

                        Goal goal;
                        switch (goalType)
                        {
                            case "SimpleGoal":
                                goal = new SimpleGoal("", "", 0);
                                goal = goal.CreateGoalFromString(goalData);
                                break;
                            case "EternalGoal":
                                goal = new EternalGoal("", "", 0);
                                goal = goal.CreateGoalFromString(goalData);
                                break;
                            case "ChecklistGoal":
                                goal = new ChecklistGoal("", "", 0, 0, 0);
                                goal = goal.CreateGoalFromString(goalData);
                                break;
                            default:
                                throw new ArgumentException($"Unknown goal type: {goalType}");
                        }

                        loadedGoals.Add(goal);
                    }
                }
            }

            _goals = loadedGoals;

            Console.WriteLine($"Progress loaded from {fileName}\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Save file not found. Creating a new progress instance.\n");
            _goals = new List<Goal>();
            _totalScore = 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading progress: {ex.Message}\n");
            _goals = new List<Goal>();
            _totalScore = 0;
        }
    }
}
