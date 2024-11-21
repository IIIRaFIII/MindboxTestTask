using FluentAssertions;
using FigureAreaLibrary.Factories;
using FigureAreaLibrary.Models;

namespace FigureAreaLibrary.Tests.Factories
{
    public class CircleFactoryTests
    {
        [Fact]
        public void CircleFactory_TryParseFigureParameters_ValidRadius_Success()
        {
            var factory = new CircleFactory();
            var parameters = new double[] { 5.0 };

            var result = factory.TryParseFigureParameters(parameters, out string errorMessage);

            result.Should().BeTrue();
            errorMessage.Should().BeNull();
        }

        [Fact]
        public void CircleFactory_TryParseFigureParameters_NegativeRadius_Fail()
        {
            var factory = new CircleFactory();
            var parameters = new double[] { -5.0 };

            var result = factory.TryParseFigureParameters(parameters, out string errorMessage);

            result.Should().BeFalse();
            errorMessage.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void CircleFactory_CreateFigure_ValidRadius_ReturnsCircle()
        {
            var factory = new CircleFactory();
            var parameters = new double[] { 5.0 };

            var circle = factory.CreateFigure(parameters);

            circle.Should().NotBeNull();
            circle.Should().BeOfType<Circle>();
        }
    }
}
