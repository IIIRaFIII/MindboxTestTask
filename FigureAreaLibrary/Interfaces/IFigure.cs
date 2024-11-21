namespace FigureAreaLibrary.Interfaces
{
    public interface IFigure
    {
        double CalculateSquare();
        void Accept(IFigureValidationVisitor visitor);
    }
}
