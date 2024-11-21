using FigureAreaLibrary.Factories;

namespace FigureAreaLibrary.Services
{
    public static class FigureFactoryCollector
    {
        public static IEnumerable<Type> GetAllFactoryTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(FigureFactory).IsAssignableFrom(type) && !type.IsAbstract && type.IsClass);
        }
    }
}
