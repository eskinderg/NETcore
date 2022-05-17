using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ProjectAPI
{
  public static class RouteConfig
  {
    public static IApplicationBuilder AddEndpoints(this IApplicationBuilder builder)
    {
      if (builder == null)
      {
        throw new ArgumentNullException(nameof(builder));
      }

      return builder.UseEndpoints((Action<IEndpointRouteBuilder>)(endpoints =>
                  {
                    endpoints.MapControllerRoute(
                                  name: "default",
                                  pattern: "{controller=Home}/{action=Index}/{id?}");

                  }));
    }
  }

}
