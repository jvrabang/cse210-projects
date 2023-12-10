using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "Reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void Run()
    {
        base.Run();

        string reflectionPrompt = GetRandomPrompt();
        Console.WriteLine(reflectionPrompt);

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        int remainingTime = _duration;

        while (remainingTime > 0)
        {
            Console.Clear(); 

            foreach (var question in _reflectionQuestions)
            {
                if (remainingTime <= 0)
                {
                    break;
                }

                Console.WriteLine(question);
        
                Console.Write("Time remaining: ");
                Countdown(10);

                remainingTime -= 10;
            }
        }

        Console.WriteLine("Reflection activity completed.");
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_reflectionPrompts.Count);
        return _reflectionPrompts[index];
    }

    private void Countdown(int seconds)
    {
        int cursorLeft = Console.CursorLeft;

        for (int i = seconds; i > 0; i--)
        {
            try
            {
                Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                Console.Write($". . . {i} ");
                Thread.Sleep(1000);
            }
            catch (ArgumentOutOfRangeException)
            {
                break;
            }
        }

        Console.WriteLine();
    }
}