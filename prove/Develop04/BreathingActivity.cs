using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "Relax by walking through breathing in and out slowly.")
    {
    }

    protected override void Run()
    {
        base.Run();

        int totalBreathDuration = (int)Math.Ceiling((double)_duration / 6);
        int countdownSeconds = 3;

        for (int i = 0; i < totalBreathDuration; i++)
        {
            Console.Write("Breathe in . . . ");
            Countdown(countdownSeconds);

            Console.Write("Breathe out . . . ");
            Countdown(countdownSeconds);
        }

        Console.WriteLine("Done Breathing.");
    }

    private void Countdown(int seconds)
    {
        int cursorLeft = Console.CursorLeft;
        for (int i = seconds; i > 0; i--)
        {
            try
            {
                Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                Console.Write($"{i} "); 
                Thread.Sleep(1000); 
            }
            catch (ArgumentOutOfRangeException)
            {
                break;
            }
        }

        Console.WriteLine();
    }
}
