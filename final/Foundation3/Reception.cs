public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullDetails()
    {
        return $"Full Details:\n{base.GenerateFullDetails()}\nType: Reception\nRSVP Email: {_rsvpEmail}";
    }

    public override string GenerateShortDescription()
    {
        return $"Short Description: Reeption -{base.GenerateShortDescription()}";
    }
}

