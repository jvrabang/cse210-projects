using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeJournalActivity : Activity
{
    private string[] _gratitudePrompts = {
        "What are you grateful for in your family?",
        "List three things you appreciate about your job or studies.",
        "Reflect on a friend who has positively impacted your life.",
        "What aspects of your health are you thankful for?",
        "Think about a recent positive experience that brought you joy."
    };

    public GratitudeJournalActivity() : base("Gratitude Journal", "Reflect on the positive aspects of your life by listing things you are grateful for.")
    {
    }

    protected override void Run()
    {
        base.Run();

        Random random = new Random();
        string randomPrompt = _gratitudePrompts[random.Next(_gratitudePrompts.Length)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        PauseWithSpinner(2);

        Console.WriteLine("Start listing things you are grateful for. Press Enter after each item:");

        DateTime startTime = DateTime.Now;
        int itemCount = 0;

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            string item = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(item))
            {
                Console.WriteLine("Item cannot be empty. Please enter a valid item.");
                continue;
            }

            itemCount++;
            Console.WriteLine("Item added.");
        }

        Console.WriteLine($"You expressed gratitude for {itemCount} things within the specified duration of {_duration} seconds.");
    }
}
