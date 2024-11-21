using FigureAreaLibrary.Models;
using FigureAreaLibrary.Services;

namespace FigureAreaLibrary.Tests.Models
{
    public class CircleTests
    {
        [Fact]
        public void CalculateSquare_ValidRadius_ReturnsCorrectArea()
        {
            var radius = 5;
            var circle = new Circle(radius);

            var area = circle.CalculateSquare();

            Assert.Equal(Math.PI * Math.Pow(radius, 2), area, 5);
        }

        [Fact]
        public void Constructor_NegativeRadius_ThrowsArgumentException()
        {
            var invalidRadius = -5;

            Assert.Throws<ArgumentException>(() => new Circle(invalidRadius));
        }

        [Fact]
        public void Constructor_ZeroRadius_ThrowsArgumentException()
        {
            var zeroRadius = 0;

            Assert.Throws<ArgumentException>(() => new Circle(zeroRadius));
        }

        [Fact]
        public void Constructor_LargeRadius_CreatesCircleSuccessfully()
        {
            var largeRadius = 1e6;

            var circle = new Circle(largeRadius);

            Assert.NotNull(circle);
            var area = circle.CalculateSquare();
            Assert.True(area > 0);
        }

        [Fact]
        public void Accept_VisitWithCircle_DoesNotThrow()
        {
            var visitor = new FigureValidationVisitor();
            var circle = new Circle(1);

            var exception = Record.Exception(() => circle.Accept(visitor)); 

            Assert.Null(exception);
        }
    }
}
