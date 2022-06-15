using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Laba2_1;

public static class Program
{
    public static void Main()
    {
        var car = new Car("Audi A8", 0, new Engine(550));
        Console.WriteLine(car);
        car.Ride();
        
        car.Fill(100);        
        Console.WriteLine(car);

        var wheel1 = new Wheel(Side.FrontLeft, 100, true);
        var wheel2 = new Wheel(Side.FrontRight, 100, true);
        var wheel3 = new Wheel(Side.BackLeft, 100, true);
        var wheel4 = new Wheel(Side.BackRight, 100, true);
        car.AddWheel(wheel1);
        car.AddWheel(wheel2);
        car.AddWheel(wheel3);
        car.AddWheel(wheel4);
        
        // Зайве колесо:
        car.AddWheel(wheel4);
        
        var door1 = new Door(Side.FrontLeft, Color.Beige);
        var door2 = new Door(Side.FrontRight, Color.Aqua);
        var door3 = new Door(Side.BackLeft, Color.Chocolate);
        var door4 = new Door(Side.BackRight, Color.Navy);
        car.AddDoor(door1);
        car.AddDoor(door2);
        car.AddDoor(door3);
        car.AddDoor(door4);
        
        // Зайве:
        car.AddDoor(door4);
        
        car.Ride();
    }
}

public class Car
{
    public string Model { get; set; }
    
    public Engine Engine { get; set; }

    public List<Wheel> Wheels { get; set; }
    
    public List<Door> Doors { get; set; }
    
    public double GasolineAmount { get; set; }

    public Car(string model, double gasolineAmount, Engine engine)
    {
        Model = model;
        GasolineAmount = gasolineAmount;

        Engine = engine;

        Wheels = new();
        Doors = new();
    }

    public override string ToString()
    {
        return $"Машина {Model}, {GasolineAmount}Л.";
    }

    public void Ride()
    {
        if (GasolineAmount <= 0)
        {
            Console.WriteLine("Немає пального");
            return;
        }
        Engine.Start();
        Console.WriteLine("Машина запущена");
    }

    public void Fill(double gasolineAmount)
    {
        GasolineAmount += gasolineAmount;
    }

    public void AddWheel(Wheel wheel)
    {
        if (Wheels.Any(w => w.Side == wheel.Side))
        {
            Console.WriteLine("Колесо на данiй позицiї вже присутнє.");
            return;
        }
        Wheels.Add(wheel);

        Console.WriteLine($"Колесо ({wheel.Side}) змiнено.");
    }
    
    public void RemoveWheel(Side side)
    {
        var wheel = Wheels.FirstOrDefault(w => w.Side == side);
        if (wheel is not null)
        {
            Wheels.Remove(wheel);
            Console.WriteLine($"Колесо ({side}) видалено.");
            return;
        }

        Console.WriteLine($"Такого колеса ({side}) немає.");
    }
    
    public void AddDoor(Door door)
    {
        if (Doors.Any(w => w.Side == door.Side))
        {
            Console.WriteLine("Дверi на данiй позицiї вже присутнi.");
            return;
        }
        Doors.Add(door);

        Console.WriteLine($"Дверi ({door.Side}) змiнено.");
    }
    
    public void RemoveDoor(Side side)
    {
        var door = Doors.FirstOrDefault(w => w.Side == side);
        if (door is not null)
        {
            Doors.Remove(door);
            Console.WriteLine($"Дверi ({side}) видалено.");
            return;
        }

        Console.WriteLine($"Такої дверi ({side}) немає.");
    }
}

public class Engine
{
    public double Power { get; set; }

    public Engine(double power)
    {
        Power = power;
    }

    public void Start()
    {
        Console.WriteLine("Двигун запущено.");
    }
}

public class Wheel
{
    public double Radius { get; set; }
    public bool HasWinterTires { get; set; }
    public Side Side { get; set; }

    public Wheel(Side side, double radius, bool hasWinterTires)
    {
        Side = side;
        Radius = radius;
        HasWinterTires = hasWinterTires;
    }
}

public enum Side
{
    FrontLeft,
    FrontRight,
    BackLeft,
    BackRight
}

public class Door
{
    public Side Side { get; set; }
    public Color Color { get; set; }

    public Door(Side side, Color color)
    {
        Side = side;
        Color = color;
    }
}
