using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1.Task2.Drawing2D
{
    public class FigureList : IEnumerable<IFigure>
    {
        private List<IFigure> figures = new List<IFigure>();

        public void Add(IFigure item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            figures.Add(item);
        }

        public void Remove(IFigure item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            figures.Remove(item);
        }

        public IEnumerator<IFigure> GetEnumerator()
        {
            return figures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return figures.GetEnumerator();
        }
    }
}
