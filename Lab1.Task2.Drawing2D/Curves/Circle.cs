using System;

namespace Lab1.Task2.Drawing2D.Curves
{
    public class Circle : IPlaneShape
    {
        public Point Center { get; set; }

        public int Radius { get; set; }

        public double Area => Math.PI * Radius * Radius;

        public double Perimeter => 2 * Math.PI * Radius;

        public Circle(Point center, int radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Circle radius must be greater than 0");
            }

            Center = center;
            Radius = radius;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine($"Circle({Center.X}, {Center.Y}; {Radius})");
        }
    }
}
