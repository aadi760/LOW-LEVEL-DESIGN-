# SOLID Principles & Design Patterns

Notes and worked examples for SOLID principles and common design patterns, implemented in C# under `src/`. Each example contrasts a "before" (violating) version with an "after" (fixed) version in the same file.

## SOLID Principles — `src/Solid_Principles/`

| Principle | File | Example |
|---|---|---|
| Single Responsibility Principle (SRP) | [Single_Responsiblity_Priinciple.cs](../src/Solid_Principles/Single_Responsiblity_Priinciple.cs) | `Invoice` originally calculated totals, printed, and saved to DB in one class. Split into `Invoice`, `InvoicePrinter`, and `Inoicedac`, each with a single responsibility. |
| Open/Closed Principle (OCP) | [Open_Closed_Principle.cs](../src/Solid_Principles/Open_Closed_Principle.cs) | `InvoiceDac` required modifying the class to add a new save target (file). Replaced with an `InvoiveDao` interface and separate `fileInvoiceDao` / `dbInvoiceDao` implementations, so new storage types extend behavior without changing existing code. |
| Liskov Substitution Principle (LSP) | [Liskov_Substitution_Principle.cs](../src/Solid_Principles/Liskov_Substitution_Principle.cs) | `Bicycle : Vehicle` threw `NotImplementedException` from `StartEngine()`, breaking substitutability. Fixed by introducing an `IVehicle` interface (just `WheelCount()`) and an `EngineVehicle` base for engine-bearing vehicles, so `Bicycle` no longer inherits a method it can't support. |
| Interface Segregation Principle (ISP) | [Interface_Segration_Principle.cs](../src/Solid_Principles/Interface_Segration_Principle.cs) | A single `RestaurantEmployee` interface forced `Waiter` to implement `WashDishes()`/`CookFood()` it doesn't use. Split into focused `IWaiter`, `ICook`, `IDishWasher` interfaces implemented only by the roles that need them. |
| Dependency Inversion Principle (DIP) | [Dependency_Inversion_Principle.cs](../src/Solid_Principles/Dependency_Inversion_Principle.cs) | `computer` depended directly on concrete `wiredMouse`/`wiredKeyboard`. Fixed `Computer` depends on `IMouse`/`IKeyboard` abstractions instead, allowing wired or wireless implementations to be swapped freely. |

## Design Patterns — `src/Common_Design_Patterns/`

### Behavioral Patterns

| Pattern | Folder | Status |
|---|---|---|
| Strategy | [Behavioral_Design_Patterns/StrategyDesignPattern/](../src/Common_Design_Patterns/Behavioral_Design_Patterns/StrategyDesignPattern/) | 🚧 Scaffolded (`WithoutStrategyDesignPattern.cs`, `WithStrategyDesignPattern.cs`) — implementation pending |

## Design Patterns Used
- SRP, OCP, LSP, ISP, DIP applied across `src/Solid_Principles/`
- Strategy pattern (in progress) under `src/Common_Design_Patterns/Behavioral_Design_Patterns/`
