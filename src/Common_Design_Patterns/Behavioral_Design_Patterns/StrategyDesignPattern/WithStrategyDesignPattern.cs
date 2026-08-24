// Strategy Design Pattern is a behavioral design pattern that allows you to define a family of algorithms,
// encapsulate each one, and make them interchangeable.
// This pattern lets the algorithm vary independently from clients that use it.


// here we use strategy design pattern to avoid the duplication of code
// and to avoid modifying the context class to add new behaviour

public interface IEngine
{
    void Engine();
}


public class PassengerEngine:IEngine
{
    public void Engine()
    {
        Console.WriteLine("Passenger Engine is running");
    }

}


public class SportsEngine : IEngine
{
    public void Engine()
    {
        Console.WriteLine("Sports Engine is running");
    }

}



public class Vehicle
{
    private IEngine _engine;  // here we are using the interface to encapsulate the family of interchangble
                              // algorithms behind the common interface and allowing the behaviour to be
                              // decided at runtime without modifiying the context
    public Vehicle(IEngine engine)
    {
        _engine = engine;
    }
    public void Engine()
    {
        _engine.Engine();
    }
}

public class offroadVehicle: Vehicle
{
    public offroadVehicle() : base(new SportsEngine())
    {
    }

}

public class  SportsVehicle: Vehicle
{
    public SportsVehicle() : base(new SportsEngine())
    {
    }

}

public class PassengerVehicle: Vehicle
{
    public PassengerVehicle() : base(new PassengerEngine())
    {
    }

}


public class Program
{
    public static void Main(string[] args)
    {
        Vehicle vehicle = new PassengerVehicle();
        vehicle.Engine();

        Vehicle vehicle1 = new SportsVehicle();
        vehicle1.Engine();

        Vehicle vehicle2 = new OffroadVehicle();
        vehicle2.Engine();
    }
}

// this is correct implementation of strategy design pattern where we are encapsulating
// the family of interchangble algorithms behind
// the common interface and allowing the behaviour to be decided at runtime without modifiying the context
//              IEngine
//                 │
//       ┌─────────┼─────────┐
//       ↓         ↓         ↓
//  Passenger Sports     Offroad
//  Engine       Engine      Engine
//       │         │         │
//       ↓         ↓         ↓
//  Passenger     Sports    Offroad
//  Vehicle       Vehicle    Vehicle