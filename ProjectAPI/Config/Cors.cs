using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ProjectAPI
{
  public static class Cors
  {
    public static IApplicationBuilder AddCorsConfiguration(this IApplicationBuilder builder)
    {
      if (builder == null)
      {
        throw new ArgumentNullException(nameof(builder));
      }

      return builder.UseCors((Action<CorsPolicyBuilder>)(c =>
      {
        c.AllowAnyMethod();
        c.AllowAnyHeader();
        c.AllowAnyOrigin();
      }));
    }
  }

}
