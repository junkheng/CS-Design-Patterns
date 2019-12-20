using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace StaticDecoratorComposition
{
    // Static Decorator Composition Pattern ** not to be used in C# as not meant to be
    public abstract class Shape
    {
        public abstract string AsString();
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle() : this(0)
        {
            
        }

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            radius *= factor;
        }

        public override string AsString()
        {
            return $"A circle with radius {radius}";
        }
    }

    public class Square : Shape
    {
        private float side;

        public Square() : this(0.0f)
        {
            
        }

        public Square(float side)
        {
            this.side = side;
        }
        public override string AsString()
        {
            return $"A square with side {side}";
        }
    }

    // Decorator
    public class ColoredShape<T> : Shape where T : Shape, new()
    {
        private string color;
        private T shape = new T();

        public ColoredShape() : this("black")
        {
            
        }

        public ColoredShape(string color)
        {
            this.color = color;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} and color {color}";
        }
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private float transparency;
        private T shape = new T();

        public TransparentShape() : this(0)
        {

        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

    public override string AsString() => $"{shape.AsString()} and {transparency * 100}% transparency";
    }



    static class Program
    {
        static void Main(string[] args)
        {
            var circle = new TransparentShape<ColoredShape<Circle>>(0.4f);
            WriteLine(circle.AsString());
        }
    }
}
