using AppDependencyInject_Lab.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AppDependencyInject_Lab.Utility.DI_Config
{
  public static class ConfigureDIServices
  {
    public static IServiceCollection AddAllServices(this IServiceCollection services)
    {
     
      return services;
    }

  }
}
