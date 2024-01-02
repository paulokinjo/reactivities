using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reactivities.Persistence.Configurations;

namespace Reactivities.Application.Configurations;
public static class ApplicationServices
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddPersistenceServices(configuration);

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    services.AddAutoMapper(Assembly.GetExecutingAssembly());
    return services;
  }
}
