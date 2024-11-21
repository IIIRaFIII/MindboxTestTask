using FigureAreaLibrary.Interfaces;
using FigureAreaLibrary.Models;
using FigureAreaLibrary.Resources;

namespace FigureAreaLibrary.Services
{
    public class FigureValidationVisitor : IFigureValidationVisitor
    {
        public void Visit(Circle circle)
        {
            if (circle.Radius <= 0)
            {
                throw new ArgumentException(ErrorMessage.ParameterMustBePositive, nameof(circle.Radius));
            }
        }

        public void Visit(Triangle triangle)
        {
            var sides = triangle._sides;
            if (sides == null || sides.Length != 3)
            {
                throw new ArgumentException("Треугольник должен иметь ровно три стороны.");
            }

            if (sides.Any(side => side <= 0))
            {
                throw new ArgumentException(ErrorMessage.ParameterMustBePositive, nameof(triangle._sides));
            }

            if (sides.Any(side => side <= 1e-3))
            {
                throw new ArgumentException("Все стороны треугольника должны быть больше 0.001.");
            }

            if (sides.Any(side => side <= 0.0001))
            {
                throw new ArgumentException("Все стороны треугольника должны быть больше 0.0001.");
            }

            if (sides[0] + sides[1] <= sides[2] ||
                sides[0] + sides[2] <= sides[1] ||
                sides[1] + sides[2] <= sides[0])
            {
                throw new ArgumentException("Стороны треугольника не удовлетворяют условию существования.");
            }
        }
    }

}
