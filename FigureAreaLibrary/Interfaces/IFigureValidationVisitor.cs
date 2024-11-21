using FigureAreaLibrary.Models;

namespace FigureAreaLibrary.Interfaces
{
    public interface IFigureValidationVisitor
    {
        void Visit(Circle circle);
        void Visit(Triangle triangle);
    }
}
