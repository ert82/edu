Immutable types (objects or data structures) are types that, once initialized, cannot change their internal state. That’s it.

# Why

In most applications, data integrity and consistency is usually of paramount importance. We don’t want data being mutated in odd fashions and, as a result, being erroneously stored in our database or returned to the user. We want to ensure with the best predictability that the data we are using remains consistent with what we expect. This is vital when it comes to asynchronous and multi-threaded applications.

Immutable objects are inherently thread-safe; they require no synchronization. They cannot be corrupted by multiple threads accessing them concurrently. This is far and away the easiest approach to achieving thread safety. In fact, no thread can ever observe any effect of another thread on an immutable object. Therefore, immutable objects can be shared freely.

The only real disadvantage of immutable classes is that they require a separate object for each distinct value.

# Why strings are immutable

Thread safety and performance. If a string cannot be modified it is safe and quick to pass a reference around among multiple threads. If strings were mutable, you would always have to copy all of the bytes of the string to a new instance, or provide synchronization.

# Before

```c#
public class RGBColor
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public RGBColor(int red = 0, int green = 0, int blue = 0)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }
}
```

# After

- Remove setters.
- Turn the private fields into readonly (or create them, if they don’t exist at this point).
- Change the constructor so it requires all needed parameters at construction time.

```c#
public class RGBColor
{
    private readonly int red;
    private readonly int green;
    private readonly int blue;

    public int Red => red;
    public int Green => green;
    public int Blue => blue;

    public RGBColor(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }
}
```

Starting with C# 6.0, there is this feature called “readonly automatically implemented properties”

```c#
public class RGBColor
{
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }
 
    public RGBColor(int red, int green, int blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }
}
```

# Vs mutable

https://softwareengineering.stackexchange.com/questions/151733/if-immutable-objects-are-good-why-do-people-keep-creating-mutable-objects

Immutable objects do indeed make life simpler in many cases. They are especially applicable for value types, where objects don't have an identity so they can be easily replaced. And they can make concurrent programming way safer and cleaner (most of the notoriously hard to find concurrency bugs are ultimately caused by mutable state shared between threads). However, for large and/or complex objects, creating a new copy of the object for every single change can be very costly and/or tedious. And for objects with a distinct identity, changing an existing objects is much more simple and intuitive than creating a new, modified copy of it.

Think about a game character. In games, speed is top priority, so representing your game characters with mutable objects will most likely make your game run significantly faster than an alternative implementation where a new copy of the game character is spawned for every little change.

Moreover, our perception of the real world is inevitably based on mutable objects. When you fill up your car with fuel at the gas station, you perceive it as the same object all along (i.e. its identity is maintained while its state is changing) - not as if the old car with an empty tank got replaced with consecutive new car instances having their tank gradually more and more full. So whenever we are modeling some real-world domain in a program, it is usually more straightforward and easier to implement the domain model using mutable objects to represent real-world entities.

Apart from all these legitimate reasons, alas, the most probable cause why people keep creating mutable objects is inertia of mind, a.k.a. resistance to change. Note that most developers of today have been trained well before immutability (and the containing paradigm, functional programming) became "trendy" in their sphere of influence, and don't keep their knowledge up to date about new tools and methods of our trade - in fact, many of us humans positively resist new ideas and processes. "I have been programming like this for nn years and I don't care about the latest stupid fads!"

Especially in GUI programming, mutable object are very handy.











