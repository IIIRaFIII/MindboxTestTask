using FigureAreaLibrary.Abstractions;
using FigureAreaLibrary.Factories;
using FigureAreaLibrary.Interfaces;
using FigureAreaLibrary.Resources;

namespace FigureAreaLibrary.Services
{
    public class FigureHandler : IFigureHandler
    {
        private readonly List<FigureFactory> _factories;

        public FigureHandler(List<FigureFactory> factories)
        {
            _factories = factories;
        }

        public List<FigureFactory> GetMatchingFactory(double[] parameters, out string validationError)
        {
            validationError = null;

            if (parameters == null || parameters.Length == 0)
            {
                validationError = ErrorMessage.NullOrEmptyParametersError;
                return null;
            }

            var matchingFactories = _factories
                .Where(factory => factory.ExpectedParameterCount == parameters.Length)
                .ToList();

            if (!matchingFactories.Any())
            {
                validationError = $"Нет подходящей фугуры для обработки {parameters.Length} параметров.";
                return null;
            }
            var validFactories = new List<FigureFactory>();
            var errors = new Dictionary<FigureFactory, string>();

            foreach (var factory in matchingFactories)
            {
                if (factory.TryParseFigureParameters(parameters, out string error))
                {
                    validationError = null;
                    validFactories.Add(factory);
                }
                else
                {
                    errors[factory] = error;
                }
            }

            if (!validFactories.Any())
            {
                validationError = "Параметры не удовлетворяют условиям:\n" +
                          string.Join("\n", errors.Select(e => $"{e.Key.GetType().Name}: {e.Value}"));
                return null;
            }

            if (errors.Any())
            {
                validationError = "Ошибки для следующих фигур:\n" +
                                  string.Join("\n", errors.Select(e => $"{e.Key.GetType().Name}: {e.Value}"));
            }


            return validFactories;
        }




        public IFigure CreateFigure(FigureFactory factory, double[] parameters, out string validationError)
        {
            validationError = null;

            if (factory == null)
            {
                validationError = "Фабрика не найдена. Проверьте параметры.";
                return null;
            }

            if (parameters == null || parameters.Length == 0)
            {
                validationError = ErrorMessage.NullOrEmptyParametersError;
                return null;
            }

            if (!factory.TryParseFigureParameters(parameters, out validationError))
            {
                return null; 
            }

            validationError = null;
            return factory.CreateFigure(parameters);
        }
    }
}

