// Observer Design Pattern is a behavioral design pattern that allows an object,
// known as the subject or observable, to maintain a list of its dependents, known as observers,
// and notify them automatically of any state changes, usually by calling one of their methods.
// This pattern is particularly useful for implementing distributed event handling systems.

// Common use case is Notify me in Amazon when stock of a product is available or when the price of a product is reduced.
// so we implement the common use case here to understand the observer design pattern


public interface INotificationObserver
{
    void Update();
}

public class NotificationEmailObserver : INotificationObserver
{
    private string email;
    IStockObervable stockObservable;
    public NotificationEmailObserver(string email, IStockObervable stock)
    {
        this.email = email;
        this.stockObservable = stock;
    }
    public void Update()
    {
        sendEmail();
    }
    public void sendEmail()
    {
        Console.WriteLine($"Sending email to {email} ");
    }
}



public interface IStockObervable
{
    void RegisterObserver(INotificationObserver observer);
    void RemoveObserver(INotificationObserver observer);
    void NotifyObservers();
    void UpdateStock(int quantity);
}


public class IphoneStock : IStockObervable
{
    private List<INotificationObserver> observers;
    int stock = 0;

    public IphoneStock(int stock)
    {
        this.stock = stock;
        observers = new List<INotificationObserver>();
    }
    public void RegisterObserver(INotificationObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(INotificationObserver observer)
    {
        observers.Remove(observer);
    }
    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
    public void UpdateStock(int quantity)
    {
        if (stock == 0)
        {
            NotifyObservers();
        }
        this.stock = stock + quantity;

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IphoneStock iphoneStock = new IphoneStock(0);
        NotificationEmailObserver observer1 = new NotificationEmailObserver("adityash549@gmail.com", iphoneStock);
        NotificationEmailObserver observer2 = new NotificationEmailObserver("ram549@gmail.com", iphoneStock);
        NotificationEmailObserver observer3 = new NotificationEmailObserver("sh549@gmail.com", iphoneStock);
        iphoneStock.RegisterObserver(observer1);
        iphoneStock.RegisterObserver(observer2);
        iphoneStock.UpdateStock(10);
    }
}


// this is very simple example of observer design pattern but in real world we can have
// multiple observers and multiple subjects and we can have different types of observers
// like email, sms, push notification etc. and we can have different types of subjects like product, order
// user etc. and we can have different types of notifications like stock available, price reduced, order shipped etc.