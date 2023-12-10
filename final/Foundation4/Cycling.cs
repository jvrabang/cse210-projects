using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed; // Invert speed to get pace
    }

    public override string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} - Cycling ({_minutes} min) - Speed {_speed:F1} kph, Pace: {GetPace():F2} min per km";
    }
}
