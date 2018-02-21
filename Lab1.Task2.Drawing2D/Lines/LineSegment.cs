using System;

namespace Lab1.Task2.Drawing2D.Lines
{
    public class LineSegment : ILine
    {
        public Point FirstPoint { get; set; }

        public Point SecondPoint { get; set; }

        public double Length => Math.Sqrt(Math.Pow(FirstPoint.X - SecondPoint.X, 2) + Math.Pow(FirstPoint.Y - SecondPoint.Y, 2));

        public LineSegment(Point firstPoint, Point secondPoint)
        {
            if (firstPoint == secondPoint)
            {
                throw new ArgumentException("The points must be different.");
            }

            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine($"LineSegment({FirstPoint.X}, {FirstPoint.Y}; {SecondPoint.X}, {SecondPoint.Y})");
        }
    }
}
