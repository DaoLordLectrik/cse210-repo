using System;

public class Activity
{
    private DateTime date;
    private int durationInMinutes;

    public Activity(DateTime date, int durationInMinutes)
    {
        this.date = date;
        this.durationInMinutes = durationInMinutes;
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
        return $"{date.ToShortDateString()} {GetType().Name} ({durationInMinutes} min)";
    }
}

public class Running : Activity
{
    private double distance; // in miles
    public double Distance { get => distance; set => distance = value; }

    public Running(DateTime date, int durationInMinutes, double distance) : base(date, durationInMinutes)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (durationInMinutes / 60); // miles per hour
    }

    public override double GetPace()
    {
        return durationInMinutes / Distance; // minutes per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {Distance} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}

public class Cycling : Activity
{
    private double speed; // in mph
    public double Speed { get => speed; set => speed = value; }

    public Cycling(DateTime date, int durationInMinutes, double speed) : base(date, durationInMinutes)
    {
        Speed = speed;
    }

    public override double GetSpeed()
    {
        return Speed;
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
    private int laps;

    public Swimming(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / (durationInMinutes / 60); // miles per hour
    }

    public override double GetPace()
    {
        return durationInMinutes / GetDistance(); // minutes per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {GetDistance():0.00} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
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
