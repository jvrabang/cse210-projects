using System;

class Program
{
    static void Main()
    {
        var randomScripture = RandomScripture.GetRandomScripture();
        Scripture scripture = new Scripture(randomScripture);
        MemorizationHelper memorizationHelper = new MemorizationHelper(scripture);

        Console.WriteLine("Welcome to Scripture Memorization Program!");
        Console.WriteLine();
        Console.WriteLine(scripture.GetVisibleText());
        Console.WriteLine();
        Console.WriteLine("Press Enter to hide words, type 'quit' to exit.");

        string userInput;
        while (!memorizationHelper.AllWordsHidden)
        {
            userInput = Console.ReadLine().ToLower();
            if (userInput == "quit")
            {
                break;
            }

            memorizationHelper.HideRandomWords();
            Console.Clear();
            Console.WriteLine(memorizationHelper.GetVisibleScripture());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words, type 'quit' to exit.");
        }

        Console.WriteLine("Program ended. Press any key to exit.");
        Console.ReadKey();
    }
}