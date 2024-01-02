using Microsoft.EntityFrameworkCore;
using Reactivities.Domain;

namespace Reactivities.Persistence
{
  public class DataContext : DbContext
  {
    public DbSet<Activity> Activities => Set<Activity>();

    public DataContext(DbContextOptions options) : base(options)
    {

    }
  }
}