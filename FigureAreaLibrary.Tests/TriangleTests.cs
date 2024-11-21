using FigureAreaLibrary.Models;
using FigureAreaLibrary.Services;

namespace FigureAreaLibrary.Tests.Models
{
    public class TriangleTests
    {
        [Fact]
        public void CalculateSquare_ValidSides_ReturnsCorrectArea()
        {
            var sides = new[] { 3.0, 4.0, 5.0 };
            var triangle = new Triangle(sides);

            var area = triangle.CalculateSquare();

            Assert.Equal(6.0, area, 5);
        }

        [Fact]
        public void Constructor_InvalidSides_ThrowsArgumentException()
        {
            var invalidSides = new[] { 1.0, 2.0, 10.0 };

            Assert.Throws<ArgumentException>(() => new Triangle(invalidSides));
        }

        [Fact]
        public void Constructor_NegativeOrZeroSides_ThrowsArgumentException()
        {
            var invalidSidesSet1 = new[] { -1.0, 2.0, 3.0 };
            var invalidSidesSet2 = new[] { 0.0, 4.0, 5.0 };

            Assert.Throws<ArgumentException>(() => new Triangle(invalidSidesSet1));
            Assert.Throws<ArgumentException>(() => new Triangle(invalidSidesSet2));
        }

        [Theory]
        [InlineData(3.0, 4.0, 5.0, true)]
        [InlineData(5.0, 12.0, 13.0, true)]
        [InlineData(6.0, 8.0, 10.0, true)]
        [InlineData(3.0, 3.0, 3.0, false)]
        [InlineData(4.0, 5.0, 6.0, false)] 
        public void IsRightAngled_CorrectlyIdentifiesRightTriangle(double side1, double side2, double side3, bool isRight)
        {
            var sides = new[] { side1, side2, side3 };
            var triangle = new Triangle(sides);

            var result = triangle.IsRightAngled;

            Assert.Equal(isRight, result);
        }

        [Fact]
        public void Constructor_LargeSides_CreatesTriangleSuccessfully()
        {
            var largeSides = new[] { 1e6, 1e6, 1e6 };
            var triangle = new Triangle(largeSides);

            Assert.NotNull(triangle);
            var area = triangle.CalculateSquare();
            Assert.True(area > 0);
        }

        [Fact]
        public void Constructor_AlmostZeroSides_ThrowsArgumentException()
        {
            var almostZeroSides = new[] { double.Epsilon, double.Epsilon, double.Epsilon };

            Assert.Throws<ArgumentException>(() => new Triangle(almostZeroSides));
        }

        [Fact]
        public void Constructor_SidesWithExtremeDifference_ThrowsArgumentException()
        {
            var extremeDifferenceSides = new[] { 1e-6, 1e-6, 1e6 };

            Assert.Throws<ArgumentException>(() => new Triangle(extremeDifferenceSides));
        }

        [Fact]
        public void Constructor_LargeAndValidSides_CreatesTriangleSuccessfully()
        {
            var validLargeSides = new[] { 1e6, 1e6, 1.5e6 };
            var triangle = new Triangle(validLargeSides);

            Assert.NotNull(triangle);
            var area = triangle.CalculateSquare();
            Assert.True(area > 0);
        }

        [Fact]
        public void Accept_VisitWithTriangle()
        {
            var visitor = new FigureValidationVisitor();
            var triangle = new Triangle(1, 1, 1);

            var exception = Record.Exception(() => triangle.Accept(visitor));

            Assert.Null(exception); 
        }
    }
}
