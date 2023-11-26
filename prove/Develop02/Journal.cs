using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date, string mood)
    {
        Entry newEntry = new Entry(prompt, response, date, mood);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response},{entry.Mood}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                if (parts.Length == 4)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    string mood = parts[3];
                    AddEntry(prompt, response, date, mood);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
