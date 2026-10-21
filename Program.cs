using System;
public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}
public interface ICreateShape
{
    string MenuName { get; }
    IShape CreateShape();
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a shape:");
        Console.WriteLine("1. Trapezium");
        Console.WriteLine("2. Circle");
        Console.WriteLine("3. Nonagon");

        int choice = (int)Input("choose (1-3): ");

        IShape shape;
        ICreateShape shapeCreator;

        switch (choice)
        {
            case 1:
                shapeCreator = new CreateTrapezium();
                shape = shapeCreator.CreateShape();
                break;
            case 2:
                shapeCreator = new CreateCircle();
                shape = shapeCreator.CreateShape();
                break;
            case 3:
                shapeCreator = new CreateNonagon();
                shape = shapeCreator.CreateShape();
                break;
            default:
                Console.WriteLine("Doesn't work, re-run the program");
                return;        
            }

        Console.WriteLine($"Area: {shape.CalculateArea()}");
        Console.WriteLine($"Perimeter: {shape.CalculatePerimeter()}");
    }
    public static double Input(string message)
    {
        double value;

        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                return value;
            }
            else
            {
                Console.WriteLine("Enter a number greater than 0");
            }
        }
    }
}

public class Trapezium : IShape
{

    //has 4 sides, 2 parallel sides, 2 non-parallel sides and height
    readonly double a,b,c,d,h;
    public Trapezium(double a, double b, double c, double d, double h)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
        this.h = h;
    }
    public void CalculateUnknownSides()
    {
        //big base - small base = remaining base
        //pythagoras theorem


    }
    public double CalculateArea()
    {
        return (a + b) / 2 * h;
    }
    public double CalculatePerimeter()
    {
        return a + b + c + d;
    }
}

public class CreateTrapezium : ICreateShape
{
    public string MenuName => "Trapezium";

    public IShape CreateShape()
    {
        double a = Program.Input("Enter the length of side a (parallel): ");
        double b = Program.Input("Enter the length of side b (parallel): ");
        double c = Program.Input("Enter the length of side c (non-parallel): ");
        double d = Program.Input("Enter the length of side d (non-parallel): ");
        double h = Program.Input("Enter the height: ");
        return new Trapezium(a, b, c, d, h);
    }
}
public class Circle : IShape
{
    double diameter;
    public Circle(double diameter){
        this.diameter = diameter;
    }

    public double CalculateArea()
    {
    //pi * r^2
        return Math.PI * Math.Pow(CalculateRadius(), 2); 
    }
    public double CalculateRadius()
    {
        return diameter / 2;
    }
    public double CalculatePerimeter()
    {
        //pi*d or pi*2*r
        return Math.PI *2 * CalculateRadius();
    }
}

public class CreateCircle : ICreateShape
{
    public string MenuName => "Circle";

    public IShape CreateShape()
    {
        double diameter = Program.Input("Enter the diameter of the circle: ");
        return new Circle(diameter);
    }
}
public class Nonagon : IShape
{
    int numberOfSides;

    double sideLength, apothem;

    public Nonagon(double sideLength, double apothem)
    {
        this.sideLength = sideLength;
        this.apothem = apothem;
        numberOfSides = 9;
    }

    public double CalculateArea()
    {
        //perimeter * apothem / 2 or numberOfSides * sideLength * apothem / 2
        return CalculatePerimeter() * apothem / 2;
    }
    public double CalculatePerimeter()
    {
        return numberOfSides * sideLength;
    }
    public int CalculateNumberOfSides()
    {
    return numberOfSides;
    }
}
public class CreateNonagon : ICreateShape
    {
        public string MenuName => "Nonagon";

        public IShape CreateShape()
        {
            double sideLength = Program.Input("Enter the length of one side: ");
            double apothem = Program.Input("Enter the apothem: ");
            return new Nonagon(sideLength, apothem);
        }
    }
