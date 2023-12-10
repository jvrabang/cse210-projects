using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2023, 12, 03), 100, 3.0));
        activities.Add(new Running(new DateTime(2023, 12, 04), 50, 4.8));
        activities.Add(new Cycling(new DateTime(2023, 12, 04), 65, 20.5));
        activities.Add(new Swimming(new DateTime(2023, 12, 05), 10, 15));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
