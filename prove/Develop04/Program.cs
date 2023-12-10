class Program
{
    static void Main()
    {
        Console.WriteLine("Mindfulness Program");

        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Journal Activity"); // New activity to exceed core requirements
            Console.WriteLine("5. Exit");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }

            if (choice == 5)
            {
                break;
            }

            Activity activity = GetSelectedActivity(choice);
            activity.PerformActivity();
        }
    }

    static Activity GetSelectedActivity(int choice)
    {
        switch (choice)
        {
            case 1:
                return new BreathingActivity();
            case 2:
                return new ReflectionActivity();
            case 3:
                return new ListingActivity();
            case 4:
                return new GratitudeJournalActivity(); // New activity
            default:
                throw new ArgumentException("Invalid choice");
        }
    }
}
