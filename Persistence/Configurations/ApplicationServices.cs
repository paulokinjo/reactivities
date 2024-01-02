using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Reactivities.Persistence.Configurations;
public static class PersistenceServices
{
  public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<DataContext>(opt => opt.UseSqlite(configuration.GetConnectionString("Default")));
    return services;
  }
}
