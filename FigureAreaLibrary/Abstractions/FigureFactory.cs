using FigureAreaLibrary.Interfaces;

namespace FigureAreaLibrary.Factories
{
    public abstract class FigureFactory
    {
        public abstract int ExpectedParameterCount { get; }
        public abstract bool TryParseFigureParameters(double[] parameters, out string errorMessage);
        public abstract IFigure CreateFigure(double[] parameters);
    }
}
