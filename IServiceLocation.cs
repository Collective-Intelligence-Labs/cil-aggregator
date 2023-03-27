namespace Cila
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }

    public class ServiceLocator : IServiceLocator
    {
        private readonly ServiceProvider _serviceProvider;

        public ServiceLocator(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>() => _serviceProvider.GetService<T>();
    }
}