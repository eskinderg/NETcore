
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectAPI.Identity.Authorization
{
    public static class JwtBearerExtenstion
    {

        public static AuthenticationBuilder AddJwtBearerConfiguration(this AuthenticationBuilder builder, string issuer, string audience, bool requireHttps)
        {
            return builder.AddJwtBearer(options =>
    {
        options.Authority = issuer;
        options.Audience = audience;
        options.RequireHttpsMetadata = requireHttps;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { ValidAudiences = new string[] { "master-realm", "account", "api2" } };
        options.Events = new ProjectJwtBearerEvents();

    });
        }

        public static AuthenticationBuilder AddAuthenticationConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddAuthentication((Action<AuthenticationOptions>) (o => {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }));
        }

    }
}