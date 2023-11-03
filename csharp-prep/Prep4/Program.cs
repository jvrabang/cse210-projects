using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbersList = new List<int>();
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a list of numbers, type 0 when finished: ");
            
            string numberFromUser = Console.ReadLine();
            userNumber = int.Parse(numberFromUser);
            
            if (userNumber != 0)
            {
                numbersList.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbersList)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbersList.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbersList[0];

        foreach (int number in numbersList)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");
    }
}