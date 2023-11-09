using System;

// Interface for beverages
public interface IBeverage
{
    string GetDescription();
    double Cost();
}

// Concrete implementation of a HouseBlend coffee
public class HouseBlend : IBeverage
{
    public string GetDescription()
    {
        return "House Blend Coffee";
    }

    public double Cost()
    {
        return 1.80;
    }
}

// Concrete implementation of DarkRoast coffee
public class DarkRoast : IBeverage
{
    public string GetDescription()
    {
        return "Dark Roast Coffee";
    }

    public double Cost()
    {
        return 2.20;
    }
}

// Concrete implementation of Decaf coffee
public class Decaf : IBeverage
{
    public string GetDescription()
    {
        return "Decaf Coffee";
    }

    public double Cost()
    {
        return 2.00;
    }
}

// Concrete implementation of Espresso coffee
public class Espresso : IBeverage
{
    public string GetDescription()
    {
        return "Espresso";
    }

    public double Cost()
    {
        return 2.90;
    }
}

// Abstract decorator class
public abstract class CondimentDecorator : IBeverage
{
    protected IBeverage _beverage;

    public CondimentDecorator(IBeverage beverage)
    {
        _beverage = beverage;
    }

    public virtual string GetDescription()
    {
        return _beverage.GetDescription();
    }

    public abstract double Cost();
}

// Concrete decorator for steamed milk
public class SteamedMilk : CondimentDecorator
{
    public SteamedMilk(IBeverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return $"{_beverage.GetDescription()}, Steamed Milk";
    }

    public override double Cost()
    {
        return _beverage.Cost() + 0.30;
    }
}

// Concrete decorator for mocha
public class Mocha : CondimentDecorator
{
    public Mocha(IBeverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return $"{_beverage.GetDescription()}, Mocha";
    }

    public override double Cost()
    {
        return _beverage.Cost() + 0.60;
    }
}

// Concrete decorator for soy
public class Soy : CondimentDecorator
{
    public Soy(IBeverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return $"{_beverage.GetDescription()}, Soy";
    }

    public override double Cost()
    {
        return _beverage.Cost() + 0.45;
    }
}

// Concrete decorator for whipped cream
public class WhippedCream : CondimentDecorator
{
    public WhippedCream(IBeverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return $"{_beverage.GetDescription()}, Whipped Cream";
    }

    public override double Cost()
    {
        return _beverage.Cost() + 0.30;
    }
}

// Main program for testing
internal class Program
{
    static void Main(string[] args)
    {
        // Creating a HouseBlend coffee
        IBeverage houseBlend = new HouseBlend();
        Console.WriteLine($"Description: {houseBlend.GetDescription()}, Cost: ${houseBlend.Cost()}");

        // Adding steamed milk to the HouseBlend
        houseBlend = new SteamedMilk(houseBlend);
        Console.WriteLine($"Description: {houseBlend.GetDescription()}, Cost: ${houseBlend.Cost()}");

        // Adding mocha to the HouseBlend with steamed milk
        houseBlend = new Mocha(houseBlend);
        Console.WriteLine($"Description: {houseBlend.GetDescription()}, Cost: ${houseBlend.Cost()}");

        // Creating an Espresso with soy
        IBeverage espressoWithSoy = new Soy(new Espresso());
        Console.WriteLine($"Description: {espressoWithSoy.GetDescription()}, Cost: ${espressoWithSoy.Cost()}");
    }
}
