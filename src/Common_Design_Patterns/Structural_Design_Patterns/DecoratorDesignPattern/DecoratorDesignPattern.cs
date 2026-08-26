// Decorator Design Pattern is a structural design pattern that lets you attach new behaviours
// to an object dynamically by wrapping it inside special wrapper objects (decorators),
// without altering the structure or behaviour of other objects of the same class.

// Common use case is a coffee shop where a base beverage (Espresso, HouseBlend etc.)
// can be wrapped with add-ons (Milk, Sugar, Whip etc.), each adding its own cost and description
// so we implement the common use case here to understand the decorator design pattern


public interface IBeverage
{
    string GetDescription();
    double GetCost();
}

public class Espresso : IBeverage
{
    public string GetDescription() => "Espresso";
    public double GetCost() => 1.5;
}

public class HouseBlend : IBeverage
{
    public string GetDescription() => "House Blend Coffee";
    public double GetCost() => 1.0;
}

public abstract class BeverageDecorator : IBeverage
{
    protected IBeverage beverage;

    protected BeverageDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }

    public abstract string GetDescription();
    public abstract double GetCost();
}

public class MilkDecorator : BeverageDecorator
{
    public MilkDecorator(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => beverage.GetDescription() + ", Milk";
    public override double GetCost() => beverage.GetCost() + 0.5;
}

public class SugarDecorator : BeverageDecorator
{
    public SugarDecorator(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => beverage.GetDescription() + ", Sugar";
    public override double GetCost() => beverage.GetCost() + 0.2;
}

public class WhipDecorator : BeverageDecorator
{
    public WhipDecorator(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => beverage.GetDescription() + ", Whip";
    public override double GetCost() => beverage.GetCost() + 0.7;
}

public class Program
{
    public static void Main(string[] args)
    {
        IBeverage beverage = new Espresso();
        beverage = new MilkDecorator(beverage);
        beverage = new SugarDecorator(beverage);

        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        IBeverage beverage2 = new HouseBlend();
        beverage2 = new WhipDecorator(beverage2);

        Console.WriteLine($"{beverage2.GetDescription()} : {beverage2.GetCost()}");
    }
}

// this is a simple example of decorator design pattern where each decorator wraps
// a beverage and adds its own cost and description on top of it, allowing add-ons
// to be combined in any order and any number without creating a new subclass for every combination
//              IBeverage
//                 │
//       ┌─────────┼─────────┐
//       ↓                   ↓
//  Espresso           BeverageDecorator
//  HouseBlend               │
//                  ┌────────┼────────┐
//                  ↓        ↓        ↓
//               Milk     Sugar     Whip
//             Decorator Decorator Decorator 