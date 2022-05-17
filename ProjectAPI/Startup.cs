using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using ProjectAPI.Ioc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Identity.Authorization;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;

namespace ProjectAPI
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var config = Configuration.GetSection("ApplicationSettings").Get<AppSettings>();

      services.Configure<AppSettings>(Configuration.GetSection("ApplicationSettings"));

      services.AddDbContext<AppDbContext>(
          options => options.UseMySql(config.DbConnectionString, ServerVersion.AutoDetect(config.DbConnectionString))
          );

      services.AddApiVersioningConfiguration(config.Api.VersionReader, config.Api.AssumeDefaultVersionWhenUnspecified);

      services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Content API", Version = "v1" }); });

      services.AddAuthorizationConfiguration();

      services.AddAuthenticationConfiguration()
        .AddJwtBearerConfiguration(
            config.IdentityServer.Authority, config.IdentityServer.Audience, config.IdentityServer.RequireHttpsMetadata
            );

      RegisterServices(services);

      services.AddControllers();

    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.AddCorsConfiguration();

      app.UseAuthentication();

      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contents API V1"); });

      app.UseSwagger();

      app.UseRouting();

      app.UseAuthorization();

      app.AddEndpoints();

    }

    private static void RegisterServices(IServiceCollection services)
    {
      NativeInjectorBootStrapper.RegisterServices(services);
    }

  }
}
