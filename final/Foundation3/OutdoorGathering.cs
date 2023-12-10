public class OutdoorGathering : Event
{
    private string _weatherStatement;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        _weatherStatement = weatherStatement;
    }

    public override string GenerateFullDetails()
    {
        return $"Full Details:\n{base.GenerateFullDetails()}\nType: Outdoor Gathering\nWeather: {_weatherStatement}";
    }

    public override string GenerateShortDescription()
    {
        return $"Short Description: Outdoor Gathering -{base.GenerateShortDescription()}";
    }
}
