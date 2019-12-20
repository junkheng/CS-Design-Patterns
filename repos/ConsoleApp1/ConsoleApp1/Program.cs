using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    // Dynamic Decorator Pattern
    public interface IShape
    {
        string AsString();
    }

    public class Circle : IShape
    {
        private float radius;

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }

        public string AsString() => $"A circle with radius {radius}";
    }

    public class Square : IShape
    {
        private float side;

        public Square(float side)
        {
            this.side = side;
        }
        public string AsString() => $"A square with side {side}";
    }

    // Decorator
    public class ColoredShape : IShape
    {
        private IShape shape;
        private string color;

        public ColoredShape(IShape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public string AsString() => $"{shape.AsString()} has the color {color}";
    }

    // Decorator on top of Decorator ColoredShape
    public class TransparentShape : IShape
    {
        private IShape shape;
        private float transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }
        public string AsString() => $"{shape.AsString()} and {transparency * 100.0}% transparency";
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(1.23f);
            WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "red");
            WriteLine(redSquare.AsString());

            var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
            WriteLine(redHalfTransparentSquare.AsString());
        }
    }
    //public interface IBird
    //{
    //    void Fly();
    //    int Weight { get; set; }
    //}

    //public class Bird : IBird
    //{
    //    public int Weight { get; set; }
    //    public void Fly()
    //    {
    //        WriteLine($"Soaring in the sky with weight {Weight}");
    //    }
    //}

    //public interface ILizard
    //{
    //    void Crawl();
    //    int Weight { get; set; }
    //}

    //public class Lizard : ILizard
    //{
    //    public int Weight { get; set; }
    //    public void Crawl()
    //    {
    //        WriteLine($"Crawling like a boss with weight {Weight}");
    //    }
    //}

    //public class Dragon : IBird, ILizard
    //{
    //    private Bird bird = new Bird();
    //    private Lizard lizard = new Lizard();
    //    private int _weight;

    //    public void Crawl()
    //    {
    //        lizard.Crawl();
    //    }

    //    public void Fly()
    //    {
    //        bird.Fly();
    //    }

    //    public int Weight
    //    {
    //        get { return _weight; }
    //        set
    //        {
    //            _weight = value;
    //            bird.Weight = value;
    //            lizard.Weight = value;
    //        }
    //    }
    //}
    //static class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var d = new Dragon();
    //        d.Weight = 123;
    //        d.Fly();
    //        d.Crawl();
    //    }
    //}
}
