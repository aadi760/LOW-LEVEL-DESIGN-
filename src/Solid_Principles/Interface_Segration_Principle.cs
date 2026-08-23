// Interface segration principle states that a class should not be forced to
// implement interfaces it does not use. In other words, an interface should
// have only the methods that are relevant to the implementing class.
// This principle helps to reduce the complexity of the code and makes it easier to maintain.


public interface RestaurantEmployee
{
    void WashDishes();
    void CookFood();
    void ServeFood();
    void TakeOrders();
}

public class Waiter: RestaurantEmployee
{
    public void WashDishes()
    {
        throw new NotImplementedException("Waiter does not wash dishes");
    }
    public void CookFood()
    {
        throw new NotImplementedException("Waiter does not cook food"); // here it violates the Interface
                                                                        // Segregation Principle (ISP) because
                                                                        // the Waiter class is forced to implement
                                                                        // methods that it does not use.
    }
    public void ServeFood()
    {
        Console.WriteLine("Serving food to customers");
    }
    public void TakeOrders()
    {
        Console.WriteLine("Taking orders from customers");
    }
}

// solution for this problem is to create separate
// interfaces for each responsibility and implement
// them in the classes that need them.


public interface IWaiter
{
    void ServeFood();
    void TakeOrders();
}

public interface ICook
{
    void CookFood();
}

public interface IDishWasher
{
    void WashDishes();
}

public class waiter : IWaiter
{
    public void ServeFood()
    {
        Console.WriteLine("Serving food to customers");
    }
    public void TakeOrders()
    {
        Console.WriteLine("Taking orders from customers");
    }
}

public class Cook : ICook
{
    public void CookFood()
    {
        Console.WriteLine("Cooking food for customers");
    }
}

// now they follow ISP