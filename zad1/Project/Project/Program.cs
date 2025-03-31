namespace Project;

public interface IHazardNotifier
{
    void Notify(string message);
}

public abstract class Container
{
    private static int counter = 0;
    public string serialNumber { get; set; }
    public double ownWeight { get; set; }
    public double height { get; set; }
    public double maxLoad { get; set; }
    public double currentLoad { get; set; }

    protected Container(String type, double ownWeight, double height, double maxLoad)
    {
        this.ownWeight = ownWeight;
        this.height = height;
        this.maxLoad = maxLoad;
        currentLoad = 0;
        serialNumber = $"KON-{type}-{++counter}";
    }

    public virtual void Load(double weight)
    {
        if (currentLoad + weight > maxLoad)
            throw new OverfillException($"Overfill error in {serialNumber}");

        currentLoad += weight;
    }

    public virtual void Unload()
    {
        currentLoad = 0;
    }
}

public class LiquidContainer : Container, IHazardNotifier
{
    public bool hazard { get; }

    public LiquidContainer(double ownWeight, double height, double maxLoad, bool hazard) : base("L", ownWeight, height,
        maxLoad)
    {
        this.hazard = hazard;
    }

    public override void Load(double weight)
    {
        double maxAllowed = hazard ? maxLoad * 0.5 : maxLoad * 0.9;
        if (weight > maxAllowed)
        {
            Notify($"You cannot add too much to container {serialNumber}");
            throw new OverfillException("Danger, danger, danger");
        }

        base.Load(weight);
    }

    public void Notify(string message)
    {
        Console.WriteLine($"DANGER: {message}");
    }
}

public class GasContainer : Container, IHazardNotifier
{
    public double pressure { get; }

    public GasContainer(double ownWeight, double height, double maxLoad, double pressure) : base("G", ownWeight, height,
        maxLoad)
    {
        this.pressure = pressure;
    }

    public override void Unload()
    {
        currentLoad *= 0.05;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"DANGER: {message}");
    }
}

public class RefrigeratedContainer : Container, IHazardNotifier
{
    private static readonly Dictionary<string, double> Requirements = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public string productType { get; set; }
    public double temperature { get; set; }

    public RefrigeratedContainer(double ownWeight, double height, double maxLoad, string productType,
        double temperature) : base("C", ownWeight, height, maxLoad)
    {
        if (!Requirements.ContainsKey(productType))
        {
            Notify("Danger, danger, danger");
            throw new ArgumentException($"Cannot add this type ->: {productType}");
        }

        if (temperature < Requirements[productType])
        {
            Notify("Danger, danger, danger");
            throw new ArgumentException(
                $"Temperature for {productType} cannot be lower than {Requirements[productType]}°C");
        }

        this.productType = productType;
        this.temperature = temperature;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"DANGER: {message}");
    }
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}

public class Ship
{
    public List<Container> containers { get; set; } = [];
    public double maxSpeed { get; set; }
    public int maxQuantity { get; set; }
    public double maxWeight { get; set; }

    public Ship(double maxSpeed, int maxQuantity, double maxWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxQuantity = maxQuantity;
        this.maxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (containers.Count >= maxQuantity)
            throw new OverfillException("Too many containers.");
        if (getWeight() + container.maxLoad > maxWeight * 1000) //tons need to be changed into kg
            throw new OverfillException("Too heavy!!!!");

        containers.Add(container);
    }

    private double getWeight()
    {
        double totalWeight = 0;
        foreach (var container in containers)
        {
            totalWeight += container.maxLoad;
        }

        return totalWeight;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            GasContainer gasContainer = new GasContainer(100, 100, 300, 100);
            gasContainer.Load(200);
            Ship ship = new Ship(25, 10, 10000);
            ship.LoadContainer(gasContainer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}