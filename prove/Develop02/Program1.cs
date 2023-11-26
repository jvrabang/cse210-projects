using System;
using System.Collections.Generic;
using System.IO;

class Program1
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomPrompt = GetRandomPrompt();
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    Console.WriteLine("Enter your response to the prompt:");
                    string response = Console.ReadLine();
                    Console.WriteLine("Enter your mood or emotional state:");
                    string mood = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(randomPrompt, response, date, mood);
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal loaded successfully.");
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is a new skill or hobby I want to explore?",
            "Write about a book or movie that left a lasting impression on me.",
            "If I could travel anywhere in the world, where would I go and why?",
            "Describe a goal I want to achieve in the next month.",
            "Reflect on a challenge I overcame recently and what I learned from it.",
            "What are three things I'm grateful for today?",
            "If I could have dinner with any historical figure, who would it be and what would we talk about?",
            "What is a quote or mantra that inspires me?",
            "Write about a random act of kindness I witnessed or experienced today.",
            "If I could have any superpower, what would it be and how would I use it?",
            "Describe a moment when I felt proud of myself.",
            "Reflect on a mistake I made and what I learned from it.",
            "What is a small, achievable goal I can set for tomorrow?",
            "If I could relive one day of my life, which day would it be and why?",
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}