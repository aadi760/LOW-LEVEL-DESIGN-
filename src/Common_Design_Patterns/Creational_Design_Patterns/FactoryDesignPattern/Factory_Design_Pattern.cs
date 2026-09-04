// Factory Design Pattern is a creational design pattern that provides an interface for creating objects in a superclass,
// but allows subclasses to alter the type of objects that will be created.
// It is used when the client code needs to create objects without knowing the
//exact class of the object that will be created.
// so we use factory pattern because it hides the object creation logic from the client 
// and provides a simple interface to create objects of different types based on the input provided by the client.

// now we see some examples of factory design pattern in c# to understand it better

// payment example is a common example of factory design pattern where we have different
// payment methods like credit card, debit card, net banking etc.

public void interface IPayment
{
    void Pay(double amount);
}

public class CreditCardPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using Credit Card");
    }
}

public class DebitCardPayment : IPayment {

    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using debit card");
    }

}

public class  UPIPayment:IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} using UPI");
    }
}

public class PaymentFactory
{
    public static IPayment GetPaymentMethod(string PaymentType)
    {
        switch (PaymentType)
        {
            case "CreditCard":
                return new CreditCardPayment();
            case "DebitCard":
                return new DebitCardPayment();
            case "UPI":
                return new UPIPayment();
            default:
                throw new ArgumentException("Invalid payment type");
        }

    }

}

public class Program
{
    public static void Main(string[] args)
    {
        // without using factory design pattern we have to create object of each payment method and call pay method on it

        IPayment payment = new CreditCardPayment();
        payment.Pay(1000);
        IPayment payment2 = new DebitCardPayment();
        payment2.Pay(2000);
        IPayment payment3 = new UPIPayment();
        payment3.Pay(3000);

        // so this creates a messey code and we have to create object of each payment method and call pay method on it

        // now we will use factory design pattern to create object of payment method and call pay method on it

        IPayment payment4 = PaymentFactory.GetPaymentMethod("CreditCard");
        IPayment payment5 = PaymentFactory.GetPaymentMethod("DebitCard");
        IPayment payment6 = PaymentFactory.GetPaymentMethod("UPI"); // here we hiding the object creation logic from the
                                                                    // client and providing
                                                                    // a simple interface to create objects of different
                                                                    // types based on the input provided by the client

    }

}