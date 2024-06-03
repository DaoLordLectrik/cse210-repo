using System;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

public class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public Address Address { get; set; }

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Event\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity) 
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

public class Reception : Event
{
    public string RsvpEmail { get; set; }

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail) 
        : base(title, description, date, time, address)
    {
        RsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Reception\nRSVP Email: {RsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast) 
        : base(title, description, date, time, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("Market Downtown", "Market Town", "CA", "USA");
        Lecture lecture = new Lecture("Lectures on python", "Introduction to python", DateTime.Now.AddDays(10), "10:07 AM", address1, "Marthias Zuma", 50);
        
        Address address2 = new Address("Nim Trees St", "Fresh Town", "ON", "Canada");
        Reception reception = new Reception("Networking Friends", "Networking event for friends", DateTime.Now.AddDays(15), "9:58 PM", address2, "net@working.com");
        
        Address address3 = new Address("broadway street", "Night life city", "NY", "USA");
        OutdoorGathering gathering = new OutdoorGathering("Picnic in the Park", "Community picnic event", DateTime.Now.AddDays(20), "1:00 PM", address3, "New Road");

        Console.WriteLine("Marketing Messages:");
        Console.WriteLine("---------------");
        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("---------------");
        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("---------------");
        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(gathering.GetFullDetails());
    }
}
