using FigureAreaLibrary.Abstractions;
using FigureAreaLibrary.Factories;


namespace FigureAreaLibrary.Services
{
    public class FigureHandlerBuilder : IFigureHandlerBuilder
    {
        private readonly List<FigureFactory> _factories = new();

        public FigureHandlerBuilder RegisterFactory<T>() where T : FigureFactory, new()
        {

            _factories.Add(new T());
            return this;
        }

        public IFigureHandler Build()
        {
            return new FigureHandler(_factories);
        }

        public FigureHandlerBuilder RegisterAllFactories()
        {
            foreach (var factoryType in FigureFactoryCollector.GetAllFactoryTypes())
            {
                typeof(FigureHandlerBuilder)
                    .GetMethod("RegisterFactory")
                    ?.MakeGenericMethod(factoryType)
                    .Invoke(this, null);
            }

            return this;
        }
    }
}

