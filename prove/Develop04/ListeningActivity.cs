using System;
using System.Threading;

public class ListingActivity : Activity
{
    private string[] _listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "Reflect on the good things in your life by listing as many things as you can in a certain area.")
    {
    }

    protected override void Run()
    {
        base.Run();

        Random random = new Random();
        string randomPrompt = _listingPrompts[random.Next(_listingPrompts.Length)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        PauseWithSpinner(2);

        Console.WriteLine("Start listing items. Press Enter after each item:");

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

        Console.WriteLine($"You listed {itemCount} items within the specified duration of {_duration} seconds.");
    }
}
