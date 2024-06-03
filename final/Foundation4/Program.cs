using System;

public class Activity
{
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }

    public Activity(DateTime date, int durationInMinutes)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class does not have distance
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class does not have speed
    }

    public virtual double GetPace()
    {
        return 0; // Base class does not have pace
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} {GetType().Name} ({DurationInMinutes} min)";
    }
}

public class Running : Activity
{
    public double Distance { get; set; }

    public Running(DateTime date, int durationInMinutes, double distance) : base(date, durationInMinutes)
    {
        Distance = distance;
    }

    public override double GetSpeed()
    {
        return Distance / (DurationInMinutes / 60); // miles per hour
    }

    public override double GetPace()
    {
        return DurationInMinutes / Distance; // minutes per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {Distance} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}

public class Cycling : Activity
{
    public double Speed { get; set; }

    public Cycling(DateTime date, int durationInMinutes, double speed) : base(date, durationInMinutes)
    {
        Speed = speed;
    }

    public override double GetPace()
    {
        return 60 / Speed; // minutes per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Speed: {Speed:0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}

public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000; // kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / (DurationInMinutes / 60); // kilometers per hour
    }

    public override double GetPace()
    {
        return DurationInMinutes / GetDistance(); // minutes per kilometer
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {GetDistance():0.00} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Activity running = new Running(new DateTime(2024, 11, 3), 30, 3.0);
        Activity cycling = new Cycling(new DateTime(2024, 11, 4), 45, 12.0);
        Activity swimming = new Swimming(new DateTime(2024, 11, 5), 60, 20);

        Activity[] activities = { running, cycling, swimming };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
