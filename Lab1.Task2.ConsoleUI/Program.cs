using Lab1.Task2.Drawing2D;
using Lab1.Task2.Drawing2D.Curves;
using Lab1.Task2.Drawing2D.Lines;
using Lab1.Task2.Drawing2D.Polygons;
using System.Collections.Generic;

namespace Lab2.Task2.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var figureList = new FigureList();

            figureList.Add(new Circle (new Point(10, 20 ), 10));
            figureList.Add(new Rectangle(new Point(5, 15), 15, 25));
            figureList.Add(new Square(new Point(0, 0 ), 5));
            var points = new List<Point>
            {
                new Point(14, 26),
                new Point(23, 18),
                new Point(96, 21)
            };
            figureList.Add(new PolygonalChain(points));

            foreach (var figure in figureList)
            {
                figure.Draw();
            }
        }
    }
}
