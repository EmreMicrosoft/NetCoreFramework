using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface IModule
    {
        void Load(IServiceCollection service);
    }
}