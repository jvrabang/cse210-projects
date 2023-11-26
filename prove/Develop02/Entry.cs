using System;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; }

    public Entry(string prompt, string response, string date, string mood)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Mood = mood;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine("---------------------------");
    }
}
