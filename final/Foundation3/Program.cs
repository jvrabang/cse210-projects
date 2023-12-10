using System;

class Program
{
    static void Main()
    {
        Address address = new Address("88th Bonifacio", "Hope City", "UT", "USA");

        Lecture lecture = new Lecture("Learn Fintech", "Rule of Fintech in the Accounting Industry", "2024-02-17", "11:00", address, "John Vincent", 50);
        Reception reception = new Reception("J&J Wedding", "Wedding of the Jared and Janet", "2023-12-25", "17:30", address, "rsvp@byui.edu");
        OutdoorGathering gathering = new OutdoorGathering("Year End Party", "Let's celebrate our success for 2023", "2023-12-30", "12:00", address, "Expect sunny weather!");

        DisplayEventDetails(lecture);
        Console.WriteLine("\n-----------------------------------\n");
        DisplayEventDetails(reception);
        Console.WriteLine("\n-----------------------------------\n");
        DisplayEventDetails(gathering);
    }

    static void DisplayEventDetails(Event ev)
    {
        Console.WriteLine(ev.GenerateStandardDetails());
        Console.WriteLine("\n-----------------------------------\n");
        Console.WriteLine(ev.GenerateFullDetails());
        Console.WriteLine("\n-----------------------------------\n");
        Console.WriteLine(ev.GenerateShortDescription());
        Console.WriteLine("\n===================================\n");
    }
}
