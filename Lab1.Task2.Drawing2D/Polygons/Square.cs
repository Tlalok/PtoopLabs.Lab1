using System;

namespace Lab1.Task2.Drawing2D.Polygons
{
    public class Square : IPlaneShape
    {
        public Point UpperLeftCorner { get; set; }
        public int Side { get; set; }

        public double Area => Side * Side;

        public double Perimeter => 4 * Side;

        public Square(Point upperLeftCorner, int side)
        {
            if (side <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(side), "Square side must be greater than 0");
            }
            UpperLeftCorner = upperLeftCorner;
            Side = side;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine($"Square({UpperLeftCorner.X}, {UpperLeftCorner.Y}; {Side})");
        }
    }
}
