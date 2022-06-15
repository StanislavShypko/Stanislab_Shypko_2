namespace Laba2_2;

public static class Program
{
    public static void Main()
    {
        var gamingRoom = new GamingRoom(2000, 12);
        
        var ball = new Ball("Червоний м'яч", 700, ToySize.Medium);
        var doll = new Doll("Гарна лялька", 500, ToySize.Small);
        var car = new Car("Зелена машина", 655, ToySize.Big);
        var cube = new Cube("Кубики", 1000, ToySize.Big);

        gamingRoom.BuyToy(ball);
        gamingRoom.BuyToy(doll);
        gamingRoom.BuyToy(car);
        gamingRoom.BuyToy(cube);

        var foundToy = gamingRoom.Toys.FirstOrDefault(toy => toy.Price < 700 && toy.Size == ToySize.Big);
        if (foundToy is not null)
        {
            Console.WriteLine($"Знайдено iграшку - {foundToy.Description} за {foundToy.Price}");
        }
        else
        {
            Console.WriteLine("Iграшку не знайдено");
        }
    }
}

public class GamingRoom
{
    public List<Toy> Toys { get; set; }
    public double Budget { get; set; }
    public int MinimalAge { get; set; }

    public GamingRoom(double budget, int minimalAge)
    {
        Budget = budget;
        MinimalAge = minimalAge;
        
        Toys = new List<Toy>();
    }

    public void BuyToy(Toy toy)
    {
        if (Budget >= toy.Price)
        {
            Budget -= toy.Price;
            Toys.Add(toy);
            Console.WriteLine($"Куплено iграшку - {toy.Description} за {toy.Price}");
            return;
        }

        Console.WriteLine("Вже нема грошей");
    } 
}

public enum ToySize
{
    Small,
    Medium,
    Big
}

public abstract class Toy
{
    public string Description { get; set; }
    public double Price { get; set; }
    public ToySize Size { get; set; }

    protected Toy(string description, double price, ToySize size)
    {
        Description = description;
        Price = price;
        Size = size;
    }
}

public class Car : Toy
{
    public Car(string description, double price, ToySize size) : base(description, price, size)
    {
    }
}

public class Doll : Toy
{
    public Doll(string description, double price, ToySize size) : base(description, price, size)
    {
    }
}

public class Cube : Toy
{
    public Cube(string description, double price, ToySize size) : base(description, price, size)
    {
    }
}

public class Ball : Toy
{
    public Ball(string description, double price, ToySize size) : base(description, price, size)
    {
    }
}