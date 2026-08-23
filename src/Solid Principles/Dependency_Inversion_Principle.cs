// Dependency Inversion Principle (DIP) states that high-level modules
// should not depend on low-level modules. Both should depend on abstractions.
// This principle is about decoupling software modules,
// which can lead to more flexible and maintainable code.
// in simple words, it states that class should depend on abstractions rather than concrete implementations.


public interface IMouse
{
    void Click();
    void Scroll();
}
public interface IKeyboard
{
    void Type();
    void PressKey();
}


public class wiredMouse : IMouse
{
    public void Click()
    {
        Console.WriteLine("Wired Mouse Clicked");
    }
    public void Scroll()
    {
        Console.WriteLine("Wired Mouse Scrolled");
    }
}

public class wirelessMouse : IMouse
{
    public void Click()
    {
        Console.WriteLine("Wireless Mouse Clicked");
    }
    public void Scroll()
    {
        Console.WriteLine("Wireless Mouse Scrolled");
    }
}

public class wiredKeyboard : IKeyboard
{
    public void Type()
    {
        Console.WriteLine("Wired Keyboard Typing");
    }
    public void PressKey()
    {
        Console.WriteLine("Wired Keyboard Key Pressed");
    }
}

public class wirelessKeyboard : IKeyboard
{
    public void Type()
    {
        Console.WriteLine("Wireless Keyboard Typing");
    }
    public void PressKey()
    {
        Console.WriteLine("Wireless Keyboard Key Pressed");
    }
}



public class computer
{
    wiredMouse mouse;
    wiredKeyboard keyboard;
    public computer(wiredMouse mouse, wiredKeyboard keyboard)
    {
        this.mouse = mouse;
        this.keyboard = keyboard;  // here the computer class is dependent on the concrete implementations of
                                   // wiredMouse and wiredKeyboard classes. This violates the Dependency
                                   // Inversion Principle (DIP)
                                   // because the computer class should depend on abstractions rather
                                   // than concrete implementations.
    }
    public void UseMouse()
    {
        mouse.Click();
        mouse.Scroll();
    }
    public void UseKeyboard()
    {
        keyboard.Type();
        keyboard.PressKey();
    }
}

// solution for this problem is to create an interface c
// alled IMouse and IKeyboard and implement it in both the
//wiredMouse and wirelessMouse classes. The computer class will
//depend on the IMouse and IKeyboard interfaces rather than
//the concrete implementations of the wiredMouse and wiredKeyboard classes.
//This way we can replace the wiredMouse object with a wirelessMouse object
//without affecting the correctness of the program.

public class Computer
{
    IMouse mouse;
    IKeyboard keyboard;
    public Computer(IMouse mouse, IKeyboard keyboard)
    {
        this.mouse = mouse;
        this.keyboard = keyboard;  // here the computer class is dependent on the abstractions of
                                   // IMouse and IKeyboard interfaces. This follows the Dependency
                                   // Inversion Principle (DIP) because the computer class depends on
                                   // abstractions rather than concrete implementations.
    }
    public void UseMouse()
    {
        mouse.Click();
        mouse.Scroll();
    }
    public void UseKeyboard()
    {
        keyboard.Type();
        keyboard.PressKey();
    }
}