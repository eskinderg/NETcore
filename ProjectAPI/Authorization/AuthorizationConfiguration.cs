
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectAPI.Identity.Authorization
{
    public static class AuthorizationConfigurationExtenstion
    {
        public static IServiceCollection AddAuthorizationConfiguration(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }


            return services.AddAuthorization((Action<AuthorizationOptions>)(o =>
                        {
                        // o.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("name", "Alice Smith")));
                        // o.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("name", "Bob Smith")));
                        // o.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("name", "Eskinder")));
                        // o.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("name", "Kukusha")));
                        // o.AddPolicy("CanRemoveCustomerData", policy => policy.Requirements.Add(new MyClaimRequirement("Customers", "Remove")));
                        // o.AddPolicy("IsAdmin", policy => policy.Requirements.Add(new RoleClaimRequirement("Admin")));
                        o.AddPolicy("CanWrite", policy => policy.Requirements.Add(new RoleClaimRequirement("Write")));
                        o.AddPolicy("CanRead", policy => policy.Requirements.Add(new RoleClaimRequirement("Read")));
                        }));
        }
    }

}
