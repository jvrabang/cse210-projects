using System;

class Program
{
    static void Main()
    {
        EternalQuest eternalQuest = new EternalQuest();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            string choice;
            do
            {
                Console.Write("Select an option: ");
                choice = Console.ReadLine();

                if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                }

            } while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6");

            switch (choice)
            {
                case "1":
                    CreateNewGoal(eternalQuest);
                    break;
                case "2":
                    eternalQuest.DisplayGoals();
                    break;
                case "3":
                    Console.Write("Enter file name to save goals: ");
                    string saveFileName = Console.ReadLine();
                    eternalQuest.SaveProgress(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter file name to load goals: ");
                    string loadFileName = Console.ReadLine();
                    eternalQuest.LoadProgress(loadFileName);
                    break;
                case "5":
                    eternalQuest.RecordEvent();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewGoal(EternalQuest eternalQuest)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string goalTypeChoice;
        do
        {
            Console.Write("Enter your choice: ");
            goalTypeChoice = Console.ReadLine();

            if (goalTypeChoice != "1" && goalTypeChoice != "2" && goalTypeChoice != "3")
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }

        } while (goalTypeChoice != "1" && goalTypeChoice != "2" && goalTypeChoice != "3");

        Console.Write("Enter the name of the goal: ");
        string goalName = Console.ReadLine();

        Console.Write("Enter a short description of the goal: ");
        string goalDescription = Console.ReadLine();

        switch (goalTypeChoice)
        {
            case "1":
                Console.Write("Enter the points associated with this goal: ");
                int simpleGoalPoints = int.Parse(Console.ReadLine());
                eternalQuest.AddGoal(new SimpleGoal(goalName, goalDescription, simpleGoalPoints));
                break;
            case "2":
                Console.Write("Enter the points associated with this goal: ");
                int eternalGoalPoints = int.Parse(Console.ReadLine());
                eternalQuest.AddGoal(new EternalGoal(goalName, goalDescription, eternalGoalPoints));
                break;
            case "3":
                Console.Write("Enter the number of times this goal needs to be accomplished: ");
                int totalRequired = int.Parse(Console.ReadLine());

                Console.Write("Enter the points associated with each completion: ");
                int checklistGoalPoints = int.Parse(Console.ReadLine());

                Console.Write("Enter the bonus points if completed: ");
                int bonusPoints = int.Parse(Console.ReadLine());

                eternalQuest.AddGoal(new ChecklistGoal(goalName, goalDescription, totalRequired, checklistGoalPoints, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                break;
        }
    }
}
