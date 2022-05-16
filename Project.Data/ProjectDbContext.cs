using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Project.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity => base.Set<TEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var implementedConfigTypes = Assembly.GetExecutingAssembly()
        .GetTypes().Where(t => !t.IsAbstract
            && !t.IsGenericTypeDefinition
            && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
              i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

      foreach (var configType in implementedConfigTypes)
      {
        dynamic config = Activator.CreateInstance(configType);
        modelBuilder.ApplyConfiguration(config);
      }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // get the configuration from the app settings
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      // define the database to use
      // optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }

    public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
    {
      throw new NotImplementedException();
    }

  }
}
