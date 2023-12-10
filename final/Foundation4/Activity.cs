using System;

public class Activity
{
    protected DateTime _date;
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Default implementation for activities without specific distance calculation
    }

    public virtual double GetSpeed()
    {
        return 0; // Default implementation for activities without specific speed calculation
    }

    public virtual double GetPace()
    {
        return 0; // Default implementation for activities without specific pace calculation
    }

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} - Unknown Activity ({_minutes} min)";
    }
}
