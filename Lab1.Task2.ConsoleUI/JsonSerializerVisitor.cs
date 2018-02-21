using Lab1.Task2.Drawing2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Task2.Drawing2D.Curves;
using Lab1.Task2.Drawing2D.Lines;
using Lab1.Task2.Drawing2D.Polygons;

namespace Lab2.Task2.ConsoleUI
{
    public class JsonSerializerVisitor : IVisitor
    {
        public string Json { get; set; }

        public void Visit(Circle circle)
        {
            Json = $"{{ 'radius' : {circle.Radius}, 'center': {{ 'x': {circle.Center.X}, 'y':{circle.Center.Y} }} }}";
        }

        public void Visit(Ellipse ellipse)
        {
            throw new NotImplementedException();
        }

        public void Visit(LineSegment lineSegment)
        {
            throw new NotImplementedException();
        }

        public void Visit(PolygonalChain polygonalChain)
        {
            throw new NotImplementedException();
        }

        public void Visit(Rectangle rectangle)
        {
            throw new NotImplementedException();
        }

        public void Visit(Square square)
        {
            throw new NotImplementedException();
        }

        public void Visit(Triangle triangle)
        {
            throw new NotImplementedException();
        }
    }
}
