using FluentAssertions;
using FigureAreaLibrary.Factories;
using FigureAreaLibrary.Models;

namespace FigureAreaLibrary.Tests.Factories
{
    public class TriangleFactoryTests
    {
        [Fact]
        public void TriangleFactory_TryParseFigureParameters_ValidSides_Success()
        {
            var factory = new TriangleFactory();
            var parameters = new double[] { 3.0, 4.0, 5.0 };

            var result = factory.TryParseFigureParameters(parameters, out string errorMessage);

            result.Should().BeTrue();
            errorMessage.Should().BeNull();
        }

        [Fact]
        public void TriangleFactory_TryParseFigureParameters_InvalidSides_Fail()
        {
            var factory = new TriangleFactory();
            var parameters = new double[] { 1.0, 2.0, 10.0 };

            var result = factory.TryParseFigureParameters(parameters, out string errorMessage);

            result.Should().BeFalse();
            errorMessage.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void TriangleFactory_CreateFigure_ValidSides_ReturnsTriangle()
        {
            var factory = new TriangleFactory();
            var parameters = new double[] { 3.0, 4.0, 5.0 };

            var triangle = factory.CreateFigure(parameters);

            triangle.Should().NotBeNull();
            triangle.Should().BeOfType<Triangle>();
        }
    }
}
