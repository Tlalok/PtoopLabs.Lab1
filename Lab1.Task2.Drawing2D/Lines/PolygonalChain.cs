using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1.Task2.Drawing2D.Lines
{
    public class PolygonalChain : ILine
    {
        public List<Point> Points { get; set; }

        public double Length
        {
            get
            {
                double fullLength = 0;
                for (int i = 1; i < Points.Count; i++)
                {
                    var startPoint = Points[i - 1];
                    var endPoint = Points[i];
                    var length = Math.Sqrt(Math.Pow(startPoint.X - endPoint.X, 2) + Math.Pow(startPoint.Y - endPoint.Y, 2));
                    fullLength += length;
                }

                return fullLength;
            }
        }

        public PolygonalChain(IEnumerable<Point> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }
            if (points.Count() < 2)
            {
                throw new ArgumentException("PolygonalChain must contain at least 2 points.", nameof(points));
            }
            Points = new List<Point>(points);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Draw()
        {
            string points = string.Join("; ", Points.Select(p => $"{p.X}, {p.Y}"));
            Console.WriteLine($"PolygonalChain({points})");
        }
    }
}
