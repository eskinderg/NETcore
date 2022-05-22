using ProjectAPI;
using Project.Data;
using ProjectAPI.Ioc;
using ProjectAPI.Identity.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

var config = configuration.GetSection("ApplicationSettings").Get<AppSettings>();

builder.Services.Configure<AppSettings>(configuration.GetSection("ApplicationSettings"));

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
      options.UseMySql(config.DbConnectionString, ServerVersion.AutoDetect(config.DbConnectionString));
    });

builder.Services.AddApiVersioningConfiguration(config.Api.VersionReader, config.Api.AssumeDefaultVersionWhenUnspecified);

builder.Services.AddAuthorizationConfiguration();

builder.Services.AddAuthenticationConfiguration()
  .AddJwtBearerConfiguration(
      config.IdentityServer.Authority, config.IdentityServer.Audience, config.IdentityServer.RequireHttpsMetadata
      );

NativeInjectorBootStrapper.RegisterServices(builder.Services);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

  app.UseSwagger();

  app.UseSwaggerUI();

}

app.AddCorsConfiguration();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
