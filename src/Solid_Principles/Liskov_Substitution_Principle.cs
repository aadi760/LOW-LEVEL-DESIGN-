// Liskov substitution principle states that objects of a parentclass
// should be replaceable with objects of a childclass without
// affecting the correctness of the program.
// subclass should extend the capabilities of the parent class without changing its behavior.


// for vehicle example we can create a parent class Vehicle and two child classes Car and Bike.
// The Car class will have a method called StartEngine() and the
// Bike class will have a method called KickStart(). Both methods will start the engine of
// the vehicle. The Car class will also have a method called OpenDoor()
// which will open the door of the car. The Bike class will not have this method because
// it does not have doors. Now if we create an object of the Car class and call
// the StartEngine() method, it will work fine. But if we create an object of the Bike
// class and call the StartEngine() method, it will throw an error because the
// Bike class does not have this method. This violates the Liskov Substitution Principle because
// we cannot replace the Car object with a Bike object without affecting the correctness of the program.


class Vehicle
{
    public virtual void StartEngine()
    {
        Console.WriteLine("Starting Engine");
    }
    public int WheelCount()
    {
        Console.WriteLine("Vehicle has 4 wheels");
    }
}


class Car : Vehicle
{
    public override void StartEngine()
    {
        Console.WriteLine("Starting Car Engine");
    }
    public void WheelCount()
    {
        Console.WriteLine("vehicle has 4 wheels");
    }
}

class Bicycle : Vehicle
{
    public override void StartEngine()
    {
        throw new NotImplementedException("Bicycle does not have an engine");  // here it violates the
                                                                               // LSP because we cannot replace
                                                                               // the Car object with a Bicycle
                                                                               // object without affecting the
                                                                               // correctness of the program.
    }
    public void WheelCount()
    {
        Console.WriteLine("vehicle has 2 wheels");
    }
}


//solution for this 
//problem is to create an interface called IVehicle and implement it in
//both the Car and Bicycle classes. The IVehicle interface will have a method called
//StartEngine() which will be implemented in both the Car and Bicycle classes.
//The Car class will implement the StartEngine() method and the Bicycle class will
//not implement this method because it does not have an engine. 
//This way we can replace the Car object with a Bicycle object without affecting the correctness of the program.

public interface IVehicle
{
    void WheelCount();
}

public class EngineVehicle:IVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Starting Engine");
    }
    public void WheelCount()
    {
        Console.WriteLine("vehicle has 4 wheels");
    }
}
public class Car:EngineVehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Starting Car Engine");
    }
    public void WheelCount()
    {
        Console.WriteLine("vehicle has 4 wheels");
    }
}

public class Bicycle:IVehicle
{
    public void WheelCount()
    {
        Console.WriteLine("vehicle has 2 wheels");
    }
}