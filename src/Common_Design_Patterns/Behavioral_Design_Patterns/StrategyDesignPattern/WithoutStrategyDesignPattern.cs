// Stategy Design Pattern Is a Behavioural Design Pattern that encapsulate the family of interchangble algorithms behind the common
// interface and allowing the behaviour to be decided at runtime without modifiying the context

// now do the example without using the strategy design pattern

public class vehicle
{
   void Engine
    {
       console.WriteLine("Engine is running");
    }
}


public class PassengerVehicle : vehicle
{
    void Engine
    {
        console.WriteLine(Engine is running");
    }
}

public class SportsVehicle : vehicle
{
    void Engine
    {
        console.WriteLine(" Sports Engine is running"); // here we have to modify the context class to add new behaviour
    }
}

public class OffroadVehicle
{
    void Engine
    {
        console.WriteLine(" Sports Engine is running"); // here we have duplicate code and we have to modify the
                                                        // context class to add new behaviour
    }
    
}


// so we are duplicating the code also 
// so we are modifying the context class to add new behaviour which is not a good practice
// to avoid this we can use the strategy design pattern which will encapsulate the family of interchangble algorithms
// behind the common interface and allowing the behaviour to be decided at runtime without modifiying the context