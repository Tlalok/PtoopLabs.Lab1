using System;

namespace Lab1.Task2.Drawing2D.Polygons
{
    public class Rectangle : IPlaneShape
    {
        public Point UpperLeftCorner { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public double Area => Width * Height;

        public double Perimeter => 2 * (Width + Height);

        public Rectangle(Point upperLeftCorner, int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Rectangle width must be greater than 0");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), "Rectangle height must be greater than 0");
            }

            UpperLeftCorner = upperLeftCorner;
            Width = width;
            Height = height;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine($"Rectangle({UpperLeftCorner.X}, {UpperLeftCorner.Y}; {Width}; {Height})");
        }
    }
}
