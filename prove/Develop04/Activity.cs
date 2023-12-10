using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void PerformActivity()
    {
        DisplayStartingMessage();
        PauseWithSpinner(3);

        Run();

        DisplayEndingMessage();
        PauseWithSpinner(3);
    }

    protected virtual void Run()
    {
        Console.WriteLine($"{_name} activity is running for {_duration} seconds.");
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity: {_description}");
        Console.Write($"Enter duration in seconds for {_name} activity: ");
        _duration = int.Parse(Console.ReadLine());
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed the {_name} activity for {_duration} seconds.");
    }

    protected void PauseWithSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
