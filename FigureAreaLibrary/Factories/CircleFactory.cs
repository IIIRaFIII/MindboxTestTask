using FigureAreaLibrary.Interfaces;
using FigureAreaLibrary.Models;
using FigureAreaLibrary.Resources;

namespace FigureAreaLibrary.Factories
{
    public class CircleFactory : FigureFactory
    {
        public override int ExpectedParameterCount => 1;

        public override bool TryParseFigureParameters(double[] parameters, out string errorMessage)
        {
            if (parameters == null || parameters.Length != 1)
            {
                errorMessage = ErrorMessage.InvalidParameterCount + " для круга.";
                return false;
            }

            try
            {
                var tempCircle = new Circle(parameters[0]);
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
            return new Circle(parameters[0]);
        }
    }
}