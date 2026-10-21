using System;
public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}

public class Trapezium : IShape
{

    //has 4 sides, 2 parallel sides, 2 non-parallel sides and height

    double a,b,c,d,h;

    public Trapezium(double a, double b, double c, double d, double h)
    {
        this.a = a; //a is parallel to b
        this.b = b;
        this.c = c; //c is non-parallel to d
        this.d = d;
        this.h = h; //height
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

class Program
{
    static double Input(string message)
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

        static void Main()
        {
            Console.WriteLine("Choose a shape:");
            Console.WriteLine("1. Trapezium");
            Console.WriteLine("2. Circle");
            Console.WriteLine("3. Nonagon");

            int choice = (int)Input("choose (1-3): ");

            IShape shape;

            switch (choice)
            {
                case 1:
                    double a = Input("Enter the length of side a (parallel): ");
                    double b = Input("Enter the length of side b (parallel): ");
                    double c = Input("Enter the length of side c (non-parallel): ");
                    double d = Input("Enter the length of side d (non-parallel): ");
                    double h = Input("Enter the height: ");
                    shape = new Trapezium(a, b, c, d, h);
                    break;
                case 2:
                    double diameter = Input("Enter the diameter of the circle: ");
                    shape = new Circle(diameter);
                    break;
                case 3:
                    double sideLength = Input("Enter the length of one side: ");
                    double apothem = Input("Enter the apothem: ");
                    shape = new Nonagon(sideLength, apothem);
                    break;
                default:
                    Console.WriteLine("Doesn't work, re-run the program");
                    return;
            }

            Console.WriteLine($"Area: {shape.CalculateArea()}");
            Console.WriteLine($"Perimeter: {shape.CalculatePerimeter()}");
        }
}