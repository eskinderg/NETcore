using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectAPI
{
  public static class ApiVersionConfig
  {
    public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services, string versionReader, bool assumeDefaultVersionWhenUnspecified)
    {
      if (services == null)
      {
        throw new ArgumentNullException(nameof(services));
      }

      return services.AddApiVersioning((Action<ApiVersioningOptions>)(o =>
      {
        /* o.ApiVersionReader                 = new UrlSegmentApiVersionReader(); */
        o.ApiVersionReader                    = new HeaderApiVersionReader(versionReader);
        o.AssumeDefaultVersionWhenUnspecified = assumeDefaultVersionWhenUnspecified;
        o.DefaultApiVersion                   = new ApiVersion(1, 0);
        o.ReportApiVersions                   = true;
      }));
    }
  }

}
