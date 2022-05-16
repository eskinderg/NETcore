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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      //Registering dynamically all mappings that implement IEntityTypeConfiguration 
      modelBuilder.ApplyConfigurationsFromAssembly(
          Assembly.GetExecutingAssembly(), 
          t => t.GetInterfaces().Any(i => 
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
            typeof(BaseEntity).IsAssignableFrom(i.GenericTypeArguments[0])));
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
