using System;

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

public class Event
{
    private string _title;
    private string _description;
    private DateTime _date;
    private string _time;
    private Address _address;

    public Event(
        string title,
        string description,
        DateTime date,
        string time,
        Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Date: {_date:MMMM dd, yyyy}\n" +
               $"Time: {_time}\n" +
               $"Address:\n{_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event: {_title} on {_date:MMMM dd, yyyy}";
    }
}

public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(
        string title,
        string description,
        DateTime date,
        string time,
        Address address,
        string speakerName,
        int capacity)
        : base(title, description, date, time, address)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() +
               $"\nEvent Type: Lecture" +
               $"\nSpeaker: {_speakerName}" +
               $"\nCapacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Lecture: {_speakerName} - {base.GetShortDescription()}";
    }
}

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(
        string title,
        string description,
        DateTime date,
        string time,
        Address address,
        string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() +
               $"\nEvent Type: Reception" +
               $"\nRSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception - {base.GetShortDescription()}";
    }
}

public class OutdoorGathering : Event
{
    private string _weatherStatement;

    public OutdoorGathering(
        string title,
        string description,
        DateTime date,
        string time,
        Address address,
        string weatherStatement)
        : base(title, description, date, time, address)
    {
        _weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() +
               $"\nEvent Type: Outdoor Gathering" +
               $"\nWeather: {_weatherStatement}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering - {base.GetShortDescription()}";
    }
}

public class Program
{
    public static void Main()
    {
        Address lectureAddress = new Address(
            "123 College Avenue",
            "Provo",
            "UT",
            "USA");

        Lecture lecture = new Lecture(
            "Programming with Classes",
            "A lecture about object-oriented programming.",
            new DateTime(2026, 11, 5),
            "6:00 PM",
            lectureAddress,
            "Professor Smith",
            150);

        Address receptionAddress = new Address(
            "456 Main Street",
            "Salt Lake City",
            "UT",
            "USA");

        Reception reception = new Reception(
            "Business Networking Reception",
            "A reception for local business professionals.",
            new DateTime(2026, 11, 10),
            "7:00 PM",
            receptionAddress,
            "rsvp@example.com");

        Address outdoorAddress = new Address(
            "789 Mountain Road",
            "Park City",
            "UT",
            "USA");

        OutdoorGathering outdoorGathering = new OutdoorGathering(
            "Community Picnic",
            "A picnic for families and friends.",
            new DateTime(2026, 11, 15),
            "12:00 PM",
            outdoorAddress,
            "Clear skies and mild temperatures.");

        Event[] events =
        {
            lecture,
            reception,
            outdoorGathering
        };

        foreach (Event currentEvent in events)
        {
            Console.WriteLine("STANDARD DETAILS");
            Console.WriteLine(currentEvent.GetStandardDetails());

            Console.WriteLine("\nFULL DETAILS");
            Console.WriteLine(currentEvent.GetFullDetails());

            Console.WriteLine("\nSHORT DESCRIPTION");
            Console.WriteLine(currentEvent.GetShortDescription());

            Console.WriteLine(new string('-', 50));
        }
    }
}