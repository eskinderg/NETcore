using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Identity.Authorization;

namespace ProjectAPI.Identity.Authorization
{
    public class ClaimsRequirementHandler : AuthorizationHandler<MyClaimRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyClaimRequirement requirement)
        {
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == requirement.ClaimName);

            if (claim != null && claim.Value.Contains(requirement.ClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
