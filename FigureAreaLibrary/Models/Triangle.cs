using FigureAreaLibrary.Interfaces;
using FigureAreaLibrary.Services;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("FigureAreaLibrary.Tests")]

namespace FigureAreaLibrary.Models
{
    public class Triangle : IFigure
    {
        public double[] _sides;

        internal Triangle(params double[] sides)
        {
            _sides = sides
                .OrderByDescending(side => side)
                .ToArray();

            Accept(new FigureValidationVisitor());
        }

        public bool IsRightAngled
            => Math.Abs(Math.Pow(_sides[0], 2) - Math.Pow(_sides[1], 2) - Math.Pow(_sides[2], 2)) < Double.Epsilon;

        public double CalculateSquare()
        {
            double semiPerimeter = _sides.Sum() / 2;
            return Math.Sqrt(semiPerimeter * _sides
                   .Aggregate(1.0, (x, y) => x * (semiPerimeter - y)));
        }

        public void Accept(IFigureValidationVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
