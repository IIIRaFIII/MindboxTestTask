using FigureAreaLibrary.Interfaces;
using FigureAreaLibrary.Models;
using FigureAreaLibrary.Resources;

namespace FigureAreaLibrary.Factories
{
    public class TriangleFactory : FigureFactory
    {
        public override int ExpectedParameterCount => 3;

        public override bool TryParseFigureParameters(double[] parameters, out string errorMessage)
        {
            if (parameters == null || parameters.Length != 3)
            {
                errorMessage = ErrorMessage.InvalidParameterCount + " для треугольника.";
                return false;
            }

            try
            {
                var tempTriangle = new Triangle(parameters);
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public override IFigure CreateFigure(double[] parameters)
        {
            return new Triangle(parameters);
        }
    }
}

