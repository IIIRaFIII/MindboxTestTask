using FigureAreaLibrary.Models;
using FigureAreaLibrary.Services;

class Program
{
    static void Main(string[] args)
    {
        var handlerBuilder = new FigureHandlerBuilder();
        handlerBuilder.RegisterAllFactories();
        var handler = handlerBuilder.Build();

        Console.WriteLine("Тестирование для круга: 5 (радиус)");
        Console.WriteLine("Тестирование для треугольника: 3 4 5 (длины сторон)");

        while (true)
        {
            Console.WriteLine("\nВведите параметры фигуры (или 'exit' для выхода):");
            string input = Console.ReadLine();
            if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Выход");
                break;
            }

            try
            {
                double[] parameters = ParseInput(input);

                var validFactories = handler.GetMatchingFactory(parameters, out string validationError);

                if (validFactories == null || !validFactories.Any())
                {
                    Console.WriteLine($"Ошибка: {validationError}");
                    continue;
                }

                if (!string.IsNullOrEmpty(validationError))
                {
                    Console.WriteLine(validationError);
                }


                foreach (var factory in validFactories)
                {
                    var figure = handler.CreateFigure(factory, parameters, out string creationError);

                    if (figure == null)
                    {
                        Console.WriteLine($"Ошибка при создании фигуры ({factory.GetType().Name}): {creationError}");
                        continue;
                    }

                    Console.WriteLine($"Площадь фигуры ({factory.GetType().Name.Replace("Factory", "")}): {figure.CalculateSquare():F2}");

                    if (figure is Triangle triangle)
                    {
                        Console.WriteLine($"Треугольник прямоугольный: {triangle.IsRightAngled}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    static double[] ParseInput(string input)
    {
        try
        {
            return input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }
        catch
        {
            throw new ArgumentException("Неверный формат ввода. Убедитесь, что параметры являются числами.");
        }
    }
}



