using Lab1.Task2.Drawing2D.Curves;
using Lab1.Task2.Drawing2D.Lines;
using Lab1.Task2.Drawing2D.Polygons;

namespace Lab1.Task2.Drawing2D
{
    public interface IVisitor
    {
        void Visit(Circle circle);
        void Visit(Ellipse ellipse);
        void Visit(LineSegment lineSegment);
        void Visit(PolygonalChain polygonalChain);
        void Visit(Rectangle rectangle);
        void Visit(Square square);
        void Visit(Triangle triangle);
    }
}
