using System;

namespace Lab1.Task2.Drawing2D.Polygons
{
    public class Triangle : IPlaneShape
    {
        public Point FirstApex { get; set; }
        public Point SecondApex { get; set; }
        public Point ThirdApex { get; set; }

        public double Area
        {
            get
            {
                var a = ClaculateLength(FirstApex, SecondApex);
                var b = ClaculateLength(SecondApex, ThirdApex);
                var c = ClaculateLength(FirstApex, ThirdApex);
                var p = (a + b + c) / 2.0;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }

        public double Perimeter
        {
            get
            {
                return ClaculateLength(FirstApex, SecondApex) + ClaculateLength(SecondApex, ThirdApex) + ClaculateLength(FirstApex, ThirdApex);
            }
        }

        public Triangle(Point firstApex, Point secondApex, Point thirdApex)
        {
            if (firstApex == secondApex || firstApex == thirdApex || secondApex == thirdApex)
            {
                throw new ArgumentException("All points must be different.");
            }

            FirstApex = firstApex;
            SecondApex = secondApex;
            ThirdApex = thirdApex;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw()
        {
            Console.WriteLine($"Triangle({FirstApex.X}, {FirstApex.Y}; {SecondApex.X}, {SecondApex.Y}; {ThirdApex.X}, {ThirdApex.Y})");
        }

        private double ClaculateLength(Point first, Point second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }
    }
}
