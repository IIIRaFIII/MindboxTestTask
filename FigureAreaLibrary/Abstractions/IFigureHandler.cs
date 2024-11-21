using FigureAreaLibrary.Factories;
using FigureAreaLibrary.Interfaces;

namespace FigureAreaLibrary.Abstractions
{
    public interface IFigureHandler
    {
        List<FigureFactory> GetMatchingFactory(double[] parameters, out string validationError);
        IFigure CreateFigure(FigureFactory factory, double[] parameters, out string validationError);
    }
}
