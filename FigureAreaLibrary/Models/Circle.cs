using FigureAreaLibrary.Interfaces;
using FigureAreaLibrary.Services;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("FigureAreaLibrary.Tests")]

namespace FigureAreaLibrary.Models
{
    public class Circle : IFigure
    {
        public double Radius { get; }

        internal Circle(double radius)
        {
            Radius = radius;

            Accept(new FigureValidationVisitor());
        }


        public double CalculateSquare() => Math.PI * Math.Pow(Radius, 2);

        public void Accept(IFigureValidationVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
