using System;

namespace Lab1.Task2.Drawing2D.Curves
{
    public class Ellipse : IPlaneShape
    {
        public Point Center { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public double Area => Math.PI * Width * Height;

        public double Perimeter => Math.PI * (Width + Height);

        public Ellipse(Point center, int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Ellipse width must be greater than 0");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Ellipse height must be greater than 0");
            }

            Center = center;
            Width = width;
            Height = height;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine($"Ellipse({Center.X}, {Center.Y}; {Width}; {Height})");
        }
    }
}
